namespace Bot
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
		public MinSupplyCondition(int minSupply)
		{
			MinSupply = minSupply;
		}
		private int MinSupply;

		public override bool IsTrue()
		{
			if (MinSupply > Controller.currentSupply)
				return false;
			else
				return true;
		}
	}
}
