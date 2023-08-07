#include "Card.h"

Card::Card()
{
	this->useRData = new userData{};
	this->CVV = new int{};
	this->dateExpiry = new dateOfExpiration{};
	this->balance = new Balance{};
}

Card::Card(const Card& other)
{
	this->useRData = new userData(*other.useRData);
	this->cardNumber = other.cardNumber;
	this->CVV = new int(*other.CVV);
	this->dateExpiry = new dateOfExpiration(*other.dateExpiry);
	this->balance = new Balance(*other.balance);
}

Card::Card(userData& ownerData, string& cardNumber, int& CVV, Balance& balance, dateOfExpiration& dataOfExpiry)
{
	this->useRData = new userData(ownerData);
	this->cardNumber = cardNumber;
	this->CVV = new int{ CVV };
	this->dateExpiry = new dateOfExpiration(dataOfExpiry);
	this->balance = new Balance{ balance };
}

string Card::getCardNumber() const
{
	return this->cardNumber;
}

int Card::getCVV() const
{
	return *this->CVV;
}

Balance Card::getBalance() const
{
	return *this->balance;
}