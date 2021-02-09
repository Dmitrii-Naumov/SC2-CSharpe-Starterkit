using SC2_Connector;

namespace BeholderBot
{
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
