
#include<iostream>

using namespace std;
/*
• Random üretilen sayýlarla büyüklüðü 20 olan bir dizi oluþturunuz.
• Oluþturduðunuz diziyi selection sort metoduna göndererek iþlem yapýnýz. (sort
algoritmasýný main fonksiyonun içine yazmayýnýz, ilgili metodu çaðýrýnýz.)
• Her geçiþte deðerleri ekrana yazdýrýnýz.
• Yazdýðýnýz kodun T(n), O(?) deðerlerini hesaplayýp, sonuçlarý yazýnýz.
• Bu sýralama algoritmasýný daha performanslý bir þekilde nasýl kodlayabilirdik,
yorumlayýnýz? Diðer sýralama algoritmalarý ile –O- deðeri üzerinden karþýlaþtýrýnýz.
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

		//[KUB] Her swaptan sonra array'i gösterelim		
		display(array, size);
	}
}

int main() {
	/*
	[KUB]
	Bu kýsma gerek yok, soruda zaten size 20  olacak demiþ
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

