#pragma once
#include "Wallet.h"
#include <sstream>
#include <string>
#include <regex>

namespace functions
{
	template<typename T>
	void saveInFile(T data, string fileName)
	{
		fileName += ".txt";

		ofstream file(fileName, std::ios::app);

		if (file.is_open()) 
		{
			file << data;
		}
		else 
		{
			throw invalid_argument("File not found!");
		}

		file.close();
	}

	template <typename T>
	bool loadFromFile(T**& downloadData, string fileName, int& count)
	{
		fileName += ".txt";

		ifstream file(fileName);

		T data{};

		if (file.is_open())
		{
			for (int i = 0; file >> data; i++)
			{
				downloadData[i] = new T(data);
				count++;
			}

			count--;
		}
		else
		{
			file.close();
			return false;
		}

		file.close();

		return true;
	}

	string checkWallets(wallet** wallet, int& count);

	void formationOfRatings(wallet wallets);
	void top3cost(wallet wallets);
	void top3category(wallet wallets);

	int getCurrentYear();

	void myCheck(string& str, regex regexCheck);

	wallet* addWallet();
	Transaction* addTransaction();
	userData* addPersonalData();
	dateOfExpiration* addDateOfExpiry();
};