using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheSantaClausProblem
{
	class Elf
	{
		public static List<Elf> elves = new List<Elf>();

		public static int elfCount = 0;
		public static Semaphore elfSem = new Semaphore(3,3);
		public static Mutex elfMutex = new Mutex();

		public Elf()
		{
			
		}

		public void Start()
		{
			while (true)
			{
				Console.WriteLine("Elf waiting at door");
				elfMutex.WaitOne();
				Program.m.WaitOne();
				elfCount++;
				if (elfCount == 3)
				{
					Santa.santaSem.Release();
				}
				else
				{
					elfMutex.ReleaseMutex();
				}
				Program.m.ReleaseMutex();
				elfSem.WaitOne();
				getHelp();
				Program.m.WaitOne();
				elfCount--;
				if (elfCount == 0)
				{
					elfMutex.ReleaseMutex();
				}
				Program.m.ReleaseMutex();
			}
		}

		private void getHelp()
		{
			Console.WriteLine("Elf is getting help");
			Thread.Sleep(250);
		}
	}
}
