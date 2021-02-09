using SC2_Connector;
using System.Collections.Generic;
using System.Numerics;

namespace BeholderBot
{
	public class MoveUnitCommand : Command
	{
		private Unit Unit;
		private Vector3 Postition;
		public MoveUnitCommand(Unit unit, Vector3 postion)
		{
			Unit = unit;
			Postition = postion;
		}
		public override bool Execute(Beholder bot)
		{
			Controller.Move(new List<Unit>() { bot.GetAvailableWorker() }, Postition);
				return true;
		}
	}
}
