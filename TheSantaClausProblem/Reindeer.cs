using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheSantaClausProblem
{
	public class Reindeer
	{
		public static List<Reindeer> reindeer = new List<Reindeer>();

		public static int reindeerCount = 0;
		public static Semaphore reindeerSem = new Semaphore(9, 9);
		public Reindeer()
		{
			
		}

		public void Start()
		{
			while (true)
			{
				Console.WriteLine("A reindeer arrives");
				Program.m.WaitOne();
				reindeerCount++;
				if (reindeerCount == 9)
				{
					Santa.santaSem.Release();
				}
				Program.m.ReleaseMutex();
				reindeerSem.WaitOne();
				getHitched();
			}
		}

		private void getHitched()
		{
			Console.WriteLine("Reindeer is getting hitched");
			Thread.Sleep(250);
		}
	}
}
