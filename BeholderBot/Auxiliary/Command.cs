using SC2_Connector;
using System;

namespace BeholderBot
{
	public abstract class Command
	{
		//public bool? ToExpand;
		public abstract bool Execute(Beholder bot);
	}
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
	public class ExtraDroneCommand : Command
	{
		private uint UnitToBuild;

		public override bool Execute(Beholder bot)
		{
			throw new NotImplementedException();
			return Controller.BuildUnit(Units.DRONE);
		}
	}
	public class ExpandCommand : Command
	{
		public override bool Execute(Beholder bot)
		{
			if (Controller.CanConstruct(Units.HATCHERY))
			{
				return bot.Expand();
			}
			return false;
		}
	}
	public class ProxyHatchCommand : Command
	{
		public override bool Execute(Beholder bot)
		{
			if (Controller.CanConstruct(Units.HATCHERY))
			{
				return bot.Proxy();
			}
			return false;
		}
	}

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
	public class AttackCommand : Command
	{
		public override bool Execute(Beholder bot)
		{
			var army = Controller.GetUnits(Units.ArmyUnits);
			if (army.Count > 0)
			{
				if (Controller.EnemyLocations.Count > 0)
				{
					Controller.Attack(army, Controller.EnemyLocations[0]);
					return true;
				}
			}
			return false;
		}
	}
	public class TalkCommand : Command
	{
		private string Message;
		public TalkCommand(string message)
		{
			Message = message;
		}
		public override bool Execute(Beholder bot)
		{
			Controller.Chat(Message);
			return true;
		}
	}
}
