using SC2_Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderBot
{
	public class Debut_12Pool : BuildOrder
	{
		public Debut_12Pool()
		{
			AbortCondition = new MinSupplyCondition(19);

			BO = new Queue<Command>(); 
			BO.Enqueue(new TalkCommand("12 Pool debut"));
			BO.Enqueue(new ConstructCommand(Units.SPAWNING_POOL));
			BO.Enqueue( new BuildUnitCommand(Units.DRONE));
			BO.Enqueue( new BuildUnitCommand(Units.DRONE));
			BO.Enqueue( new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new BuildUnitCommand(Units.OVERLORD));
			BO.Enqueue(new BuildUnitCommand(Units.ZERGLING));
			BO.Enqueue( new BuildUnitCommand(Units.ZERGLING));
			BO.Enqueue( new BuildUnitCommand(Units.ZERGLING));
			BO.Enqueue( new BuildUnitCommand(Units.ZERGLING));
			BO.Enqueue(new AttackCommand().WithCondition(new UnitsCondition(Units.ZERGLING, 6)));
			BO.Enqueue(new AttackCommand().WithCondition(new UnitsCondition(Units.ZERGLING, 8)));
			BO.Enqueue(new TalkCommand("BO Completed"));
		}
	}
}
