#include <iostream>
#include <algorithm>
#include <vector>
#include "ConsoleApplication4.h"
using namespace std;
int matric[4][4] =
{
	{0,0,0,0},
	{0,0,0,0},
	{0,0,0,0},
	{0,0,0,0}
};
int t[4][4] =
{
	{0,0,0,0},
	{0,0,0,0},
	{0,0,0,0},
	{0,0,0,0}
};
int mat[16];
void random()
{
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			matric[i][j] = rand() % 101;
			cout << matric[i][j] << "\t";
		}
		cout << "\n";
	}
}
void your()
{
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			int n = 0;
			cin >> n;
			matric[i][j] = n;
			cout << matric[i][j] << "\t";
		}
		cout << "\n";
	}
}
void prost()
{
	int p = 0;
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			bool simple = true;
			for (int z = 2; z < matric[i][j]; z++)
			{
				if (matric[i][j] % z == 0)
				{
					simple = false;
					break;
				}
			}
			if (simple)
			{
				mat[p] = matric[i][j];
				p++;
			}
		}
	}
}
void sort()
{
	for (int i = 0; i < 16; i++)
	{
		for (int j = 0; j < 15; j++) 
		{
			if (mat[j] < mat[j + 1])
			{
				int f = mat[j];
				mat[j] = mat[j + 1];
				mat[j + 1] = f;
			}
		}
	}
	for (int i = 0; i < 16; i++)
	{
		if(mat[i]>0) cout << mat[i] << "\t";
	}
}
int main()
{
	int v;
	srand(time(0));
	setlocale(0, "");
	cout << "1-собственный ввод,2-random\n";
	cin >> v;
	if (v == 2) 
	{
		random();
	}
	if (v == 1)
	{
		your();
	}
	prost();
	cout << "\nотсортированные\n";
	sort();
}