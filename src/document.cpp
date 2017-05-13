#include <vector>
#include <string>

#include "document.h"
#include "logger.h"
#include "utils.h"

using namespace std;

Document* Document::create(const char *file_name)
{
    ifstream file(file_name);
    if (!file.is_open())
    {
        return NULL;
    }
    auto document =  new Document(string(file_name), &file);
    file.close();
    return document;
}

Document::Document(std:: string name, std::ifstream *stream) : _name(name)
{
    string word;
    while (*stream >> word)
    {
        auto cleared_word = Utils::clear_word(word);
        if(cleared_word.length() <= 3)
        {
            _ignored_words.push_back(word);
        }
        else
        {
            _words.push_back({-1, -1, cleared_word});
        }
    }
}

Word *Document::get_word(const int index)
{
    return &_words[index];
}

int Document::get_total_words()
{
    return _words.size();
}

string Document::get_name()
{
    return _name;
}

vector<string>* Document::get_ignored_words()
{
    return &_ignored_words;
}