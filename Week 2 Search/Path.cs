using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_Week_2___Search {
	class Path {
		public IState initialState;
		public List<Node> nodes;
		public IState finalState;
		public List<IAction> actions {
			get {
				List<IAction> actions = new List<IAction>();

				foreach(Node node in nodes) {
					actions.Add(node.action);
				}

				return actions;
			}
		}
		public float cost {
			get; set;
		} = 0;

		public int nodesExpanded { get; set; }
		public int searchDepth { get; set; }
		public int maxSearchDepth { get; set; }

		public Path(IState initialState) {
			this.initialState = initialState;
			nodes = new List<Node>();
			finalState = initialState;
		}
		public Path(Path path, IAction action) {
			initialState = path.initialState;

			nodes = new List<Node>();
			nodes.AddRange(path.nodes);

			finalState = path.finalState.applyAction(action);
			nodes.Add(new Node(action, finalState));
			cost = path.cost + action.getCost();
		}

		public float getMinDistance(IState goal) {
			return cost + finalState.getHeuristicDistance(goal);
		}

		public override bool Equals(object obj) {
			if(obj is Path path) {
				return ToString() == path.ToString();
			} else {
				return false;
			}
		}

		public override int GetHashCode() {
			return ToString().GetHashCode();
		}

		public override string ToString() {
			return finalState.ToString();
		}
	}
}
