#include "utils.h"
#include <fstream>
#include <string>
#include <vector>
#include <ctype.h>
#include <algorithm>

using namespace std;

string Utils::clear_word(string word)
{
    word.erase(remove_if(word.begin(), word.end(), Utils::char_accepted), word.end());
    std::transform(word.begin(), word.end(), word.begin(), ::tolower);
    return word;
}

bool Utils::char_accepted(char c)
{
    return !isalpha(c) && !isdigit(c);
}
