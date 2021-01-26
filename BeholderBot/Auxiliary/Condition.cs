using SC2_Connector;

namespace BeholderBot
{
	public abstract class Condition
	{
		public abstract bool IsTrue();
	}
	public class EmptyCondition : Condition
	{
		public override bool IsTrue()
		{
			return true;
		}
	}
	public class UnitsCondition : Condition
	{
		uint UnitType;
		int Qty;
		public UnitsCondition(uint unitType, int qty)
		{
			Qty = qty;
			UnitType = unitType;
		}
		public override bool IsTrue()
		{
			return Controller.GetUnits(UnitType).Count >= Qty;
		}
	}
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
