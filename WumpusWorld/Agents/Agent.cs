namespace WumpusWorld.Agents {
	abstract class Agent {
		public Hunter hunter;

		public Agent(Hunter hunter) {
			this.hunter = hunter;
		}

		public abstract Action getNextAction();
	}
}
