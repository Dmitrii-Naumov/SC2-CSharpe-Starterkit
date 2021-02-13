using SC2_Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderBot
{
	public class Debut_17Hatch : BuildOrder
	{
		public Debut_17Hatch()
		{
			AbortCondition = new MinSupplyCondition(25);

			BO = new Queue<Command>();
			BO.Enqueue(new TalkCommand("17 Hatch debut"));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new BuildUnitCommand(Units.OVERLORD));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));

			BO.Enqueue(new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));

			BO.Enqueue(new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new ExpandCommand());
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));

			BO.Enqueue(new ConstructGasCommand());
			BO.Enqueue(new ConstructCommand(Units.SPAWNING_POOL));

			BO.Enqueue(new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new BuildUnitCommand(Units.OVERLORD));
			BO.Enqueue(new BuildUnitCommand(Units.ZERGLING));
			BO.Enqueue(new BuildUnitCommand(Units.ZERGLING));
			BO.Enqueue(new BuildUnitCommand(Units.ZERGLING));
			BO.Enqueue(new BuildUnitCommand(Units.ZERGLING));
			BO.Enqueue(new AttackCommand().WithCondition(new UnitsCondition(Units.ZERGLING, 6)));
			BO.Enqueue(new AttackCommand().WithCondition(new UnitsCondition(Units.ZERGLING, 8)));
			BO.Enqueue(new TalkCommand("BO Completed"));
		}
	}
}
