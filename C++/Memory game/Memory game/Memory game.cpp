#include <iostream>
#include <Windows.h>
using namespace std;

void getClick(int& x, int& y)
{
	HANDLE hConsoleIn = GetStdHandle(STD_INPUT_HANDLE);
	INPUT_RECORD inputRec;
	DWORD events;
	COORD coord;
	bool clicked = false;

	DWORD fdwMode = ENABLE_EXTENDED_FLAGS | ENABLE_WINDOW_INPUT | ENABLE_MOUSE_INPUT;
	SetConsoleMode(hConsoleIn, fdwMode);

	while (!clicked) {

		ReadConsoleInput(hConsoleIn, &inputRec, 1, &events);

		if (inputRec.EventType == MOUSE_EVENT) {
			if (inputRec.Event.MouseEvent.dwButtonState == FROM_LEFT_1ST_BUTTON_PRESSED) {
				coord = inputRec.Event.MouseEvent.dwMousePosition;
				x = coord.X;
				y = coord.Y;
				clicked = true;
			}
		}
		if (GetAsyncKeyState(VK_ESCAPE)) {
			cout << "Exiting" << endl;
			break;
		}
		else if (inputRec.EventType == KEY_EVENT) {
		}
	}
}

void printField(int* field, int* numbers, int size, int choice, int& count)
{
	system("cls");

	for (int i = 0; i < size; i++)
	{
		if (choice == numbers[i])
		{
			if (field[i] != 111)
			{
				cout << "\t" << field[i];
				count = i;
			}
			else
			{
				cout << "\t ";
			}
		}
		else
		{
			if (field[i] != 111)
			{
				cout << "\t* ";
			}
			else 
			{
				cout << "\t ";
			}
		}

		if ((i + 1) % 4 == 0)
		{
			cout << endl;
		}
	}
}


int main()
{
	int* field{};
	int x{}, y{};

	cout
		<< "Enter Field size: " << endl
		<< "1. 4X4" << endl
		<< "2. 8X4" << endl;

	getClick(x, y);

	while (y < 1 && y > 3 || x > 5)
	{
		system("cls");

		cout
			<< "Enter Field size: " << endl
			<< "1. 4X4" << endl
			<< "2. 8X4" << endl;

		cout << "Invalid input, re-enter: " << endl;

		getClick(x, y);
	}

	while (y != 1 && y != 2)
	{
		getClick(x, y);
	}
	
	int size{};

	if (y == 1) 
	{
		size = 16;
	}
	else if (y == 2) 
	{
		size = 32;
	}

	field = new int[size] {};
	int* count = new int[size] {};
	int num{};

	srand(time(0));

	for (int i = 0; i < size; i++)
	{
		num = rand() % (size / 2) + 1;

		if (count[num - 1] < 2)
		{
			field[i] = num;
			count[num - 1]++;
		}
		else
		{
			i--;
		}
	}

	int* coordinates = new int[33]{ 80, 160, 240, 320, 81, 161, 241, 321, 82, 162, 242, 322, 83, 163, 243, 323, 84, 164, 244, 324, 85, 165, 245, 325, 86, 166, 246, 326, 87, 167, 247, 327 };
	int endTimeOfGame = time(0), move{};
	bool stop = true;

	while (stop)
	{
		system("cls");

		for (int i = 0; i < size; i++)
		{
			if (field[i] != 111)
			{
				cout << "\t* ";
			}
			else 
			{
				cout << "\t ";
			}

			if ((i + 1) % 4 == 0)
			{
				cout << endl;
			}
		}

		int choice16{}, choice32{}, first = 50, second = 50;
		int input{};

		while (input == 0)
		{
			getClick(x, y);

			choice16 = (x *= 10) + y;

			for (int i = 0; coordinates[i] != 0; i++)
			{
				if (choice16 == coordinates[i])
				{
					input++;
					break;
				}
			}
		}

		printField(field, coordinates, size, choice16, first);

		choice32 = choice16;
		input--;

		while (choice32 == choice16)
		{
			while (input == 0)
			{
				getClick(x, y);

				choice32 = (x *= 10) + y;

				for (int i = 0; coordinates[i] != 0; i++)
				{
					if (choice32 == coordinates[i])
					{
						input++;
						break;
					}
				}
			}

			input--;
		}

		printField(field, coordinates, size, choice32, second);

		if (field[second] == field[first])
		{
			field[second] = 111;
			field[first] = 111;
		}

		int size2{};

		for (int i = 0; i < size; i++)
		{
			if (field[i] == 111)
			{
				size2++;
			}
		}

		move++;

		if (size2 == size)
		{
			system("cls");

			cout << "Victory!" << endl;

			stop = false;

			continue;
		}

		char* a = new char[1000]{};

		cout << "Enter anything to continue:"; cin >> a;
	}

	endTimeOfGame = time(0) - endTimeOfGame;

	cout << "You did it in " << endTimeOfGame << " seconds." << endl 
	 	 << "In " << move << " moves." << endl;

	return 0;
}