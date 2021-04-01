#pragma once
//#ifdef HEADERDLL_EXPORTS
extern "C" {
	__declspec(dllimport) int Factorial(int);
	__declspec(dllimport) int Power(int, int);
	__declspec(dllimport) int SumValuesInArray(int[], int);
	__declspec(dllimport) int MinInArray(int[], int);
	__declspec(dllimport) int MaxInArray(int[], int);
	__declspec(dllimport) bool IsValueInArray(int[], int, int);
	__declspec(dllimport) int FindIndexOfValueInArray(int[], int, int);
}