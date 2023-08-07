#pragma once
#include "Card.h"

class wallet
{
private:
	int* securityCode{};
	string ID{};
	Balance* balance{};

public:
	int* cardsCount = new int{};
	int* dailySpendingLimit{};
	int* tranasctionCount = new int{ 50 };

	string userEmail{};
	string userPhone{};
	string currency{};

	Card** cards = new Card * [10];
	userData* userDAta{};
	Transaction** Transactions = new Transaction * [50] {};
	
	wallet();

	wallet(const wallet& _other);

	wallet(userData&, string&, string&, string&, string&, int&, Balance&);

	friend ostream& operator << (ostream& os, const wallet wallet)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< *wallet.userDAta << endl
				<< wallet.userEmail << endl
				<< wallet.userPhone << endl
				<< wallet.ID << endl
				<< *wallet.securityCode << endl
				<< wallet.currency << endl
				<< *wallet.balance << endl;

			for (int i = 0; i < *wallet.cardsCount; i++)
			{
				os << wallet.cards[i]->getCardNumber();
			}

			return os;
		}

		os
			<< *wallet.userDAta
			<< "Owner email: " << wallet.userEmail << endl
			<< "Owner phone: " << wallet.userPhone << endl
			<< "Wallet ID: " << wallet.ID << endl
			<< "Wallet security code: " << *wallet.securityCode << endl
			<< "Wallet currency: " << wallet.currency << endl
			<< "Balance: " << *wallet.balance << endl
			<< "Cards in wallet: " << endl;

		for (int i = 0; i < *wallet.cardsCount; i++)
		{
			os << "Card number: " << wallet.cards[i]->getCardNumber();
		}

		return os;
	}

	friend istream& operator>>(istream& is, wallet& wallet)
	{
		is >> *wallet.userDAta >> wallet.userEmail >> wallet.userPhone >> wallet.ID >> *wallet.securityCode >> wallet.currency >> *wallet.balance;

		return is;
	}

	void addCard();
	void cardReplenishment();
	void walletReplenishment();

	Balance getBalance() const;

	string getID() const;

	int getSecurityCode() const;
};