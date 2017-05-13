#include <stdio.h>
#include <algorithm>
#include "logger.h"
#include "corpus.h"
#include "lda.h"

#define ITERATIONS 1000;
#define ALPHA 50;
#define BETA 0.1;
#define DEBUG_ENABLED false;

structlog LOGCFG = {}; //init logger

void print_help()
{
    LOG(INFO) << "Topic Modeling App";
    LOG(INFO) << "Author: Onur Uygur, Computer Engineering Department, Bogazici University";
    LOG(INFO) << "------------------------------------------------------------------------";
    LOG(INFO) << "Parameters:";
    LOG(INFO) << "-f\trequired\tcorpus file for document names";
    LOG(INFO) << "-k\trequired\tNumber of topics";
    LOG(INFO) << "-d\toptional\tEnable debug mode\tDefault: " << DEBUG_ENABLED;
    LOG(INFO) << "-i\toptional\tNumber of iIterations\tDefault: " << ITERATIONS;
    LOG(INFO) << "-a\toptional\tALPHA\tDefault: " << 50 << "/k";
    LOG(INFO) << "-b\toptional\tBETA\tDefault: " << BETA;
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

bool try_get_options(int *argc, char *argv[], char **f, int &k, bool &d, int &i, double &a, double &b)
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
        if(k <= 0)
        {
            LOG(ERROR) << "parameter -k should be positive\n";
            return false;
        }
    }

    d = DEBUG_ENABLED;
    if (cmd_option_exists(argv, argv + *argc, "-d"))
    {
        d = true;
    }

    i = ITERATIONS;
    if (cmd_option_exists(argv, argv + *argc, "-i"))
    {
        i= std::atoi(get_cmd_option(argv, argv + *argc, "-i"));
        if(i <= 0)
        {
            LOG(ERROR) << "parameter -i should be positive\n";
            return false;
        }
    }

    a = 50. / (double)k;
    if (cmd_option_exists(argv, argv + *argc, "-a"))
    {
        a= std::atof(get_cmd_option(argv, argv + *argc, "-a"));
        if(a <= 0)
        {
            LOG(ERROR) << "parameter -a should be positive\n";
            return false;
        }
    }

    b = BETA;
    if (cmd_option_exists(argv, argv + *argc, "-b"))
    {
        b= std::atof(get_cmd_option(argv, argv + *argc, "-b"));
        if(b <= 0)
        {
            LOG(ERROR) << "parameter -b should be positive\n";
            return false;
        }
    }

    return true;
}

int main(int argc, char *argv[])
{
    LOGCFG.level = INFO;
    LOGCFG.headers = true;
    char* file = 0;
    int k,i;
    bool d;
    double a,b;
    if(!try_get_options(&argc, argv, &file, k, d, i, a, b))
    {
        print_help();
        return -1;
    }
    if(d)
    {
        LOGCFG.level = DEBUG;
    }
    auto corpus = Corpus::create(file);
    LOG(INFO) << "Total vocabulary: " << corpus -> get_num_of_vocabularies();
    LOG(INFO) << "Corpus is ready. Starting LDA process..";
    auto lda = new LDA(corpus, i, k, a, b);
    lda->start();
    LOG(INFO) << "LDA process finished!";
    delete lda;
    //delete corpus;
    return 0;
}
