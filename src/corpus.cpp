#include "corpus.h"
#include "logger.h"

using namespace std;

Corpus *Corpus::create(const char *lists_file)
{
    ifstream file(lists_file);
    if (!file.is_open())
    {
        return NULL;
    }
    auto corpus = new Corpus(&file);
    file.close();
    return corpus;
}

Corpus::Corpus(ifstream *stream)
{
    string line;
    while (getline(*stream, line))
    {
        auto document = Document::create(line.c_str());
        if (document == NULL)
        {
            LOG(ERROR) << "Document " << line << " not found! Ignoring...";
        }
        else
        {
            for(auto i = 0; i < document->get_total_words(); i++)
            {
                if(_vocabulary_map.find(document->get_word(i)->word) != _vocabulary_map.end())
                {
                    document->get_word(i)->vocabulary_index = _vocabulary_map.find(document->get_word(i)->word)->second;
                }
                else
                {
                    auto new_index = _vocabulary_map.size() + 1;
                    document->get_word(i)->vocabulary_index = new_index;
                    _vocabulary_map.insert(pair<string,int>(document->get_word(i)->word, new_index));
                    _inverse_vocabulary_map.insert(pair<int,string>(new_index, document->get_word(i)->word));
                }
            }
            _documents.push_back(document);
            LOG(DEBUG) << "Document " << document->get_name() << " added to corpus! Total Words: " << document->get_total_words();
        }
    }
}

Corpus::~Corpus()
{
    for (auto document : _documents)
    {
        if (document)
        {
            delete document;
        }
    }
}

int Corpus::get_num_of_documents()
{
    return _documents.size();
}

int Corpus::get_number_of_words(const int document_index)
{
    return _documents.at(document_index)->get_total_words();
}

int Corpus::get_num_of_vocabularies()
{
    return _vocabulary_map.size();
}

string Corpus::get_vocabulary(const int vocabulary_index)
{
    return _inverse_vocabulary_map.find(vocabulary_index)->second;
}

Document *Corpus::get_document(const int document_index)
{
    return _documents.at(document_index);
}

Word *Corpus::get_word(const int document_index, const int word_index)
{
    return _documents.at(document_index)->get_word(word_index);
}