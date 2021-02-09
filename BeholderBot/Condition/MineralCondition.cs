using SC2_Connector;

namespace BeholderBot
{
	public class MineralCondition : Condition
	{
		private int Minerals;
		public MineralCondition(int minerals)
		{
			Minerals = minerals;
		}

		public override bool IsTrue()
		{
			if (Minerals > Controller.Minerals)
				return false;
			else
				return true;
		}
	}
}
