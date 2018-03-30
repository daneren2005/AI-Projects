using System;

namespace WumpusWorld.Agents {
	class RandomAgent : Agent {
		public RandomAgent(Hunter hunter) : base(hunter) {
		}

		public override Action getNextAction() {
			return Action.GO_FORWARD;
		}
	}
}
