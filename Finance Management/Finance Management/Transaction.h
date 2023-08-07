#pragma once
#include "Balance.h"

class Transaction
{
private:
	string senderID{};
	string recipientID{};

	int* sendDay{};
	int* sendMonth{};
	int* sendYear{};
	int* category{};

	Balance* sendAmount{};
	
public:
	string categories[8]{ "Food", "Utilities", "Transport", "Health", "Education", "Entertainments", "Clothes", "Communications" };

	Transaction();

	Transaction(const Transaction& other);

	Transaction(string&, string&, int&, int&, int&, Balance&, int&);

	friend ostream& operator << (ostream& os, const Transaction transaction)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< transaction.senderID << endl
				<< transaction.recipientID << endl
				<< *transaction.sendDay << endl
				<< *transaction.sendMonth << endl
				<< *transaction.sendYear << endl
				<< *transaction.sendAmount
				<< *transaction.category << endl;
			return os;
		}
		os
			<< "Sender ID: " << transaction.senderID << endl
			<< "Recipient ID: " << transaction.recipientID << endl
			<< "Date transaction: " << *transaction.sendDay << '.' << *transaction.sendMonth << '.' << *transaction.sendYear << endl
			<< "Send amount: " << *transaction.sendAmount << endl
			<< "Category: " << transaction.categories[*transaction.category - 1] << endl;
		return os;
	}

	friend istream& operator>>(istream& is, Transaction& transaction)
	{
		is >> transaction.senderID >> transaction.recipientID >> *transaction.sendDay >> *transaction.sendMonth >> *transaction.sendYear >>
			*transaction.sendAmount >> *transaction.category;

		return is;
	}

	string getSenderID() const;
	string getRecipientID() const;

	int getSendDay() const;
	int getSendMonth() const;
	int getSendYear() const;
	int getCategory() const;

	Balance* getSendAmount() const;
};
