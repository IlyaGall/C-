

namespace Otus.Answer
{
	using System;
	class Program
	{

		#region 4 задание



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
				Console.SetCursorPosition(0, selectedValue);
				Console.Write(' ');
				selectedValue++;
				Console.SetCursorPosition(0, selectedValue);
				Console.Write('>');
			}
		}

		/// <summary>
		/// На одну строку вверх
		/// </summary>
		private static void SetUp()
		{


			if (selectedValue > 0)
			{
				Console.SetCursorPosition(0, selectedValue);
				Console.Write(' ');
				selectedValue--;
				Console.SetCursorPosition(0, selectedValue);
				Console.Write('>');
			}
		}

		/// <summary>
		/// Вывести меню
		/// </summary>
		private static void PrintMenu()
		{

			for (var i = 0; i < options.Length; i++)
			{
				Console.WriteLine($"{(selectedValue == i ? ">" : " ")} {i + 1}. {options[i]}");
			}
			Console.WriteLine("Для выхода нажмие Escape");
		}

		/// <summary>
		/// Исходное положение стрелки меню
		/// </summary>
		private static int selectedValue = 0;



		/// <summary>
		/// Запуск меню
		/// </summary>
		private static void Start()
		{
			ConsoleKeyInfo ki;
			PrintMenu();
			Console.SetCursorPosition(0, 0);
			do
			{


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

			} while (ki.Key != ConsoleKey.Escape);

		}

		#endregion


		static void Task3()
		{
			ConsoleKey? key;

			var capitalized = string.Empty;
			var normal = string.Empty;

			do
			{
				Console.WriteLine($"С большой буквы: {capitalized }");
				Console.Write($"Обычный текст: {normal}");

				var ki = Console.ReadKey();
				key = ki.Key;

				capitalized += char.ToUpper(ki.KeyChar);
				normal += ki.KeyChar;
				Console.Clear();
			} while (key != ConsoleKey.Escape);
		}


		static void Task2()
		{
			Console.Write("Введите первое число: ");
			var s1 = Console.ReadLine();
			var i1 = int.Parse(s1);

			Console.Write("Введите второе число: ");
			var s2 = Console.ReadLine();
			var i2 = int.Parse(s2);

			Console.WriteLine($"Результат сложения: {i1} + {i2} = {i1 + i2}");
		}



		static void Main(string[] args)
		{
			Task3();

			//
			var s = @"
введите размерность таблицы: U
введите размерность таблицы: 1.4
введите размерность таблицы: 3
введите произвольный текст: 
введите произвольный текст: Текст
+++++++++++
+         +
+         +
+  Текст  +
+         +
+         +
+++++++++++
+ + + + + +
++ + + + ++
+ + + + + +
++ + + + ++
+ + + + + +
+++++++++++
++       ++
+ +     + +
+  +   +  +
+   + +   +
+    +    +
+   + +   +
+  +   +  +
+ +     + +
++       ++
+++++++++++";
			Console.WriteLine(s);
		}
	}
}
 