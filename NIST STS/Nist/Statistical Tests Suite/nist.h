/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
					NIST  F U N C T I O N  P R O T O T Y P E S 
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#define DLL_EXPORT extern __declspec(dllexport)

DLL_EXPORT int NistLoadFile(char*, int);
DLL_EXPORT double NistFrequency();
DLL_EXPORT double NistBlockFrequency(int);
DLL_EXPORT double NistCumulativeSums();
DLL_EXPORT double NistRuns();
DLL_EXPORT double NistLongestRunOfOnes();
DLL_EXPORT double NistRank();
DLL_EXPORT double NistDiscreteFourierTransform();
DLL_EXPORT double NistNonOverlappingTemplateMatchings(int);
DLL_EXPORT double NistOverlappingTemplateMatchings(int);
DLL_EXPORT double NistUniversal();
DLL_EXPORT double NistApproximateEntropy(int);
DLL_EXPORT double NistRandomExcursions();
DLL_EXPORT double NistRandomExcursionsVariant();
DLL_EXPORT double NistLinearComplexity(int);
DLL_EXPORT double NistSerial(int);
DLL_EXPORT void NistCleanup();
