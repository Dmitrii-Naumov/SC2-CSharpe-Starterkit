using SC2_Connector;

namespace BeholderBot
{
	public class MinSupplyCondition : Condition
	{
		private int MinSupply;
		public MinSupplyCondition(int minSupply)
		{
			MinSupply = minSupply;
		}

		public override bool IsTrue()
		{
			if (MinSupply > Controller.CurrentSupply)
				return false;
			else
				return true;
		}
	}
}
