namespace AI_Project_Week_4___Adversarial_Search {
	class BoardMove : IAction {
		public enum Direction { LEFT, RIGHT, UP, DOWN };
		public Direction direction;

		public BoardMove(Direction direction) {
			this.direction = direction;
		}

		public IState getNextState(IState startState) {
			BoardState boardState = (BoardState) startState;

			int[,] grid = (int[,]) boardState.grid.Clone();

			int iStart = 0;
			int iEnd = 0;
			int iDimension = 0;
			int iInc = 0;

			int jStart = 0;
			int jEnd = 0;
			int jDimension = 0;
			int jInc = 0;
			switch(direction) {
				case Direction.LEFT:
					iStart = 1;
					iEnd = grid.GetLength(1);
					iDimension = 1;
					iInc = 1;

					jStart = 0;
					jEnd = grid.GetLength(0);
					jDimension = 0;
					jInc = 1;
					break;
				case Direction.RIGHT:
					iStart = grid.GetLength(1) - 2;
					iEnd = -1;
					iDimension = 1;
					iInc = -1;

					jStart = 0;
					jEnd = grid.GetLength(0);
					jDimension = 0;
					jInc = 1;
					break;
				case Direction.UP:
					iStart = 1;
					iEnd = grid.GetLength(0);
					iDimension = 0;
					iInc = 1;

					jStart = 0;
					jEnd = grid.GetLength(1);
					jDimension = 1;
					jInc = 1;
					break;
				case Direction.DOWN:
					iStart = grid.GetLength(0) - 2;
					iEnd = -1;
					iDimension = 0;
					iInc = -1;

					jStart = 0;
					jEnd = grid.GetLength(1);
					jDimension = 1;
					jInc = 1;
					break;
			}

			for(int i = iStart; i != iEnd; i += iInc) {
				for(int j = jStart; j != jEnd; j += jInc) {
					int x = iDimension == 0 ? i : j;
					int y = jDimension == 0 ? i : j;

					int val = grid[x, y];
					if(val == 0) {
						continue;
					}

					int xInc = iDimension == 0 ? iInc : 0;
					int yInc = jDimension == 0 ? iInc : 0;

					int xEnd = iDimension == 0 ? (iStart - iInc * 2) : (jStart - jInc * 2);
					int yEnd = jDimension == 0 ? (iStart - iInc * 2) : (jStart - jInc * 2);

					int currentX = x;
					int currentY = y;

					while((currentX - xInc) != xEnd && (currentY - yInc) != yEnd) {
						int nextBlankX = currentX - xInc;
						int nextBlankY = currentY - yInc;

						if(grid[nextBlankX, nextBlankY] == 0) {
							grid[nextBlankX, nextBlankY] = val;
							grid[currentX, currentY] = 0;

							currentX = nextBlankX;
							currentY = nextBlankY;
						} else {
							// Yay, merge!
							if(grid[nextBlankX, nextBlankY] == val) {
								grid[nextBlankX, nextBlankY] = val * 2;
								grid[currentX, currentY] = 0;
							}

							break;
						}
					}
				}
			}

			return new BoardState(grid);
		}

		public override string ToString() {
			switch(direction) {
				case Direction.LEFT:
					return "Left";
				case Direction.RIGHT:
					return "Right";
				case Direction.UP:
					return "Up";
				case Direction.DOWN:
					return "Down";
				default:
					return "Invalid";
			}
		}
	}
}
