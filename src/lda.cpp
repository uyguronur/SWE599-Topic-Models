#include "lda.h"
#include "logger.h"
#include "utils.h"
#include <stdlib.h>
#include <time.h>

#define MAX_ITERS 1000

LDA::LDA(Corpus *corpus, int iterations, int total_topics, double alpha, double beta) : _corpus(corpus), _iterations(iterations), _total_topics(total_topics), _alpha(alpha), _beta(beta)
{
    LOG(0) << "Initializing LDA model and assigning random topics to words in corpus";
    srand(time(NULL));
    _total_docs = _corpus->get_num_of_documents();
    _total_vocabulary = _corpus->get_num_of_vocabularies();

    _word_indexes = new int *[_total_docs];
    _topic_assignments = new int *[_total_docs];
    _document_topics_count = new int *[_total_docs];
    _topic_vocabulary_count = new int *[_total_topics];
    _topic_words_count = new int[_total_topics];
    _document_words_count = new int[_total_docs];
    for (auto i = 0; i < _total_topics; i++)
    {
        _topic_vocabulary_count[i] = new int[_total_vocabulary]();
    }
    for (auto i = 0; i < _total_docs; i++)
    {
        auto total_words = _corpus->get_document(i)->get_total_words();
        _word_indexes[i] = new int[total_words]();
        _topic_assignments[i] = new int[total_words]();
        _document_topics_count[i] = new int[_total_topics]();
        for (auto j = 0; j < total_words; j++)
        {
            auto vocabulary_index = _corpus->get_document(i)->get_word(j)->vocabulary_index;
            _word_indexes[i][j] = vocabulary_index;
            auto topic = rand() % _total_topics;
            _topic_assignments[i][j] = topic;
            _document_topics_count[i][topic] += 1;
            _topic_vocabulary_count[topic][vocabulary_index] += 1;
            _topic_words_count[topic]++;
        }
        _document_words_count[i] = total_words;
    }
}

void LDA::start()
{
    for (itr = 1; itr <= _iterations; itr++)
    {
        LOG(itr) << " ";
        for(auto doc = 0; doc < _total_docs; doc++)
        {
            auto word_size = _corpus->get_number_of_words(doc);
            for(auto word = 0; word < word_size; word++)
            {
                auto new_topic = gibbs_sample(doc, word);
                _topic_assignments[doc][word] = new_topic;
            }
        }
        save_result(itr);
    }
}

int LDA::gibbs_sample(int doc, int word)
{
    LOG(itr) << "Sampling doc: " << doc << " word: " << word;
    int old_topic = _topic_assignments[doc][word];
    _document_topics_count[doc][old_topic]--;
    _topic_vocabulary_count[old_topic][_word_indexes[doc][word]]--;
    _topic_words_count[old_topic]--;
    _document_words_count[doc]--;
    double p[_total_topics];
    for (auto k = 0; k < _total_topics; k++)
    {
        p[k] = (_topic_vocabulary_count[k][_word_indexes[doc][word]] + _beta) /
        (_topic_words_count[k] + _total_vocabulary * _beta) *
        (_document_topics_count[doc][k] + _alpha);
        // / (_document_words_count[doc] + _total_topics);
    }
    for(auto k = 1; k < _total_topics; k++)
    {
        p[k] += p[k-1];
    }

    double u = (rand() / (RAND_MAX + 1.)) * p[_total_topics-1];
    int new_topic;
    for(new_topic = 0; new_topic < _total_topics; new_topic++)
    {
        if(u < p[new_topic]){
            break;
        }
    }
    LOG(itr) << "Sampled doc: " << doc << " word: " << word << " old topic: " << old_topic << " new topic: " << new_topic;

    _document_topics_count[doc][new_topic]++;
    _topic_vocabulary_count[new_topic][_word_indexes[doc][word]]++;
    _topic_words_count[new_topic]++;
    _document_words_count[doc]++;
    return new_topic;
}

void LDA::save_result(int itr)
{
    double topic_word_dist[_total_topics][_total_vocabulary];
    double document_topic_dist[_total_docs][_total_topics];

    for(auto topic = 0; topic < _total_topics; topic++)
    {
        for(auto voc = 0; voc < _total_vocabulary; voc++)
        {
            topic_word_dist[topic][voc] = (_topic_vocabulary_count[topic][voc] + _beta) / (_topic_words_count[topic] + _total_vocabulary * _beta);
        }
    }

    for(auto doc = 0; doc < _total_docs; doc++)
    {
        for(auto topic = 0; topic < _total_topics; topic++)
        {
            document_topic_dist[doc][topic] = (_document_topics_count[doc][topic] + _alpha) / (_document_words_count[doc] + _total_topics * _alpha);
        }
    }

    std::ofstream file;
    file.open("itr/"+to_string(itr) + "_twd.csv");
    for(auto i = 0; i < _total_topics; i++)
    {
        file << "," << i;
    }
    file << endl;
    for(auto j = 1; j <= _total_vocabulary; j++)
    {
        file << _corpus->get_vocabulary(j);
        for(auto i = 0; i < _total_topics; i++)
        {
            file << "," << topic_word_dist[i][j];
        }
        file << endl;
    }
    file.close();
    file.open("itr/"+to_string(itr) + "_dtd.csv");
    for(auto i = 0; i < _total_topics; i++)
    {
        file << "," << i;
    }
    file << endl;
    for(auto i = 0; i < _total_docs; i++)
    {
        file << _corpus->get_document(i)->get_name();
        for(auto j = 0; j < _total_topics; j++)
        {
            file << "," << document_topic_dist[i][j];
        }
        file << endl;
    }
    file.close();
}

LDA::~LDA()
{
    delete[] _topic_vocabulary_count;
    for (auto i = 0; i < _total_docs; i++)
    {
        delete[] _word_indexes[i];
        delete[] _topic_assignments[i];
        delete[] _document_topics_count[i];
    }
    delete[] _word_indexes;
    delete[] _topic_assignments;
    delete[] _document_topics_count;
    for (auto i = 0; i < _total_topics; i++)
    {
        delete[] _topic_vocabulary_count[i];
    }
    delete[] _topic_words_count;
    delete[] _document_words_count;
}