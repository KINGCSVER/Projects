#pragma once
#include <iostream>
#include <fstream>

using namespace std;

struct userData
{
private:
	string name{};
	string surname{};
	string patronomic{};

	int* dayOfBirth{};
	int* monthOfBirth{};
	int* yearOfBirth{};

public:
	userData();

	userData(const userData& other);

	userData(string&, string&, string&, int&, int&, int&);

	friend ostream& operator <<(ostream& os, const userData personalData)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< personalData.name << endl
				<< personalData.surname << endl
				<< personalData.patronomic << endl
				<< *personalData.dayOfBirth << endl
				<< *personalData.monthOfBirth << endl
				<< *personalData.yearOfBirth << endl;

			return os;
		}

		os
			<< "Owner name: " << personalData.name << endl
			<< "Owner surname: " << personalData.surname << endl
			<< "Owner patronomic: " << personalData.patronomic << endl
			<< "Owner date of birth: " << *personalData.dayOfBirth << '.' << *personalData.monthOfBirth << '.' << *personalData.yearOfBirth << endl;

		return os;
	}

	friend istream& operator>>(istream& is, userData& personalData)
	{
		is >> personalData.name >> personalData.surname >> personalData.patronomic >> *personalData.dayOfBirth >> *personalData.monthOfBirth >> *personalData.yearOfBirth;

		return is;
	}

	string getName() const;
	string getSurname() const;
	string getPatronomic() const;

	int getDayOfBirth() const;
	int getMonthOfBirth() const;
	int getYearOfBirth() const;

	~userData();
};