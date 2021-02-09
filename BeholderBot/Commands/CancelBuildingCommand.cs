using SC2_Connector;

namespace BeholderBot
{
	public class CancelBuildingCommand : Command
	{
		private Unit UnitToCancel;
		public CancelBuildingCommand(Unit unitToCancel)
		{
			UnitToCancel = unitToCancel;
		}

		public override bool Execute(Beholder bot)
		{
			return Controller.Cancel(UnitToCancel);
		}
	}
}
