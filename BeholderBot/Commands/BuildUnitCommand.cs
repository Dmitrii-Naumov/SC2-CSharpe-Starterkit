using SC2_Connector;

namespace BeholderBot
{
	public class BuildUnitCommand : Command
	{
		private uint UnitToBuild;
		public BuildUnitCommand(uint unitToBuild)
		{
			UnitToBuild = unitToBuild;
		}
		public override bool Execute(Beholder bot)
		{
			return Controller.BuildUnit(UnitToBuild);
		}
	}

}
