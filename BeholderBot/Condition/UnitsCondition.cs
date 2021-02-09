using SC2_Connector;

namespace BeholderBot
{
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
}
