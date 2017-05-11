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
            _documents.push_back(document);
            LOG(DEBUG)  << "Document " << document->get_name() << " added to corpus! Total Words: " << document->get_total_words();
        }
    }
}

Corpus::~Corpus()
{
    for(auto document : _documents)
    {
        if(document)
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

Word* Corpus::get_word(int document_index, int word_index)
{
    return _documents.at(document_index)->get_word(word_index);
}