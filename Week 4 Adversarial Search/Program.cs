using System;
using System.Diagnostics;

namespace AI_Project_Week_4___Adversarial_Search {
	class Program {
		static void Main(string[] args) {
			// Start with two random tiles placed
			BoardState startState = new BoardState();
			startState = (BoardState) startState.getAIAction().getNextState(startState);
			Console.WriteLine("Start state: \n" + startState + "\n");

			MinMaxSearch search = new MinMaxSearch();
			BoardState endState = startState;
			int moves = 0;
			while(!endState.isTerminal()) {
				endState = (BoardState) endState.getAIAction().getNextState(endState);

				Stopwatch sw = new Stopwatch();
				sw.Start();
				BoardMove myMove = (BoardMove) search.getBestAction(endState);
				sw.Stop();
				endState = (BoardState) myMove.getNextState(endState);

				Console.WriteLine("My move " + myMove + "(" + sw.ElapsedMilliseconds + "ms):\n" + endState);
				moves++;
			}

			float maxValue = endState.getUtilityValue();
			if(maxValue >= 2048) {
				Console.WriteLine("Passed with " + maxValue + " (" + moves + " moves)");
			} else {
				Console.WriteLine("Failed with " + maxValue + " (" + moves + " moves)");
			}

			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}
	}
}
