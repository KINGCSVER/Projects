#include "Functions.h"

wallet::wallet()
{
	this->userDAta = new userData{};
	this->securityCode = new int{};
	this->balance = new Balance{};
}

wallet::wallet(const wallet& _other)
{
	this->userDAta = new userData(*_other.userDAta);
	this->ID = _other.ID;
	this->securityCode = new int(*_other.securityCode);
	this->userEmail = _other.userEmail;
	this->userPhone = _other.userPhone;
	this->balance = new Balance(*_other.balance);
	this->currency = _other.currency;
}

wallet::wallet(userData& tempUserData, string& userEmail, string& userPhone, string& currency,
	string& ID, int& securityCode, Balance& balance)
{
	this->userDAta = new userData(tempUserData);
	this->ID = ID;
	this->securityCode = new int{ securityCode };
	this->userEmail = userEmail;
	this->userPhone = userPhone;
	this->balance = new Balance{ balance };
	this->currency = currency;
}

void wallet::addCard()
{
	string cardNumber{};

	string checkData[2]{};

	userData* person = functions::addPersonalData();

	cout << "Enter card number: " << endl; 
	cin >> cardNumber;

	functions::myCheck(cardNumber, regex("[0-9]{16}"));

	dateOfExpiration* dateOFExpiry = functions::addDateOfExpiry();

	cout << "Enter CVV: " << endl; 
	cin >> checkData[0];

	functions::myCheck(checkData[0], regex("[0-9]{3}"));

	int CVV = stoi(checkData[0]);

	cout << "Enter balance: " << endl; 
	cin >> checkData[1];

	functions::myCheck(checkData[1], regex("[0-9]{1,4}[.]?[0-9]{1,2}"));

	Balance* balance{};

	balance = new Balance{ *balance->checkAmount(checkData[1]) };

	if (*this->cardsCount == sizeof(this->cards) / sizeof(this->cards[0]))
	{
		Card** newCards = new Card * [(sizeof(this->cards) / sizeof(this->cards[0])) * 2];

		for (int i = 0; i < (sizeof(this->cards) / sizeof(this->cards[0])); ++i)
		{
			newCards[i] = cards[i];
		}

		delete[] cards;

		this->cards = newCards;
	}

	this->cards[*this->cardsCount] = new Card(*person, cardNumber, CVV, *balance, *dateOFExpiry);

	(*this->cardsCount)++;
}

void wallet::cardReplenishment()
{
	string choice{};

	if (*this->cardsCount == 0) 
	{
		return;
	}

	for (int i = 0; i < *this->cardsCount; i++) 
	{
		cout << i + 1 << ". " << this->cards[i]->getCardNumber() << endl;
	}

	do {
		cout << "Choice card for replenishment: " << endl;
		cin >> choice;

		functions::myCheck(choice, regex("[0-9]{1,}"));

	} while (stoi(choice) > *this->cardsCount || stoi(choice) <= 0);

	string checkAmount{};

	cout << "Enter amount for replenishment: "; 
	cin >> checkAmount;

	functions::myCheck(checkAmount, regex("[0-9]{1,4}[.]?[0-9]{1,2}"));

	Balance* amount{};

	amount = amount->checkAmount(checkAmount);

	if (*this->cards[stoi(choice)]->balance < *amount) 
	{
		throw invalid_argument("You don't have enough funds!");
	}

	*this->cards[stoi(choice) - 1]->balance += *amount;
}

void wallet::walletReplenishment()
{
	string checkAmount{};

	cout << "Enter amount for replenishment: "; 
	cin >> checkAmount;

	functions::myCheck(checkAmount, regex("[0-9]{1,4}[.]?[0-9]{1,2}"));

	Balance* amount{};

	amount = amount->checkAmount(checkAmount);

	if (*this->balance < *amount) 
	{
		throw invalid_argument("You don't have enough funds!");
	}

	*this->balance += *amount;
}

Balance wallet::getBalance() const
{
	return *this->balance;
}

std::string wallet::getID() const
{
	return this->ID;
}

int wallet::getSecurityCode() const
{
	return *this->securityCode;
}