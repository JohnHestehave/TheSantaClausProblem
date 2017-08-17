using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheSantaClausProblem
{
	class Program
	{
		public static List<Thread> threads = new List<Thread>();

		public static Mutex m = new Mutex();
		public static Random rand = new Random();
		static void Main(string[] args)
		{
			Santa santa = new Santa();
			Thread thread = new Thread(santa.Start);
			thread.Start();
			while (true)
			{
				if(rand.Next(100) > 50)
				{
					Reindeer r = new Reindeer();
					Thread t = new Thread(r.Start);
					t.Start();
					Reindeer.reindeer.Add(r);
				}else
				{
					Elf e = new Elf();
					Thread t = new Thread(e.Start);
					t.Start();
					Elf.elves.Add(e);
				}
				Thread.Sleep(1000);
			}
		}
	}
}
