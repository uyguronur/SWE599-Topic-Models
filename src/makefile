CC = g++ -std=c++11 -Wall

LSOURCE = main.cpp document.cpp corpus.cpp lda.cpp utils.cpp
LHEADER = word.h document.h logger.h corpus.h lda.h utils.h

mac: $(LSOURCE) $(HEADER)
	  $(CC) $(LSOURCE) -o main.out

mac-d: $(LSOURCE) $(HEADER)
	  $(CC) -g $(LSOURCE) -o main.out

linux: $(LSOURCE) $(HEADER)
	  $(CC) $(LSOURCE) -o main.out

linux-d: $(LSOURCE) $(HEADER)
	  $(CC) -g $(LSOURCE) -o main.out


clean:
	-rm hdp