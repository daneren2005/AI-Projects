namespace AI_Project_Week_4___Adversarial_Search {
	interface IAction {
		IState getNextState(IState startState);
	}
}
