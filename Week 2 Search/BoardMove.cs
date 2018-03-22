using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_Week_2___Search {
	class BoardMove : IAction {
		public string direction;

		public BoardMove(string direction) {
			this.direction = direction;
		}

		public float getCost() {
			return 1;
		}

		public override string ToString() {
			return direction;
		}
	}
}
