using SC2_Connector;
using System.Numerics;

namespace BeholderBot
{
	public class GetUnitCommand : Command
	{
		private uint UnitType;
		private Vector3 Position;
		private Unit ToPopulate;
		public GetUnitCommand(uint unitType, Unit unitToPopulate, Vector3 position= new Vector3())
		{
			UnitType = unitType;
			Position = position;
			if (unitToPopulate != null)
				throw new System.Exception("Unit must be empty");
		}
		public override bool Execute(Beholder bot)
		{
			var unit  = Controller.GetUnit(UnitType); 
			return unit != null;
		}
	}

}
