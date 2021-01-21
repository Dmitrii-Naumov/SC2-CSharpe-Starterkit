using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
	public class BuildOrder
	{
		public bool AbortConditionMet()
		{
			return BO.Count == 0 || AbortCondition.IsTrue();
		}
		public void ExecuteBO()
		{
			if (BO.Peek().TryExecute())
			{
				BO.Dequeue();
			}
		}
		protected Condition AbortCondition;
		protected Queue<CommandWithCondition> BO;
	}
}
