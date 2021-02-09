using SC2_Connector;

namespace BeholderBot
{
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
}
