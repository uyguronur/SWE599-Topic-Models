#ifndef CORPUS_H
#define CORPUS_H

#include "document.h"
#include <vector>
#include <fstream>
#include <map>

class Corpus{
private:
std::vector<Document*> _documents;
std::map<std::string, int> _vocabulary_map;
std::map<int, std::string> _inverse_vocabulary_map;
Corpus(std::ifstream *stream);
public:
~Corpus();
static Corpus* create(const char *lists_file);
int get_num_of_documents();
int get_number_of_words(const int document_index);
int get_num_of_vocabularies();
std::string get_vocabulary(const int vocabulary_index);
Document* get_document(const int document_index);
Word* get_word(const int document_index, const int word_index);
};

#endif