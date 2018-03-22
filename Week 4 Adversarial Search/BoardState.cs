using System;
using System.Collections.Generic;

namespace AI_Project_Week_4___Adversarial_Search {
	class BoardState : IState, ICloneable {
		private static Random rand = new Random();
		public int[,] grid = new int[4, 4];

		private float MAX_WEIGHT = 1.0f;
		private float EMPTY_WEIGHT = 2.7f;
		private float MONOTONICITY_WEIGHT = 1f;

		public BoardState() {
			grid = new int[4, 4] {
				{ 0, 0, 0, 0 },
				{ 0, 0, 0, 0 },
				{ 0, 0, 0, 0 },
				{ 0, 0, 0, 0 }
			};
		}
		public BoardState(int[,] grid) {
			this.grid = grid;
		}

		public float getUtilityValue() {
			return getMaxValue();
		}
		public float getHeuristicValue() {
			return getMaxValue() * MAX_WEIGHT +
				getFreeSpaceAvailable() * EMPTY_WEIGHT + 
				getMonotonicity() * MONOTONICITY_WEIGHT;
		}

		private int getMaxValue() {
			int value = 0;
			for(int i = 0; i < grid.GetLength(0); i++) {
				for(int j = 0; j < grid.GetLength(1); j++) {
					value = Math.Max(grid[i, j], value);
				}
			}

			return value;
		}

		// Interesting implementation of these heuristics: https://github.com/ovolve/2048-AI/blob/master/js/grid.js
		private float getMonotonicity() {
			float[] totals = { 0, 0, 0, 0 };

			for(int i = 0; i < grid.GetLength(0); i++) {
				int current = 0;
				int next = current + 1;
				while(next < grid.GetLength(0)) {
					while(next < 3 && grid[i, next] == 0) {
						next++;
					}

					float currentValue = 0;
					if(grid[i, current] != 0) {
						currentValue = (float) (Math.Log(grid[i, current]) / Math.Log(2));
					}

					float nextValue = 0;
					if(grid[i, next] != 0) {
						nextValue = (float) (Math.Log(grid[i, next]) / Math.Log(2));
					}

					if(currentValue > nextValue) {
						totals[0] += nextValue - currentValue;
					} else {
						totals[1] += currentValue - nextValue;
					}

					current = next;
					next++;
				}
			}

			for(int j = 0; j < grid.GetLength(1); j++) {
				int current = 0;
				int next = current + 1;
				while(next < grid.GetLength(1)) {
					while(next < 3 && grid[next, j] == 0) {
						next++;
					}

					float currentValue = 0;
					if(grid[current, j] != 0) {
						currentValue = (float) (Math.Log(grid[current, j]) / Math.Log(2));
					}

					float nextValue = 0;
					if(grid[next, j] != 0) {
						nextValue = (float) (Math.Log(grid[next, j]) / Math.Log(2));
					}

					if(currentValue > nextValue) {
						totals[2] += nextValue - currentValue;
					} else {
						totals[3] += currentValue - nextValue;
					}

					current = next;
					next++;
				}
			}

			return Math.Max(totals[0], totals[1]) + Math.Max(totals[2], totals[3]);
		}
		private float getSmoothness() {
			float smoothness = 0;

			for(int i = 0; i < grid.GetLength(0); i++) {
				for(int j = 0; j < grid.GetLength(1); j++) {
					int value = grid[i, j];
					if(value != 0) {
						
					}
				}
			}

			return smoothness;
		}
		private float getFreeSpaceAvailable() {
			int spaces = 0;

			for(int i = 0; i < grid.GetLength(0); i++) {
				for(int j = 0; j < grid.GetLength(1); j++) {
					if(grid[i, j] == 0) {
						spaces++;
					}
				}
			}

			return spaces;
		}

		public List<IAction> getMaxActions() {
			List<IAction> actions = new List<IAction>();

			actions.Add(new BoardMove(BoardMove.Direction.LEFT));
			actions.Add(new BoardMove(BoardMove.Direction.RIGHT));
			actions.Add(new BoardMove(BoardMove.Direction.UP));
			actions.Add(new BoardMove(BoardMove.Direction.DOWN));

			return actions;
		}

		public List<IAction> getMinActions() {
			List<IAction> actions = new List<IAction>();

			for(int i = 0; i < grid.GetLength(0); i++) {
				for(int j = 0; j < grid.GetLength(1); j++) {
					if(grid[i, j] == 0) {
						actions.Add(new TilePlace(i, j));
					}
				}
			}

			return actions;
		}

		public TilePlace getAIAction() {
			if(getFreeSpaceAvailable() == 0) {
				throw new Exception("No possible moves for AI due to game being over already");
			}

			while(true) {
				int i = rand.Next(0, grid.GetLength(0));
				int j = rand.Next(0, grid.GetLength(1));

				if(grid[i, j] == 0) {
					return new TilePlace(i, j, rand.Next(1, 2) * 2);
				}
			}
		}

		public bool isTerminal() {
			for(int i = 0; i < grid.GetLength(0); i++) {
				for(int j = 0; j < grid.GetLength(1); j++) {
					if(grid[i, j] == 0) {
						return false;
					}
				}
			}

			return true;
		}

		public override string ToString() {
			string str = "";

			for(int i = 0; i < grid.GetLength(0); i++) {
				for(int j = 0; j < grid.GetLength(1); j++) {
					string numStr = grid[i, j].ToString();
					str += numStr.PadLeft(4, ' ');

					if((j + 1) < grid.GetLength(1)) {
						str += " ";
					}
				}
				
				if((i + 1) < grid.GetLength(0)) {
					str += "\n";
				}
			}

			return str;
		}

		public object Clone() {
			return MemberwiseClone();
		}
	}
}
