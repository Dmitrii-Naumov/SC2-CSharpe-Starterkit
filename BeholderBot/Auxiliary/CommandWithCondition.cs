using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderBot
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
		public bool TryExecute(Beholder bot)
		{
			return Condition.IsTrue() && Command.Execute(bot);
		}
	}
	//public class ComplexCondition : Condition
	//{
	//	public bool IsTrue()
	//	{
	//	}
	//}
}
