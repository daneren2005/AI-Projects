using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_Week_2___Search {
	class BoardState : IState {
		private int[,] tiles = new int[3, 3];
		private int size = 3;
		private int blankX;
		private int blankY;

		public BoardState(string order) {
			string[] tileStrings = order.Split(',');

			for(int i = 0; i < tileStrings.Length; i++) {
				int tile = int.Parse(tileStrings[i]);

				int x = i % 3;
				int y = i / 3;
				tiles[x, y] = tile;

				if(tile == 0) {
					blankX = x;
					blankY = y;
				}
			}
		}
		public BoardState(int[,] tiles, int blankX, int blankY) {
			this.tiles = tiles;
			this.blankX = blankX;
			this.blankY = blankY;
		}

		public List<IAction> getActions() {
			List<IAction> actions = new List<IAction>();

			if(blankY != 0) {
				actions.Add(new BoardMove("up"));
			}
			if(blankY != 2) {
				actions.Add(new BoardMove("down"));
			}

			if(blankX != 0) {
				actions.Add(new BoardMove("left"));
			}
			if(blankX != 2) {
				actions.Add(new BoardMove("right"));
			}

			return actions;
		}

		public IState applyAction(IAction action) {
			BoardMove move = (BoardMove) action;

			int[,] tiles = (int[,]) this.tiles.Clone();
			int blankX = this.blankX;
			int blankY = this.blankY;

			switch(move.direction) {
				case "left":
					tiles[blankX, blankY] = tiles[blankX - 1, blankY];
					blankX--;
					break;
				case "right":
					tiles[blankX, blankY] = tiles[blankX + 1, blankY];
					blankX++;
					break;
				case "up":
					tiles[blankX, blankY] = tiles[blankX, blankY - 1];
					blankY--;
					break;
				case "down":
					tiles[blankX, blankY] = tiles[blankX, blankY + 1];
					blankY++;
					break;
			}
			tiles[blankX, blankY] = 0;

			return new BoardState(tiles, blankX, blankY);
		}

		// https://heuristicswiki.wikispaces.com/N+-+Puzzle
		// Option 1: Total number of misplaced tiles
		// Option 2: Distance required to move each tile to it's correct location (ie: from top left to bottom middle would be 3 moves)
		public float getHeuristicDistance(IState goal) {
			return getMisplacedTiles(goal);
		}



		/* A* Runs
		Depth: 1(1 explored with 0 remaining)
		Depth: 2(2 explored with 1 remaining)
		Depth: 3(3 explored with 2 remaining)
		Depth: 4(4 explored with 2 remaining)
		Depth: 5(5 explored with 3 remaining)
		Depth: 6(8 explored with 7 remaining)
		Depth: 7(9 explored with 8 remaining)
		Depth: 8(21 explored with 17 remaining)
		Depth: 9(30 explored with 23 remaining)
		Depth: 10(38 explored with 28 remaining)

		Depth: 1(1 explored with 0 remaining)
		Depth: 2(2 explored with 3 remaining)
		Depth: 3(3 explored with 4 remaining)
		Depth: 4(8 explored with 7 remaining)
		Depth: 5(16 explored with 9 remaining)
		Depth: 6(25 explored with 17 remaining)
		Depth: 7(30 explored with 22 remaining)
		Depth: 8(54 explored with 42 remaining)
		Depth: 9(98 explored with 66 remaining)
		Depth: 10(163 explored with 95 remaining)
		Depth: 11(184 explored with 109 remaining)
		Depth: 12(280 explored with 180 remaining)
		Depth: 13(331 explored with 196 remaining)
		Depth: 14(484 explored with 296 remaining)
		Depth: 15(541 explored with 319 remaining)
		Depth: 16(959 explored with 585 remaining)
		Depth: 17(2158 explored with 1319 remaining)
		Depth: 18(3468 explored with 1975 remaining)
		Depth: 19(3792 explored with 2116 remaining)
		Depth: 20(3881 explored with 2150 remaining)
		Node expanded: 3881
		Elapsed: 00:00:37.9798069
		
		Depth: 1(1 explored with 0 remaining)
		Depth: 2(2 explored with 3 remaining)
		Depth: 3(6 explored with 7 remaining)
		Depth: 4(14 explored with 7 remaining)
		Depth: 5(15 explored with 8 remaining)
		Depth: 6(26 explored with 19 remaining)
		Depth: 7(45 explored with 38 remaining)
		Depth: 8(86 explored with 59 remaining)
		Depth: 9(104 explored with 70 remaining)
		Depth: 10(176 explored with 103 remaining)
		Depth: 11(267 explored with 170 remaining)
		Depth: 12(300 explored with 184 remaining)
		Depth: 13(457 explored with 278 remaining)
		Depth: 14(512 explored with 301 remaining)
		Depth: 15(917 explored with 559 remaining)
		Depth: 16(1394 explored with 824 remaining)
		Depth: 17(1417 explored with 834 remaining)
		Depth: 18(3365 explored with 1977 remaining)
		Depth: 19(3792 explored with 2136 remaining)
		Depth: 20(3807 explored with 2143 remaining)
		Depth: 21(6575 explored with 3669 remaining)
		Depth: 22(9476 explored with 4950 remaining)
		Depth: 23(15857 explored with 7976 remaining)
		Depth: 24(33049 explored with 13966 remaining)
		Depth: 25(43107 explored with 16842 remaining)
		Depth: 26(46083 explored with 17097 remaining)
		Node expanded: 46083
		Elapsed: 01:27:57.3738254*/
		protected float getMisplacedTiles(IState goal) {
			int misplacedTiles = 0;

			for(int i = 0; i < 9; i++) {
				var x = i % 3;
				var y = i / 3;

				if(tiles[x, y] != i) {
					misplacedTiles++;
				}
			}

			return misplacedTiles;
		}

		/* A* Runs
		Depth: 1(1 explored with 0 remaining)
		Depth: 2(2 explored with 1 remaining)
		Depth: 3(3 explored with 2 remaining)
		Depth: 4(4 explored with 2 remaining)
		Depth: 5(5 explored with 3 remaining)
		Depth: 6(6 explored with 3 remaining)
		Depth: 7(9 explored with 8 remaining)
		Depth: 8(20 explored with 17 remaining)
		Depth: 9(29 explored with 22 remaining)
		Depth: 10(34 explored with 23 remaining)

		Depth: 1(1 explored with 0 remaining)
		Depth: 2(2 explored with 3 remaining)
		Depth: 3(3 explored with 4 remaining)
		Depth: 4(5 explored with 5 remaining)
		Depth: 5(13 explored with 9 remaining)
		Depth: 6(14 explored with 9 remaining)
		Depth: 7(15 explored with 10 remaining)
		Depth: 8(17 explored with 13 remaining)
		Depth: 9(18 explored with 14 remaining)
		Depth: 10(21 explored with 15 remaining)
		Depth: 11(22 explored with 16 remaining)
		Depth: 12(27 explored with 18 remaining)
		Depth: 13(44 explored with 31 remaining)
		Depth: 14(89 explored with 62 remaining)
		Depth: 15(90 explored with 63 remaining)
		Depth: 16(119 explored with 79 remaining)
		Depth: 17(122 explored with 82 remaining)
		Depth: 18(204 explored with 129 remaining)
		Depth: 19(263 explored with 165 remaining)
		Depth: 20(454 explored with 283 remaining)
		Node expanded: 454
		Elapsed: 00:00:00.5241810

		Depth: 1(1 explored with 0 remaining)
		Depth: 2(2 explored with 3 remaining)
		Depth: 3(3 explored with 4 remaining)
		Depth: 4(10 explored with 7 remaining)
		Depth: 5(11 explored with 8 remaining)
		Depth: 6(15 explored with 10 remaining)
		Depth: 7(22 explored with 13 remaining)
		Depth: 8(23 explored with 13 remaining)
		Depth: 9(33 explored with 23 remaining)
		Depth: 10(40 explored with 29 remaining)
		Depth: 11(43 explored with 33 remaining)
		Depth: 12(66 explored with 49 remaining)
		Depth: 13(67 explored with 50 remaining)
		Depth: 14(99 explored with 68 remaining)
		Depth: 15(164 explored with 106 remaining)
		Depth: 16(213 explored with 123 remaining)
		Depth: 17(214 explored with 124 remaining)
		Depth: 18(365 explored with 224 remaining)
		Depth: 19(426 explored with 268 remaining)
		Depth: 20(661 explored with 401 remaining)
		Depth: 21(753 explored with 444 remaining)
		Depth: 22(1192 explored with 727 remaining)
		Depth: 23(1193 explored with 728 remaining)
		Depth: 24(2579 explored with 1437 remaining)
		Depth: 25(3377 explored with 1946 remaining)
		Depth: 26(3474 explored with 2014 remaining)
		Node expanded: 3474
		Elapsed: 00:00:31.6642551
		*/
		protected float getMoveDistance(IState goal) {
			int moveDistance = 0;

			for(int i = 0; i < 9; i++) {
				int actualX = i % 3;
				int actualY = i / 3;

				int tile = tiles[actualX, actualY];
				int goalX = tile % 3;
				int goalY = tile / 3;

				moveDistance += Math.Abs(goalX - actualX) + Math.Abs(goalY - actualY);
			}

			return moveDistance;
		}

		public override bool Equals(object obj) {
			if(obj is BoardState boardState) {
				return ToString() == boardState.ToString();
			} else {
				return false;
			}
		}

		public override int GetHashCode() {
			return ToString().GetHashCode();
		}

		public override string ToString() {
			string str = "";
			for(int i = 0; i < tiles.GetLength(1); i++) {
				for(int j = 0; j < tiles.GetLength(0); j++) {
					str += tiles[j, i].ToString();
				}
			}

			return str;
		}
	}
}
