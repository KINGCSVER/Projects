#include "Functions.h"

int main()
{
	int walletsCount{};
	wallet** wallets = new wallet * [10] {};

	if (functions::loadFromFile(wallets, "wallets", walletsCount))
	{
		functions::loadFromFile(wallets[0]->cards, "cards", *wallets[0]->cardsCount);
		functions::loadFromFile(wallets[0]->Transactions, "transaction", *wallets[0]->tranasctionCount);
	}

	string choice{}, currentWallet = functions::checkWallets(wallets, walletsCount);

	while (true)
	{
		cout
			<< "1. Add Wallet" << endl
			<< "2. Add card" << endl
			<< "3. Wallet Replenishment" << endl
			<< "4. Card Replenishment" << endl
			<< "5. Add Transaction" << endl
			<< "6. Generating reports" << endl
			<< "7. Formation of ratings by maximum amounts" << endl
			<< "8. Formation of ratings by maximum category" << endl;
		cin >> choice;

		functions::myCheck(choice, regex("[1-8]{1}"));

		switch (stoi(choice))
		{
		case 1:
			wallets[walletsCount] = functions::addWallet();

			functions::saveInFile(*wallets[walletsCount], "wallets");

			walletsCount++;

			system("cls");

			break;
		case 2:
			wallets[stoi(currentWallet)]->addCard();

			functions::saveInFile(*wallets[stoi(currentWallet)]->cards[*wallets[stoi(currentWallet)]->cardsCount - 1], "cards");

			system("cls");

			break;
		case 3:
			wallets[stoi(currentWallet)]->walletReplenishment();

			system("cls");

			break;
		case 4:
			try {
				wallets[stoi(currentWallet)]->cardReplenishment();
			}
			catch (exception& e)
			{
				cout << e.what() << endl;
			}

			system("cls");

			break;
		case 5:
			if (*wallets[stoi(currentWallet)]->tranasctionCount == sizeof(wallets[stoi(currentWallet)]->Transactions) / sizeof(wallets[stoi(currentWallet)]->Transactions[0]))
			{
				Transaction** newCards = new Transaction * [(sizeof(wallets[stoi(currentWallet)]->Transactions) / sizeof(wallets[stoi(currentWallet)]->Transactions[0])) * 2];

				for (int i = 0; i < sizeof(wallets[stoi(currentWallet)]->Transactions) / sizeof(wallets[stoi(currentWallet)]->Transactions[0]); ++i) 
				{
					newCards[i] = wallets[stoi(currentWallet)]->Transactions[i];
				}

				delete[] wallets[stoi(currentWallet)]->Transactions;

				wallets[stoi(currentWallet)]->Transactions = newCards;
			}

			wallets[stoi(currentWallet)]->Transactions[*wallets[stoi(currentWallet)]->tranasctionCount] = functions::addTransaction();

			functions::saveInFile(*wallets[stoi(currentWallet)]->Transactions[*wallets[stoi(currentWallet)]->tranasctionCount], "transaction");

			(*wallets[stoi(currentWallet)]->tranasctionCount)++;

			system("cls");

			break;
		case 6:
			functions::formationOfRatings(*wallets[stoi(currentWallet)]);

			system("cls");

			break;
		case 7:
			functions::top3cost(*wallets[stoi(currentWallet)]);

			break;
		case 8:
			functions::top3category(*wallets[stoi(currentWallet)]);

			break;
		}
	}

	return 0;
}