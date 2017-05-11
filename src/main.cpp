#include <stdio.h>
#include <algorithm>
#include "logger.h"
#include "corpus.h"

structlog LOGCFG = {}; //init logger

void print_help()
{
    LOG(INFO) << "Topic Modeling App";
    LOG(INFO) << "Author: Onur Uygur, Computer Engineering Department, Bogazici University";
    LOG(INFO) << "------------------------------------------------------------------------";
    LOG(INFO) << "Parameters:";
    LOG(INFO) << "-f\trequired\tcorpus file for document names";
    LOG(INFO) << "-k\trequired\tNumber of topics";
    LOG(INFO) << "-d\toptional\tEnable debug mode";
}

char *get_cmd_option(char **begin, char **end, const std::string &option)
{
    char **itr = std::find(begin, end, option);
    if (itr != end && ++itr != end)
    {
        return *itr;
    }
    return 0;
}

bool cmd_option_exists(char **begin, char **end, const std::string &option)
{
    return std::find(begin, end, option) != end;
}

bool try_get_options(int *argc, char *argv[], char **f, int &k, bool &d)
{
    //check if help wanted
    if (cmd_option_exists(argv, argv + *argc, "-h"))
    {
        return false;
    }  

    if (!cmd_option_exists(argv, argv + *argc, "-f"))
    {
        LOG(ERROR) << "parameter -f is required";
        return false;
    }
    else
    {
        *f = get_cmd_option(argv, argv + *argc, "-f");
    }   

    if (!cmd_option_exists(argv, argv + *argc, "-k"))
    {
        LOG(ERROR) << "parameter -k is required\n";
        return false;
    }
    else
    {
        k = std::atoi(get_cmd_option(argv, argv + *argc, "-k"));
    }

    d = false;
    if (cmd_option_exists(argv, argv + *argc, "-d"))
    {
        d = true;
    }
    return true;
}

int main(int argc, char *argv[])
{
    LOGCFG.level = INFO;
    LOGCFG.headers = true;
    char* file = 0;
    int k;
    bool d;
    if(!try_get_options(&argc, argv, &file, k, d))
    {
        print_help();
        return -1;
    }
    if(d)
    {
        LOGCFG.level = DEBUG;
    }
    Corpus *corpus = Corpus::create(file);
    delete corpus;
    return 0;
}
