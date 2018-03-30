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
	}
}
