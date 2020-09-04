#include <iostream>
#include <ctime>
#include <Windows.h>
#define SIZE 15
using namespace std;

void bubleSort(int* Array, int size)
{
    for (int i = 0; i < size - 1; ++i)
    {
        for (int j = i + 1; j < size; j++)
        {
            if (Array[j] < Array[i])
            {
                int buf = Array[i];
                Array[i] = Array[j];
                Array[j] = buf;
            }
        }
    }
}
void quickSort(int* Array, int begin, int end)
{
    if ((end - begin) < 2)
    {
        if (Array[end] < Array[begin])
        {
            int buf = Array[begin];
            Array[begin] = Array[end];
            Array[end] = buf;
        }
    }
    else
    {
        int index = begin;
        for (int i = begin + 1; i <= end; ++i)
        {
            if (Array[i] < Array[index])
            {
                int buf = Array[index];
                Array[index] = Array[i];
                Array[i] = buf;
                index = i;
            }
        }
        if (index == begin)index++;
        quickSort(Array, begin, index);
        quickSort(Array, index, end);
    }
}

void dopWork1()
{
    srand(time(NULL));
    int arraySize;
    cout << "Введите размер массива:" << endl;
    cin >> arraySize;
    int* arr = new int[arraySize];
    bool countFlag;
    for (int i = 0; i < arraySize;)
    {
        countFlag = false;
        int newValue = 1 + rand() % 120;
        for (int j = 0; j < i; ++j)
        {
            if (arr[j] == newValue) 
            {
                countFlag = true;
                break; 
            }
        }
        if (!countFlag)
        {
            arr[i] = newValue;
            ++i;
        }
    }
    bubleSort(arr, arraySize);
    for (int i = 0; i < arraySize; ++i)
    {
        cout << arr[i] << " ";
    }
    cout << endl << "Максимальный элемент:" << arr[arraySize - 1] << endl;
    cout << "Минимальный элемент:" << arr[0] << endl;
}
void dopWork2()
{
    srand(time(NULL));
    int arr[10];
    for (int i = 0; i < 10; ++i)
    {
        arr[i] = 1 + rand() % 50;
    }
    for (int i = 0; i < 10; ++i)cout << arr[i] << " ";
    cout << endl;
    quickSort(arr, 0, 3);
    for (int i = 5; i < 9; ++i)
    {
        for (int j = i + 1; j < 10; j++)
        {
            if (arr[j] > arr[i])
            {
                int buf = arr[i];
                arr[i] = arr[j];
                arr[j] = buf;
            }
        }
    }
    for (int i = 0; i < 10; ++i)cout << arr[i] << " ";

}
void dopWork3()
{
    srand(time(NULL));
    int arr[SIZE];
    int size = SIZE;
    for (int i = 0; i < size; ++i)arr[i] = -5 + rand() % 10;
    for (int i = 0; i < size; ++i)cout << arr[i] << " ";
    for (int i = 0; i < size;i++)
    {
        for (int j = i + 1; j < size; j++)
        {
            if (arr[i] == arr[j]) {
                int t = 1;
                while (arr[j] == arr[size - t])
                {
                    t++;
                }
                arr[j] = arr[size - t];
                size -= t;
            }
            
        }
    }
    
    cout << endl;
    for (int i = 0; i < size; ++i)cout << arr[i] << " ";
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    //dopWork1();
    //dopWork2();
    dopWork3();
    return 0;
}

