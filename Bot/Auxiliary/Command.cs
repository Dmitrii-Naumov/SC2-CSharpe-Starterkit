namespace Bot
{
	public abstract class Command
	{
		//public bool? ToExpand;
		public abstract bool Execute();
	}
	public class BuildUnitCommand : Command
	{
		private uint UnitToBuild;
		public BuildUnitCommand(uint unitToBuild)
		{
			UnitToBuild = unitToBuild;
		}
		public override bool Execute()
		{
			return Controller.BuildUnit(UnitToBuild);
		}
	}
	public class ExpandCommand : Command
	{

		public override bool Execute()
		{
			if (Controller.CanConstruct(Units.HATCHERY))
			{
				return Controller.Expand();
			}
			return false;
		}
	}
	public class ConstructSingleCommand : Command
	{
		private uint BuildingToConstruct;
		public ConstructSingleCommand(uint buildingToConstruct)
		{
			BuildingToConstruct = buildingToConstruct;
		}
		public override bool Execute()
		{
			if (Controller.GetTotalCount(BuildingToConstruct) < 1)
			{
				if (Controller.CanConstruct(BuildingToConstruct))
				{
					Controller.Construct(BuildingToConstruct);
					return true;
				}
			}
			return false;
		}
	}
	public class ConstructCommand : Command
	{
		private uint BuildingToConstruct;
		public ConstructCommand(uint buildingToConstruct)
		{
			BuildingToConstruct = buildingToConstruct;
		}
		public override bool Execute()
		{
			if (Controller.CanConstruct(BuildingToConstruct))
			{
				Controller.Construct(BuildingToConstruct);
				return true;
			}
			return false;
		}
	}
	public class AttackCommand : Command
	{
		public override bool Execute()
		{
			var army = Controller.GetUnits(Units.ArmyUnits);
			if (army.Count > 0)
			{
				if (Controller.enemyLocations.Count > 0)
				{
					Controller.Attack(army, Controller.enemyLocations[0]);
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
		public override bool Execute()
		{
			Controller.Chat(Message);
			return true;
		}
	}
}
