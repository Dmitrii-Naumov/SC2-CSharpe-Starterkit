using SC2_Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderBot.Tasks
{
	internal class CheckForGG : GameplayTask
	{
		public override void Execute()
		{
			var structures = Controller.GetUnits(Units.Structures);
			if (structures.Count == 1)
			{
				//last building                
				if (structures[0].Integrity < 0.4) //being attacked or burning down                 
					if (!Controller.ChatLog.Contains("gg"))
						Controller.Chat("gg");
			}
		}
	}
}
