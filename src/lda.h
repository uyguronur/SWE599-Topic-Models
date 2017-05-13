#ifndef LDA_H
#define LDA_H

#include "corpus.h"

class LDA
{
  private:
    Corpus *_corpus;
    int itr;
    int _iterations, _total_topics, _total_docs, _total_vocabulary;
    double _alpha, _beta;
    int **_word_indexes;           //word index array
    int **_topic_assignments;      //topic label array
    int **_document_topics_count;  //given document m, count times of topic k
    int **_topic_vocabulary_count; //given topic k, count times of vocabulary v
    int *_topic_words_count; // total number of words assigned to topic
    int *_document_words_count; //total number of words in document
    int gibbs_sample(int doc, int word);
    void save_result(int itr);
  public:
    LDA(Corpus *corpus, int iterations, int total_topics, double alpha, double beta);
    void start();
    ~LDA();
};

#endif