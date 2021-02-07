using SC2_Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderBot.Tasks
{
	internal class Inject : GameplayTask
	{
		public override void Execute()
		{
			foreach (var rc in Controller.GetHatcheries().Where(_ => !_.IsInjected))
			{
				foreach (var queen in Controller.GetUnits(Units.QUEEN))
				{
					if (queen.Energy >= 25 && queen.Orders.Count == 0)
					{
						if (Controller.IsInRange(queen.Position, new List<Unit>() { rc }, 5))
						{
							Controller.Inject(new List<Unit>() { queen }, rc);
							break;
						}
					}
				}
			}
		}
	}
}
