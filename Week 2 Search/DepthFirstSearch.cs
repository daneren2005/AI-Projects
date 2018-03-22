using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_Week_2___Search {
	class DepthFirstSearch : IPathFinder {
		IState initialState;

		public DepthFirstSearch(IState initialState) {
			this.initialState = initialState;
		}

		public Path search(IState goal) {
			List<IState> states = new List<IState>();

			Stack<Path> frontier = new Stack<Path>();
			List<IState> explored = new List<IState>();

			frontier.Push(new Path(initialState));
			while(frontier.Count > 0) {
				Path path = frontier.Pop();
				IState state = path.finalState;
				explored.Add(state);

				List<IAction> actions = state.getActions();
				actions.Reverse();
				foreach(IAction action in actions) {
					IState nextState = state.applyAction(action);
					Path newPath = new Path(path, action);
					if(nextState.Equals(goal)) {
						newPath.nodesExpanded = explored.Count;
						return newPath;
					}

					if(!explored.Contains(nextState) && !frontier.Contains(newPath)) {
						frontier.Push(newPath);
					}
				}
			}

			return null;
		}
	}
}
