using System;

namespace WumpusWorld.Agents {
	class KnowledgeBasedAgent : Agent {
		public KnowledgeBasedAgent(Hunter hunter) : base(hunter) {
		}

		public override Action getNextAction() {
			if(hunter.gold > 0) {
				return Action.EXIT;
			} else if(hunter.cell.element == Element.GOLD) {
				return Action.GRAB;
			}

			if(hunter.isDeadEnd()) {
				return Action.TURN_RIGHT;
			} else {
				return Action.GO_FORWARD;
			}
		}
	}
}
