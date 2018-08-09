using System;
using WumpusWorld.Agents;

namespace WumpusWorld {
	class Program {
		static void Main(string[] args) {
			World world = new World(4, 4);

			world.setElement(2, 2, Element.WUMPUS);
			world.setElement(1, 0, Element.WUMPUS);
			world.setElement(3, 2, Element.PIT);
			world.setElement(0, 3, Element.HUNTER);
			world.setElement(3, 0, Element.GOLD);
			Console.WriteLine(world);

			Hunter hunter = world.hunter;
			Agent agent = getAgent(hunter);
			
			while(hunter.running) {
				Action nextAction = agent.getNextAction();
				hunter.takeAction(nextAction);

				Console.WriteLine("Action: " + nextAction);
				if(!hunter.running) {
					break;
				}

				if(nextAction == Action.GO_FORWARD) {
					if(hunter.feelBreeze()) {
						Console.WriteLine("I feel a breeze at " + hunter.cell);
					}
					if(hunter.smellStench()) {
						Console.WriteLine("I smell something nasty at " + hunter.cell);
					}
				}

				// Console.WriteLine(world);
			}

			if(hunter.health <= 0) {
				Console.WriteLine("Died!");
			}

			Console.WriteLine("Final score: " + world.hunter.score + " (" + hunter.turns + " turns)");
			Console.WriteLine(world);
			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}

		private static Agent getAgent(Hunter hunter) {
			Console.WriteLine("Choose your agent (knowledge, random):");
			String desiredAgent = Console.ReadLine();
			switch(desiredAgent) {
				case "knowledge":
				case "k":
					return new KnowledgeBasedAgent(hunter);
				case "random":
				case "r":
					return new RandomAgent(hunter);
				default:
					return new KnowledgeBasedAgent(hunter);
			}
		}
	}
}
