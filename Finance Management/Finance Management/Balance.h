#pragma once
#include <iostream>
#include <fstream>

using namespace std;

class Balance
{
private:
	int right{};
	int left{};
	
public:
	Balance();

	Balance(int _left, int _right);

	Balance(const Balance& _other);

	void operator+=(const Balance balance)
	{
		this->left += balance.left;
		this->right += balance.right;

		if (this->right >= 100)
		{
			this->left += 1;
			this->right -= 100;
		}
	}

	void operator -=(const Balance balance)
	{
		this->left -= balance.left;

		if (this->right <= balance.right)
		{
			this->left -= 1;
			this->right += 100;
			this->right = this->right % 100;
		}
	}

	bool operator <(const Balance balance)
	{
		return this->left < balance.left || this->right < balance.right;
	}

	bool operator >(const Balance balance)
	{
		return this->left > balance.left || this->right > balance.right;
	}

	friend ostream& operator<<(ostream& os, const Balance balance)
	{
		if (typeid(os) == typeid(ofstream))
		{
			os
				<< balance.left << std::endl
				<< balance.right << std::endl;

			return os;
		}

		os << balance.left << '.' << balance.right;

		return os;
	}

	friend istream& operator>>(istream& is, Balance& balance)
	{
		is >> balance.left >> balance.right;

		return is;
	}

	Balance* checkAmount(string amount);
};
