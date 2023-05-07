using System.Runtime.CompilerServices;

public class Friend
{
	public string Name { get; set; }
	public DateOnly BirthDate { get; set; }
}

public class Application
{
	static List<Friend> MyFriends = new List<Friend>();
	public static void Main()
	{
		bool isQuite = false;

		while (!isQuite)
		{
			Console.WriteLine("Press A to add new friend's birthday date\nPress E to edit friend's birthday date\nPress D to delete friend\nPress L to see friends list\nPress Q to quite");
			ConsoleKeyInfo key = Console.ReadKey();
			switch (key.KeyChar)
			{
				case 'A':
				case 'a':
					AddNewFriend();
					break;

				case 'L':
				case 'l':
					ListFriends();
					break;

				case 'E':
				case 'e':
					EditFriend();
					break;

				case 'D':
				case 'd':
					DeleteFriend();
					break;

				case 'Q':
				case 'q':
					isQuite = true;
					break;

			}
		}
	}

	private static void DeleteFriend()
	{
		ListFriends();
		Console.WriteLine("Select friend id");

		bool isOk = false;

		while (!isOk)
		{

			try
			{
				int id = int.Parse(Console.ReadLine());
				if (id < 0 || id > MyFriends.Count)
				{
					isOk = false;
				}
				else
				{
					MyFriends.RemoveAt(id);
					isOk = true;
				}
			}
			catch { isOk = false; };


		}
	}

	private static void EditFriend()
	{
		ListFriends();
		Console.WriteLine("Select friend id");
		
		bool isOk = false;

		while (!isOk)
		{

			try
			{
				int id = int.Parse(Console.ReadLine());
				if (id < 0 || id > MyFriends.Count)
				{
					isOk = false;
				}
				else
				{
					Friend friend = ReadFriend();

					MyFriends[id] = friend;
					isOk = true;
				}
			}
			catch { isOk = false; };

		
		}
	}

	private static void ListFriends()
	{
		int id = 0;
		foreach (Friend friend in MyFriends)
		{
			Console.WriteLine("Id: {2}, Name: {0}, Birthday: {1}", friend.Name, friend.BirthDate, id);
			id++;
		}
	}

	private static Friend ReadFriend()
	{
		bool isCorrectFormat = false;
		Friend friend = new Friend();
		while (!isCorrectFormat)
		{
			Console.WriteLine("Add friend's name");
			friend.Name = Console.ReadLine();

			try
			{
				Console.WriteLine("Add birthday calendar day as number");
				int day = Int32.Parse(Console.ReadLine());

				Console.WriteLine("Select month by pressing number from 1 to 12");
				int month = Int32.Parse(Console.ReadLine());

				Console.WriteLine("Add birthday year");
				int year = Int32.Parse(Console.ReadLine());

				friend.BirthDate = new DateOnly(year, month, day);
				isCorrectFormat = true;
			}
			catch
			{
				Console.WriteLine("Incorrect format. Please, add birthday as a number");
				isCorrectFormat = false;
			}
		}

		return friend;
	}

	private static void AddNewFriend()
	{
		Friend friend = ReadFriend();
		MyFriends.Add(friend);
	}


}
