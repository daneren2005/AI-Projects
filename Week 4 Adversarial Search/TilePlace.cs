namespace AI_Project_Week_4___Adversarial_Search {
	class TilePlace : IAction {
		protected int x;
		protected int y;
		protected int quantity;

		public TilePlace(int x, int y) {
			this.x = x;
			this.y = y;
			this.quantity = 2;
		}
		public TilePlace(int x, int y, int quantity) {
			this.x = x;
			this.y = y;
			this.quantity = quantity;
		}

		public IState getNextState(IState startState) {
			BoardState boardState = (BoardState) startState;

			int[,] grid = (int[,]) boardState.grid.Clone();
			grid[x, y] = quantity;

			return new BoardState(grid);
		}

		public override string ToString() {
			return "(" + x + ", " + y + ")";
		}
	}
}
