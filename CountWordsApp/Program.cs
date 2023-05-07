// See https://aka.ms/new-console-template for more information

public class Application
{
	public static void Main()
	{

		string directory = @"D:\C_sharp_exercises_May_2023\Ex_1_Texts";
		string searchPattern = "*.txt";
		string[] filesDirectories = Directory.GetFiles(directory, searchPattern);
		int countTotal = 0;

		if (filesDirectories.Length > 0)
		{

			foreach (string file in filesDirectories)
			{
				string text = File.ReadAllText(file);
				int countedWords = CountWords(text);
				countTotal += countedWords;
				Console.WriteLine("File: {0}, counted words {1}", file, countedWords);
				Console.WriteLine();

			}

			Console.WriteLine("Total number of words in all files: {0}", countTotal);
		}
		else { Console.WriteLine("There is no text files in given directory"); }
	}

	private static int CountWords(string text)
	{
		string[] words = text.Split(' ');

		return words.Length;
	}
}

