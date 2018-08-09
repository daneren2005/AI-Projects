namespace WumpusWorld {
	class Cell {
		public int x;
		public int y;
		public Element element;

		public Cell(int x, int y, Element element) {
			this.x = x;
			this.y = y;
			this.element = element;
		}

		public override string ToString() {
			return x + ", " + y;
		}
	}
}
