using SC2_Connector;

namespace BeholderBot
{
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
}
