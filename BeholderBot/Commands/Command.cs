using System;

namespace BeholderBot
{
	public abstract class Command
	{
		protected Condition Condition;

		public CommandBehavior Behavior;
		public Command WithCondition(Condition condition)
		{
			Condition = condition;
			return this;
		}
		public bool TryExecute(Beholder bot)
		{
			return (Condition == null || Condition.IsTrue()) && Execute(bot);
		}
		public abstract bool Execute(Beholder bot);

	}
}
