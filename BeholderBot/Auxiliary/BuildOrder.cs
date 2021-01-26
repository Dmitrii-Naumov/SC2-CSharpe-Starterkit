using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderBot
{
	public class BuildOrder
	{
		public bool AbortConditionMet()
		{
			return BO.Count == 0 || AbortCondition.IsTrue();
		}
		public void ExecuteBO(Beholder bot)
		{
			if (BO.Peek().TryExecute(bot))
			{
				BO.Dequeue();
			}
		}
		protected Condition AbortCondition;
		protected Queue<CommandWithCondition> BO;
	}
}
