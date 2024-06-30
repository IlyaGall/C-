
namespace Otus.Console.Interactive
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public static class ColorDemo
	{
		public static void Demo()
		{

			Console.Write("Я обычный текст");

			// Делаем фон красным
			Console.BackgroundColor = ConsoleColor.Red;

			// А текст зеленым
			Console.ForegroundColor = ConsoleColor.Green;

			Console.Write("Ш");
			Console.ResetColor();
			Console.Write("Я продолжение обычный текст");
		
			Console.WriteLine("Я обычный текст");

			// Делаем фон красным
			Console.BackgroundColor = ConsoleColor.Red;

			// А текст зеленым
			Console.ForegroundColor = ConsoleColor.Green;

			Console.WriteLine("А я зеленый на красном");
			Console.ResetColor();

			Console.WriteLine("Я снова в обычном режиме");
		}
	}
}
