
#include<iostream>

using namespace std;
/*
� Random �retilen say�larla b�y�kl��� 20 olan bir dizi olu�turunuz.
� Olu�turdu�unuz diziyi selection sort metoduna g�ndererek i�lem yap�n�z. (sort
algoritmas�n� main fonksiyonun i�ine yazmay�n�z, ilgili metodu �a��r�n�z.)
� Her ge�i�te de�erleri ekrana yazd�r�n�z.
� Yazd���n�z kodun T(n), O(?) de�erlerini hesaplay�p, sonu�lar� yaz�n�z.
� Bu s�ralama algoritmas�n� daha performansl� bir �ekilde nas�l kodlayabilirdik,
yorumlay�n�z? Di�er s�ralama algoritmalar� ile �O- de�eri �zerinden kar��la�t�r�n�z.
*/


void swapping(int& a, int& b) {         //swap the content of a and b
	int temp;
	temp = a;
	a = b;
	b = temp;
}
void display(int* array, int size) {
	for (int i = 0; i < size; i++)
		cout << array[i] << " ";
	cout << endl;
}
void selectionSort(int* array, int size) {
	int i, j, imin;
	for (i = 0; i < size - 1; i++) {
		imin = i;   //get index of minimum data
		for (j = i + 1; j < size; j++)
			if (array[j] < array[imin])
				imin = j;
		//placing in correct position
		swap(array[i], array[imin]);

		//[KUB] Her swaptan sonra array'i g�sterelim		
		display(array, size);
	}
}

int main() {
	/*
	[KUB]
	Bu k�sma gerek yok, soruda zaten size 20  olacak demi�
	int n;
	cout << "Enter the number of elements: ";
	cin >> n;
	*/
	srand(time(0));
	int arr[20];           //create an array with 20 elements
	cout << "Enter elements:" << endl;
	for (int i = 0; i < 20; i++) {
		// cin >> arr[i];
		arr[i] = rand() % 1000;
	}
	cout << "Array before Sorting: ";
	display(arr, 20);
	selectionSort(arr, 20);
	cout << "Array after Sorting: ";
	display(arr, 20);
}

