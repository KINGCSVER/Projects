#include "DateOfExpiration.h"

dateOfExpiration::dateOfExpiration()
{
	this->monthOfExpiry = new int{};
	this->yearOFExpiry = new int{};
}

dateOfExpiration::dateOfExpiration(const dateOfExpiration& other)
{
	this->monthOfExpiry = new int(*other.monthOfExpiry);
	this->yearOFExpiry = new int(*other.yearOFExpiry);
}

dateOfExpiration::dateOfExpiration(int& monthOfExpiry, int& yearOfExpiry)
{
	this->monthOfExpiry = new int{ monthOfExpiry };
	this->yearOFExpiry = new int{ yearOfExpiry };
}

int dateOfExpiration::getMonthOfExpiry() const
{
	return *this->monthOfExpiry;
}

int dateOfExpiration::getYearOfExpiry() const
{
	return *this->yearOFExpiry;
}

dateOfExpiration::~dateOfExpiration()
{
	delete this->monthOfExpiry;
	delete this->yearOFExpiry;
}