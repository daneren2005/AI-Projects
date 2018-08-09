using System;

namespace WumpusWorld.Agents {
	class RandomAgent : Agent {
		private Random random = new Random();

		public RandomAgent(Hunter hunter) : base(hunter) {
		}

		public override Action getNextAction() {
			if(hunter.gold > 0) {
				return Action.EXIT;
			} else if(hunter.cell.element == Element.GOLD) {
				return Action.GRAB;
			}

			if(hunter.arrows > 0) {
				return (Action) random.Next(4);
			} else {
				return (Action) random.Next(3);
			}
		}
	}
}
