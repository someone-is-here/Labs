#include "Header.h"

int Factorial(int num) {
	if (num > 1) {
		return num * Factorial(num - 1);
	}
	return 1;
}
int Power(int num, int pow) {
	int res = 1;
	while (pow--) {
		res *= num;
	}
	return res;
}
int SumValuesInArray(int arr[], int size) {
	int res = 0;
	for (int i = 0; i < size; i++) {
		res += arr[i];
	}
	return res;
}
int MinInArray(int arr[], int size) {
	int min = arr[0];
	for (int i = 0; i < size; i++) {
		if (arr[i] < min) {
			min = arr[i];
		}
	}
	return min;
}
int MaxInArray(int arr[], int size) {
	int max = arr[0];
	for (int i = 0; i < size; i++) {
		if (arr[i] > max) {
			max = arr[i];
		}
	}
	return max;
}
bool IsValueInArray(int arr[], int size, int value) {
	bool res = false;
	for (int i = 0; i < size; i++) {
		if (arr[i] == value) {
			res = true;
			break;
		}
	}
	return res;
}
int FindIndexOfValueInArray(int arr[], int size, int value) {
	int res = -1;
	for (int i = 0; i < size; i++) {
		if (arr[i] == value) {
			res = i;
			break;
		}
	}
	return res;
}