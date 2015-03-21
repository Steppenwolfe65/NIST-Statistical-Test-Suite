// mods: john underhill July 17, 2014.. 
// thanks to the original authors for a very interesting app.. extremely well done
// basic rewrite: turned console into a class library, remmed fprints, added exports, this class, prototypes, and a couple of default methods in utilities.c
// invalid state or error return -1 for all calls, otherwise, returns the p-value. caller compare p-value > ALPHA (0.01) for PASS/FAIL
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <string.h>
#include <time.h> 
#include "../include/externs.h"
#include "../include/generators.h"
#include "../include/stat_fncs.h"
#include "../include/utilities.h"
#include "nist.h"

#define DLL_EXPORT extern __declspec(dllexport)

	DLL_EXPORT int NistLoadFile(char* streamFile, int Size)
	{
		if (streamFile == NULL)
			return -1;

		tp.n = Size;
		tp.blockFrequencyBlockLength = 128;
		tp.nonOverlappingTemplateBlockLength = 9;
		tp.overlappingTemplateBlockLength = 9;
		tp.approximateEntropyBlockLength = 10;
		tp.serialBlockLength = 16;
		tp.linearComplexitySequenceLength = 500;
		tp.numOfBitStreams = 1;

		return loadFileStream(streamFile);
	}

    DLL_EXPORT double NistFrequency()
	{
		return Frequency(tp.n);
	}

	DLL_EXPORT double NistBlockFrequency(int M)
	{
		return BlockFrequency(M, tp.n);
	}

	DLL_EXPORT double NistCumulativeSums()
	{
		return CumulativeSums(tp.n);
	}

	DLL_EXPORT double NistRuns()
	{
		return Runs(tp.n);
	}

	DLL_EXPORT double NistLongestRunOfOnes()
	{
		return LongestRunOfOnes(tp.n);
	}

	DLL_EXPORT double NistRank()
	{
		return Rank(tp.n);
	}

	DLL_EXPORT double NistDiscreteFourierTransform()
	{
		return DiscreteFourierTransform(tp.n);
	}

	DLL_EXPORT double NistNonOverlappingTemplateMatchings(int M) 
	{
		if (M < 2) M = 2;
		if (M > 16) M = 16;
		// returns mean sum of tests, remember to add templates folder!
		return NonOverlappingTemplateMatchings(M, tp.n); 
	}

	DLL_EXPORT double NistOverlappingTemplateMatchings(int M)
	{
		if (M < 2) M = 2;
		if (M > 16) M = 16;
		return OverlappingTemplateMatchings(M, tp.n);
	}

	DLL_EXPORT double NistUniversal()
	{
		return Universal(tp.n);
	}

	DLL_EXPORT double NistApproximateEntropy(int M)
	{
		return ApproximateEntropy(M, tp.n);
	}

	DLL_EXPORT double NistRandomExcursions()
	{
		return RandomExcursions(tp.n);
	}

	DLL_EXPORT double NistRandomExcursionsVariant()
	{
		return RandomExcursionsVariant(tp.n);
	}

	DLL_EXPORT double NistLinearComplexity(int M)
	{
		return LinearComplexity(M, tp.n);
	}

	DLL_EXPORT double NistSerial(int M)
	{
		return Serial(M, tp.n);
	}

	DLL_EXPORT void NistCleanup()
	{
		cleanResources();
	}

