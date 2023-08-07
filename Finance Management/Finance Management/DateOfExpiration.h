#pragma once
#include <iostream>
#include <fstream>

using namespace std;

class dateOfExpiration
{
private:
	int* monthOfExpiry;
	int* yearOFExpiry;
	
public:
	dateOfExpiration();

	dateOfExpiration(const dateOfExpiration& other);

	dateOfExpiration(int&, int&);	

	friend ostream& operator << (ostream& os, dateOfExpiration dateOfExpiry)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< *dateOfExpiry.monthOfExpiry << endl
				<< *dateOfExpiry.yearOFExpiry << endl;
		}

		os << "Date of Expiry: " << *dateOfExpiry.monthOfExpiry << '.' << *dateOfExpiry.yearOFExpiry << endl;

		return os;
	}

	friend istream& operator>>(istream& is, dateOfExpiration& dateOfExpiry)
	{
		is >> *dateOfExpiry.monthOfExpiry >> *dateOfExpiry.yearOFExpiry;

		return is;
	}

	int getMonthOfExpiry() const;
	int getYearOfExpiry() const;

	~dateOfExpiration();
};
