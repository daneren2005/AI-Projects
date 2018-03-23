using System;
using System.Collections.Generic;

namespace Week_7___Machine_Learning {
	class Perceptron {
		public double[] weights;
		public double biasWeight;

		private const double learningRate = 1.0;

		public Perceptron(int size) {
			Random r = new Random();

			weights = new double[size];
			for(int i = 0; i < size; i++) {
				weights[i] = r.NextDouble();
			}
			biasWeight = r.NextDouble();
		}

		public float train(List<Record> records) {
			float errors = 0;
			foreach(Record record in records) {
				if(!train(record)) {
					errors++;
				}
			}

			return errors / records.Count;
		}
		public bool train(Record record) {
			bool result = pulse(record);

			if(result != record.label) {
				int error = result ? -1 : 1;
				for(int i = 0; i < weights.Length; i++) {
					weights[i] += learningRate * error * record.points[i];
				}
				biasWeight += learningRate * error;

				return false;
			} else {
				return true;
			}
		}

		public bool pulse(Record record) {
			double sum = 0;
			for(int i = 0; i < record.points.Length; i++) {
				sum += record.points[i] * weights[i];
			}
			sum += biasWeight;
			
			if(sum >= 0) {
				return true;
			} else {
				return false;
			}
		}

		public float getErrorRate(List<Record> records) {
			float errors = 0;
			foreach(Record record in records) {
				bool result = pulse(record);
				if(result != record.label) {
					errors++;
				}
			}

			return errors / records.Count;
		}
	}
}
