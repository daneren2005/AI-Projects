namespace WumpusWorld {
	class World {
		private Cell[][] cells;
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
			cells[y][x].element = element;

			if(element == Element.HUNTER) {
				if(hunter.cell != null) {
					hunter.cell.element = Element.EMPTY;
				}

				hunter.cell = cells[y][x];
			}
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

					Element element = cells[y][x].element;
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
