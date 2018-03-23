using System;
using System.Collections.Generic;
using System.IO;

namespace Week_7___Machine_Learning {
	class Program {
		static void Main(string[] args) {
			var lines = File.ReadLines("perceptron.csv");

			List<Record> records = new List<Record>();
			foreach(string line in lines) {
				string[] parts = line.Split(',');

				Record record = new Record(new double[] { Int32.Parse(parts[0]), Int32.Parse(parts[1]) }, parts[2] == "1");
				records.Add(record);
			}

			Perceptron perceptron = new Perceptron(2);
			float pastErrorRate = 0;
			float errorRateDiff;
			do {
				float errorRate = perceptron.train(records);
				errorRateDiff = errorRate - pastErrorRate;
				pastErrorRate = errorRate;
				Console.WriteLine("Error rate: " + errorRate + " (Diff: " + errorRateDiff + ")");
			} while(pastErrorRate > 0.05);


			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}
	}
}
