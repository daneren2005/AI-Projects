using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_Week_2___Search {
	interface IState {
		List<IAction> getActions();
		IState applyAction(IAction action);
		float getHeuristicDistance(IState goal);
	}
}
