using System.Collections.Generic;

namespace AI_Project_Week_4___Adversarial_Search {
	class MinMaxSearch {
		private int maxDepth = 6;

		public IAction getBestAction(IState startState) {
			return getBestAction(startState, 0, true).action;
		}

		protected (float value, IAction action) getBestAction(IState startState, int depth, bool isMax) {
			if(isMax) {
				(float maxValue, IAction maxAction) = (float.NegativeInfinity, null);

				List<IAction> actions = startState.getMaxActions();
				foreach(IAction action in actions) {
					IState nextState = action.getNextState(startState);

					float nextValue;
					if(depth >= maxDepth || nextState.isTerminal()) {
						nextValue = nextState.getHeuristicValue();
					} else {
						nextValue = getBestAction(nextState, depth + 1, false).value;
					}

					if(nextValue > maxValue) {
						(maxValue, maxAction) = (nextValue, action);
					}
				}
				
				return (maxValue, maxAction);
			} else {
				(float minValue, IAction minAction, List<IAction> minPlan) = (float.PositiveInfinity, null, null);

				List<IAction> actions = startState.getMinActions();
				foreach(IAction action in actions) {
					IState nextState = action.getNextState(startState);

					float nextValue;
					if(depth >= maxDepth || nextState.isTerminal()) {
						nextValue = nextState.getHeuristicValue();
					} else {
						nextValue = getBestAction(nextState, depth + 1, true).value;
					}

					if(nextValue < minValue) {
						(minValue, minAction) = (nextValue, action);
					}
				}
				
				return (minValue, minAction);
			}
		}
	}
}
