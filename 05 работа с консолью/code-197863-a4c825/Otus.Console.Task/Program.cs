
namespace Otus.Console.Task
{
	using System;

	class Program
	{
		static void Main(string[] args)
		{
			//Task1();
			//Task2();
			//Task3();
			//Task4();

		}





		/// <summary>
		/// Задание 1
		/// </summary>
		static void Task1()
		{
			var line = CustomReadLine();
			Console.WriteLine($"Ваша строка: {line}");
		}



		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		static string CustomReadLine()
		{
			var res = string.Empty;

			// Вот тут начинается ваш код





			return res;
		}

		/// <summary>
		/// Задание 2
		/// </summary>
		static void Task2()
		{

		}





		/// <summary>
		/// Задание 3
		/// </summary>
		/// <param name="s"></param>
		static void Task3()
		{

			var line = Console.ReadLine();


			// А дальше - код
		}



		/// <summary>
		/// Задание 4
		/// </summary>
		static void Task4()
		{

			Console.Clear();

			Start();
		}






















		/// <summary>
		/// Опции меню
		/// </summary>
		private static string[] options = new[]{
			"Новая игра",
			"Загрузить игру",
			"Сохранить Игру",
			"Настройки",
		};

		/// <summary>
		/// На одну строку вниз
		/// </summary>
		private static void SetDown()
		{
			if (selectedValue < options.Length - 1)
			{
				selectedValue++;
			}
		}

		/// <summary>
		/// На одну строку вверх
		/// </summary>
		private static void SetUp()
		{
			if (selectedValue > 0)
				selectedValue--;
		}

		/// <summary>
		/// Вывести меню (его трогать не нужно)
		/// </summary>
		private static void PrintMenu()
		{
			Console.WriteLine("Для выхода нажмие Escape");
			for (var i = 0; i < options.Length; i++)
			{
				Console.WriteLine($"{(selectedValue == i ? ">" : " ")} {i + 1}. {options[i]}");
			}
		}

		/// <summary>
		/// Исходное положение стрелки меню
		/// </summary>
		private static int selectedValue = 0;



		/// <summary>
		/// Запуск меню (его трогать не нужно)
		/// </summary>
		private static void Start()
		{
			Console.Clear();
			ConsoleKeyInfo ki;
			do
			{
				PrintMenu();

				ki = Console.ReadKey();


				switch (ki.Key)
				{
					case ConsoleKey.UpArrow:
						SetUp();
						break;
					case ConsoleKey.DownArrow:
						SetDown();
						break;
				}
				Console.Clear();
			} while (ki.Key != ConsoleKey.Escape);

		}




	}
}

