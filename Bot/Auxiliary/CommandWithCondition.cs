using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
	public class CommandWithCondition
	{
		public CommandWithCondition(Condition condition, Command command )
		{
			Condition = condition;
			Command = command;
		}

		protected Condition Condition;
		protected Command Command;
		public bool TryExecute()
		{
			return Condition.IsTrue() && Command.Execute();
		}
	}
	//public class ComplexCondition : Condition
	//{
	//	public bool IsTrue()
	//	{
	//	}
	//}
}
