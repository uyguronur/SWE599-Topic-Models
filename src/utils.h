#ifndef UTILS_H
#define UTILS_H

#include "corpus.h"
#include <iostream>
#include <vector>

class Utils
{
  private:
  static bool char_accepted(char c);
  public:
    static std::string clear_word(std::string word);
};

#endif