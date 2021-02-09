namespace BeholderBot
{
	public class OrCondition : Condition
	{
		Condition Condition1;
		Condition Condition2;
		public OrCondition(Condition condition1, Condition condition2)
		{
			Condition1 = condition1;
			Condition2 = condition2;
		}

		public override bool IsTrue()
		{
			return Condition1.IsTrue() || Condition2.IsTrue();
		}
	}
}
