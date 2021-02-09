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
			var command = BO.Peek();
			switch (command.Behavior)
			{
				case CommandBehavior.Blocking: if (command.TryExecute(bot)) { BO.Dequeue(); } break;
				case CommandBehavior.NonBlocking: bot.ASyncCommands.Add(command); BO.Dequeue(); break;
				case CommandBehavior.Repetative: bot.RepetativeCommands.Add(command); BO.Dequeue(); break;
			}
		}
		protected Condition AbortCondition;
		protected Queue<Command> BO;
	}
}
