using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheSantaClausProblem
{
	class Santa
	{
		public static Semaphore santaSem = new Semaphore(0, 1);

		public Santa()
		{
			
		}

		public void Start()
		{
			while (true)
			{
				santaSem.WaitOne();
				Program.m.WaitOne();
				if (Reindeer.reindeerCount == 9)
				{
					Reindeer.reindeerCount = 0;
					prepSleigh();
					Reindeer.reindeerSem.Release(9);
				}
				else
				{
					Elf.elfSem.Release(3);
					helpElves();
				}
				Program.m.ReleaseMutex();
			}
		}

		private void helpElves()
		{
			Console.WriteLine("Santa is helping elves");
			Thread.Sleep(250);
		}

		private void prepSleigh()
		{
			Console.WriteLine("Santa is prepping the sleigh");
			Thread.Sleep(250);
		}
	}
}
