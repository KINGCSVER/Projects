#include "Transaction.h"

Transaction::Transaction()
{
	this->sendDay = new int{};
	this->sendMonth = new int{};
	this->sendYear = new int{};
	this->sendAmount = new Balance{};
	this->category = new int{};
}

Transaction::Transaction(const Transaction& other)
{
	this->senderID = other.senderID;
	this->recipientID = other.recipientID;
	this->sendDay = new int{ *other.sendDay };
	this->sendMonth = new int{ *other.sendMonth };
	this->sendYear = new int{ *other.sendYear };
	this->sendAmount = new Balance{ *other.sendAmount };
	this->category = new int{ *other.category };
}

Transaction::Transaction(string& senderID, string& recipientID, int& sendDay, int& sendMonth, int& sendYear,
	Balance& sendAmount, int& category)
{
	this->senderID = senderID;
	this->recipientID = recipientID;
	this->sendDay = new int{ sendDay };
	this->sendMonth = new int{ sendMonth };
	this->sendYear = new int{ sendYear };
	this->sendAmount = new Balance{ sendAmount };
	this->category = new int{ category };
}

string Transaction::getSenderID() const
{
	return this->senderID;
}

string Transaction::getRecipientID() const
{
	return this->recipientID;
}

int Transaction::getSendDay() const
{
	return *this->sendDay;
}

int Transaction::getSendMonth() const
{
	return *this->sendMonth;
}

int Transaction::getSendYear() const
{
	return *this->sendYear;
}

int Transaction::getCategory() const
{
	return *this->category;
}

Balance* Transaction::getSendAmount() const
{
	return this->sendAmount;
}