using SC2_Connector;

namespace BeholderBot
{
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
}
