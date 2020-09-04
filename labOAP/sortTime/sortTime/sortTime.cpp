#include <iostream>
#include <ctime>
#include <chrono>
#include <Windows.h>
using namespace std;

//int lengthArray(int* Array)
//{
//    return sizeof(Array) / sizeof(Array[0]);
//}
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
        for (int i = begin+1; i <= end; ++i)
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
        quickSort(Array,begin,index);
        quickSort(Array,index,end);
    }
}
void bubleSort(int* Array, int size)
{
    for (int i=0;i<size-1;++i)
    {
        for (int j=i+1;j<size;j++)
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
void countSort(int* Array, int size)
{
    int* number = new int[size];
    for (int i = 0; i < size; ++i)
    {
        int value = 0;
        for (int j = 0; j < size; ++j)
        {
            if (Array[j] < Array[i])value++;
        }
        number[i] = value;
    }
    for (int i = 0; i < size-1; ++i)
    {
        bool flag = false;
        for (int j = i + 1; j < size; ++j)
        {
            if (number[j] == number[i])
            {
                flag = true;
                break;
            }
        }
        if (flag)number[i]++;
    }
    int* resultArr = new int[size];
    for (int i = 0; i < size; ++i)
    {
        resultArr[number[i]] = Array[i];
    }
    for (int i = 0; i < size; ++i)Array[i] = resultArr[i];
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    srand(time(NULL));
    int size;
    cout << "Введите длину массива:";
    cin >> size;
    int* Array = new int[size];
    for (int i = 0; i < size; ++i)Array[i] = 1 + rand() % 1000;

    cout << "Иcследвание:" << endl;
    printf("1 - Иcследование сортировки пузырьком\n");
    printf("2 - Иcследование сортировки подстановкой\n");
    printf("3 - Исcледование сортировки Хоара\n");
    printf("0 - выйти из программы\n");
    cout << "Введине номер команды!\n";
    int value;
    cin >> value;
    
    if (value == 0) {
        return 0;
    }
    else if (value == 1) {
        auto begin = std::chrono::steady_clock::now();
        bubleSort(Array, size);
        auto end = std::chrono::steady_clock::now();

        auto elapsed_ms = std::chrono::duration_cast<std::chrono::milliseconds>(end - begin);
        cout << "Время затраченое на сортировку:" << elapsed_ms.count() << " ms\n";
    }
    else if (value == 2)
    {
        auto begin = std::chrono::steady_clock::now();
        countSort(Array, size);
        auto end = std::chrono::steady_clock::now();

        auto elapsed_ms = std::chrono::duration_cast<std::chrono::milliseconds>(end - begin);
        cout << "Время затраченое на сортировку:" << elapsed_ms.count() << " ms\n";
    }
    else if (value == 3)
    {
        auto begin = std::chrono::steady_clock::now();
        quickSort(Array, 0, size - 1);
        auto end = std::chrono::steady_clock::now();

        auto elapsed_ms = std::chrono::duration_cast<std::chrono::milliseconds>(end - begin);
        cout << "Время затраченое на сортировку:" << elapsed_ms.count() << " ms\n";
    }
    else cout << "Введена не корректная команда!\n";
        
}

