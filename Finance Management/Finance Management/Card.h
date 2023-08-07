#pragma once
#include "DateOfExpiration.h"
#include "UserData.h"
#include "Transaction.h"

class Card
{
protected:
	string cardNumber{};
	int* CVV{};

public:
	userData* useRData{};
	dateOfExpiration* dateExpiry{};
	Balance* balance{};

	Card();

	Card(const Card& other);

	Card(userData&, string&, int&, Balance&, dateOfExpiration&);

	friend ostream& operator <<(ostream& os, const Card card)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< *card.useRData
				<< card.cardNumber << endl
				<< *card.CVV << endl
				<< *card.dateExpiry
				<< *card.balance << endl;
		}

		os
			<< *card.useRData
			<< "Card number: " << card.cardNumber << endl
			<< "CVV: " << *card.CVV << endl
			<< *card.dateExpiry
			<< "Balance: " << *card.balance << endl;

		return os;
	}

	friend istream& operator>>(istream& is, Card& card)
	{
		is >> *card.useRData >> card.cardNumber >> *card.CVV >> *card.dateExpiry >> *card.balance;

		return is;
	}

	string getCardNumber() const;

	int getCVV() const;

	Balance getBalance() const;
};