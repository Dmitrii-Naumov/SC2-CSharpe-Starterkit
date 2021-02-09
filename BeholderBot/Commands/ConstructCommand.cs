using SC2_Connector;

namespace BeholderBot
{
	public class ConstructCommand : Command
	{
		protected uint BuildingToConstruct;
		public ConstructCommand(uint buildingToConstruct)
		{
			BuildingToConstruct = buildingToConstruct;
		}
		public override bool Execute(Beholder bot)
		{
			if (Controller.CanConstruct(BuildingToConstruct))
			{
				Controller.Construct(bot.GetAvailableWorker(), BuildingToConstruct);
				return true;
			}
			return false;
		}
	}
}
