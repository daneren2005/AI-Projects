using System;
using WumpusWorld.Agents;

namespace WumpusWorld {
	class Program {
		static void Main(string[] args) {
			World world = new World(4, 4);

			world.setElement(2, 2, Element.WUMPUS);
			world.setElement(3, 2, Element.PIT);
			world.setElement(0, 3, Element.HUNTER);
			world.setElement(3, 0, Element.GOLD);
			Console.WriteLine(world);

			Agent agent = new RandomAgent(world.hunter);


			Console.WriteLine("Final score: " + world.hunter.score);
			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}
	}
}
