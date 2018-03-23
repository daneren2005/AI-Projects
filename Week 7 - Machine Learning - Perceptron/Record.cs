using System;

namespace Week_7___Machine_Learning {
	struct Record {
		public double[] points;
		public bool label;

		public Record(double[] points, bool label) {
			this.points = points;
			this.label = label;
		}

		public override string ToString() {
			return String.Join(", ", points) + " => " + label;
		}
	}
}
