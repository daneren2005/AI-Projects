using static WumpusWorld.Hunter;

namespace WumpusWorld {
	class World {
		public Cell[][] cells;
		public Hunter hunter;

		public World(int width, int height) {
			cells = new Cell[height][];
			for(int y = 0; y < height; y++) {
				cells[y] = new Cell[width];

				for(int x = 0; x < width; x++) {
					cells[y][x] = new Cell(x, y, Element.EMPTY);
				}
			}

			hunter = new Hunter(this);
			setElement(0, 0, Element.HUNTER);
		}

		public void setElement(int x, int y, Element element) {
			if(element == Element.HUNTER) {
				if(hunter.cell != null) {
					hunter.cell.element = Element.EMPTY;
				}

				hunter.cell = cells[y][x];
			} else {
				cells[y][x].element = element;
			}
		}

		public Cell getCell(int x, int y) {
			if(y < 0) {
				y = 0;
			} else if(y >= cells.Length) {
				y = cells.Length - 1;
			}

			if(x < 0) {
				x = 0;
			} else if(x >= cells[y].Length) {
				x = cells[y].Length - 1;
			}

			return cells[y][x];
		}
		public Cell getNextCell(Cell cell, Direction direction) {
			switch(direction) {
				case Direction.NORTH:
					return getCell(cell.x, cell.y - 1);
				case Direction.SOUTH:
					return getCell(cell.x, cell.y + 1);
				case Direction.WEST:
					return getCell(cell.x - 1, cell.y);
				case Direction.EAST:
					return getCell(cell.x + 1, cell.y);
			}

			return cell;
		}

		public override string ToString() {
			string str = "";

			for(int y = 0; y < cells.Length; y++) {
				// Draw the header line
				for(int x = 0; x < cells[y].Length; x++) {
					if(x == 0) {
						str += "+";
					}
					str += "---+";
				}
				str += "\n";

				// Draw the content line
				for(int x = 0; x < cells[y].Length; x++) {
					if(x == 0) {
						str += "|";
					}
					str += " ";

					Cell cell = cells[y][x];
					Element element = cell.element;
					if(cell == hunter.cell) {
						element = Element.HUNTER;
					}

					switch(element) {
						case Element.WUMPUS:
							str += "W";
							break;
						case Element.PIT:
							str += "O";
							break;
						case Element.GOLD:
							str += "$";
							break;
						case Element.HUNTER:
							str += "@";
							break;
						default:
							str += " ";
							break;
					}
					
					str += " |";
				}
				str += "\n";
			}

			// Draw the footer line
			for(int x = 0; x < cells[0].Length; x++) {
				if(x == 0) {
					str += "+";
				}
				str += "---+";
			}
			str += "\n";

			return str;
		}
	}
}
