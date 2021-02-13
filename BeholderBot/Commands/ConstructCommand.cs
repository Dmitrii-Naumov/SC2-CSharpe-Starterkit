using SC2_Connector;
using System;
using System.Numerics;

namespace BeholderBot
{
	public class ConstructCommand : Command
	{
		protected uint BuildingToConstruct;
		protected Vector3? ConstructionSpot;
		public ConstructCommand(uint buildingToConstruct, Vector3? constructionSpot=null)
		{
			BuildingToConstruct = buildingToConstruct;
			ConstructionSpot = constructionSpot;
		}
		public override bool Execute(Beholder bot)
		{
			if (Controller.CanConstruct(BuildingToConstruct))
			{
				Controller.Construct(bot.GetAvailableWorker(), BuildingToConstruct, ConstructionSpot);
				return true;
			}
			return false;
		}
	}
	public class ConstructGasCommand : Command
	{
		protected uint? BuildingToConstruct;
		protected Unit Geyser;
		public ConstructGasCommand(uint? buildingToConstruct = null, Unit geyser = null)
		{
			BuildingToConstruct = buildingToConstruct;
			Geyser = geyser;
		}
		public override bool Execute(Beholder bot)
		{
			if (BuildingToConstruct == null)
			{
				switch (bot.GetRace())
				{
					case SC2APIProtocol.Race.Zerg: BuildingToConstruct = Units.EXTRACTOR; break;
					case SC2APIProtocol.Race.Protoss: BuildingToConstruct = Units.REFINERY; break;
					case SC2APIProtocol.Race.Terran: BuildingToConstruct = Units.ASSIMILATOR; break;
					default: throw new NotImplementedException();
				}
			}
			if (Controller.CanConstruct(BuildingToConstruct.Value))
			{
				Controller.ConstructGas(bot.GetAvailableWorker(), BuildingToConstruct.Value, Geyser);
				return true;
			}
			return false;
		}
	}
}
