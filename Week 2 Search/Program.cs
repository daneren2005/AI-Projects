using System;
using System.Diagnostics;
using System.Linq;

namespace AI_Project_Week_2___Search {
	class Program {
		// 1,2,5,3,4,0,6,7,8 should take 3 steps: up, left, left
		// 1,2,5,6,3,8,4,7,0 should take 10 steps: left, left, up, right, down, right, up, up, left, left
		// 1,2,5,6,3,0,8,4,7 should take 13 steps: down, left, left, up, right, right, down, left, up, right, up, left, left
		// 1,2,5,0,6,3,8,4,7 should take 15 steps: right, right, down, left, left, up, right, right, down, left, up, right, up, left, left
		// 2,5,0,1,6,3,8,4,7 should take 18 steps: left, left, down, right, right, down, left, left, up, right, right, down, left, up, right, up, left, left
		// 2,5,3,1,0,6,8,4,7 should take 20 steps:  right, up, left, left, down, right, right, down, left, left, up, right, right, down, left, up, right, up, left, left
		// 7,2,4,5,0,6,8,3,1 should take 26 steps: left, up, right, down, right, down, left, left, up, right, right, down, left, left, up, right, right, up, left, left, down, right, right, up, left, left

		static void Main(string[] args) {
			Console.WriteLine("Enter algorithm");
			string algorithm = Console.ReadLine();

			Console.WriteLine("Enter Initial State");
			BoardState initialState = new BoardState(Console.ReadLine());
			BoardState goalState = new BoardState("0,1,2,3,4,5,6,7,8");

			Console.WriteLine("Start state: " + initialState);
			Console.WriteLine("Goal: " + goalState);

			Path path = null;
			IPathFinder search = null;
			if(algorithm == "bfs") {
				search = new BreadthFirstSearch(initialState);
			} else if(algorithm == "dfs") {
				search = new DepthFirstSearch(initialState);
			} else if(algorithm == "astar") {
				search = new AStarSearch(initialState);
			}

			Stopwatch sw = new Stopwatch();
			sw.Start();
			path = search.search(goalState);
			sw.Stop();

			Console.WriteLine("Path: " + string.Join(", ", path.actions));
			Console.WriteLine("Cost: " + path.nodes.Count);
			Console.WriteLine("Node expanded: " + path.nodesExpanded);
			Console.WriteLine("Elapsed: " + sw.Elapsed);

			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}
	}
}
