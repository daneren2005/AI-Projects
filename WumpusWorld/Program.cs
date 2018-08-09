using System;
using WumpusWorld.Agents;

namespace WumpusWorld {
	class Program {
		static void Main(string[] args) {
			World world = new World(4, 4);

			world.setElement(2, 2, Element.WUMPUS);
			world.setElement(3, 2, Element.PIT);
			world.setElement(0, 3, Element.HUNTER);
			world.setElement(0, 0, Element.GOLD);
			Console.WriteLine(world);

			Hunter hunter = world.hunter;
			Agent agent = new RandomAgent(hunter);
			
			while(hunter.running) {
				Action nextAction = agent.getNextAction();
				world.hunter.takeAction(nextAction);

				Console.WriteLine("Action: " + nextAction);
				Console.WriteLine(world);
			}

			if(hunter.health <= 0) {
				Console.WriteLine("Died!");
			}

			Console.WriteLine("Final score: " + world.hunter.score + " (" + hunter.turns + " turns)");
			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}
	}
}
