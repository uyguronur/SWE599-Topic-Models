#ifndef DOCUMENT_H
#define DOCUMENT_H

#include "word.h"
#include <stdio.h>
#include <fstream>
#include <vector>

class Document
{
private:
  std::vector<Word> _words;
  std::string _name;
  Document(std:: string name, std::ifstream *stream);

public:
  static Document* create(const char *file_name);
  Word* get_word(const int index);
  int get_total_words();
  std::string get_name();
};

#endif