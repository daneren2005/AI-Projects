using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_Week_2___Search {
	class AStarSearch : IPathFinder {
		IState initialState;

		public AStarSearch(IState initialState) {
			this.initialState = initialState;
		}

		public Path search(IState goal) {
			List<IState> states = new List<IState>();

			SimplePriorityQueue<Path> frontier = new SimplePriorityQueue<Path>();
			List<IState> explored = new List<IState>();

			frontier.Enqueue(new Path(initialState), initialState.getHeuristicDistance(goal));
			int maxDepth = 0;
			while(frontier.Count > 0) {
				Path path = frontier.Dequeue();
				IState state = path.finalState;
				explored.Add(state);

				List<IAction> actions = state.getActions();
				foreach(IAction action in actions) {
					IState nextState = state.applyAction(action);
					Path newPath = new Path(path, action);
					if(newPath.actions.Count > maxDepth) {
						maxDepth = newPath.actions.Count;
						Console.WriteLine("Depth: " + maxDepth + "(" + explored.Count + " explored with " + frontier.Count + " remaining)");
					}

					if(nextState.Equals(goal)) {
						newPath.nodesExpanded = explored.Count;
						return newPath;
					}

					// TODO: I think I need to check if we have a similar path
					if(!explored.Contains(nextState) && !frontier.Contains(newPath)) {
						frontier.Enqueue(newPath, newPath.getMinDistance(goal));
					}
				}
			}

			return null;
		}
	}
}
