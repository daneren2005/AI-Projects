using System;

namespace WumpusWorld {
	class Hunter {
		public enum Direction {
			NORTH,
			EAST,
			SOUTH,
			WEST
		}

		public World world;
		public Direction direction = Direction.NORTH;
		public Cell cell;
		public bool running = true;
		public int arrows = 1;
		public int gold = 0;
		public int health = 1;
		public int score {
			get {
				return -1000 + 1000 * health + gold * 100 + arrows * 10;
			}
		}

		public Hunter(World world) {
			this.world = world;
		}

		public void takeAction(Action action) {
			int directionInt, newDirection;
			switch(action) {
				case Action.GO_FORWARD:
					cell = world.getNextCell(cell, direction);

					if(cell.element == Element.WUMPUS || cell.element == Element.PIT) {
						health = 0;
						running = false;
					}
					break;
				case Action.TURN_LEFT:
					directionInt = (int) direction;
					newDirection = (directionInt - 1) % 4;
					direction = (Direction) newDirection;
					break;
				case Action.TURN_RIGHT:
					directionInt = (int) direction;
					newDirection = (directionInt + 1) % 4;
					direction = (Direction) newDirection;
					break;
				case Action.GRAB:
					gold++;
					cell.element = Element.EMPTY;
					break;
				case Action.EXIT:
					running = false;
					break;
				case Action.SHOOT_ARROW:
					Cell arrowCell = cell;
					for(int i = 0; i < world.cells.Length - 1; i++) {
						arrowCell = world.getNextCell(arrowCell, direction);

						if(arrowCell.element == Element.WUMPUS) {
							arrowCell.element = Element.EMPTY;
						}
					}

					arrows--;
					break;
			}
		}
	}
}
