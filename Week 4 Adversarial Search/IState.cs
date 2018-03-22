using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_Week_4___Adversarial_Search {
	interface IState {
		float getUtilityValue();
		float getHeuristicValue();
		List<IAction> getMaxActions();
		List<IAction> getMinActions();
		bool isTerminal();
	}
}
