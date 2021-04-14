
#include <iostream>
#include <string>
#include <sstream>
#include <iomanip>
using namespace std;

class Zaman
{
private:
	int _saat;
	int _dakika;
	int _saniye;

public: void ZamanAyarla(int saat, int dakika, int saniye)
{
	if (saat > 23 || dakika > 59 || saniye > 99)
		throw ("geçersiz saat");

	this->_saat = saat;
	this->_dakika = dakika;
	this->_saniye = saniye;
}

public:
	void Increment()
	{
		if (this->_saniye < 59)
		{
			//eðer saniye 59'dan küçükse ne güzel
			_saniye++;
		}
		else
		{
			//deðilse saniyeyi 0 yap
			_saniye = 0;

			//ve dakikayý 1 arttýr			
			if (this->_dakika < 59)
			{
				//eðer dakika 59'dan küçükse ne güzel
				this->_dakika++;
			}
			else
			{
				//deðilse dakikayý 0 yap
				this->_dakika = 0;

				//ve saati 1 arttýr 
				if (this->_saat < 23)
				{
					//Saat 23'den küçükse ne güzel
					this->_saat++;
				}
				else
				{
					//deðilse saati 0 yap
					this->_saat = 0;
				}
			}
		}


	}

private: string BasaSifirKoy(int i)
{
	string str = std::to_string(i);
	if (str.length() < 2)
		str = "0" + str;
	return str;

}
public:
	void Display(int tip)
	{
		string saatAsStr = BasaSifirKoy(this->_saat);
		string dakikaAsStr = BasaSifirKoy(this->_dakika);		
		string saniyeAsStr = BasaSifirKoy(this->_saniye);
		cout << "\n" + saatAsStr + ":" + dakikaAsStr + ":" + saniyeAsStr;
	}
};

int main() {

	Zaman z;
	z.ZamanAyarla(23, 59, 58);
	z.Increment();
	z.Display(1);
	z.Increment();
	z.Display(1);

}
#include<iostream>


