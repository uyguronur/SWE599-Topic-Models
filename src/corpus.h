#ifndef CORPUS_H
#define CORPUS_H

#include "document.h"
#include <vector>
#include <fstream>

class Corpus{
private:
std::vector<Document*> _documents;
Corpus(std::ifstream *stream);
public:
~Corpus();
static Corpus* create(const char *lists_file);
int get_num_of_documents();
int get_number_of_words(const int document_index);
Word* get_word(int document_index, int word_index);
};

#endif