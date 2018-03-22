using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_Week_2___Search {
	class Node {
		public IAction action { get; set; }
		public IState resultState { get; set; }

		public Node(IAction action, IState resultState) {
			this.action = action;
			this.resultState = resultState;
		}
	}
}
