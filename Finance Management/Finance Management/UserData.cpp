#include "UserData.h"

userData::userData()
{
	this->dayOfBirth = new int{};
	this->monthOfBirth = new int{};
	this->yearOfBirth = new int{};
}

userData::userData(const userData& other)
{
	this->name = other.name;
	this->surname = other.surname;
	this->patronomic = other.patronomic;
	this->dayOfBirth = new int(*other.dayOfBirth);
	this->monthOfBirth = new int(*other.monthOfBirth);
	this->yearOfBirth = new int(*other.yearOfBirth);
}

userData::userData(string& name, string& surname, string& patronomic,
	int& dayOfBirth, int& monthOfBirth, int& yearOfBirth)
{
	this->name = name;
	this->surname = surname;
	this->patronomic = patronomic;
	this->dayOfBirth = new int{ dayOfBirth };
	this->monthOfBirth = new int{ monthOfBirth };
	this->yearOfBirth = new int{ yearOfBirth };
}

string userData::getName() const
{
	return this->name;
}

string userData::getSurname() const
{
	return this->surname;
}

string userData::getPatronomic() const
{
	return this->patronomic;
}

int userData::getDayOfBirth() const
{
	return *this->dayOfBirth;
}

int userData::getMonthOfBirth() const
{
	return *this->monthOfBirth;
}

int userData::getYearOfBirth() const
{
	return *this->yearOfBirth;
}

userData::~userData()
{
	delete this->dayOfBirth;
	delete this->monthOfBirth;
	delete this->yearOfBirth;
}