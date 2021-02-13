using SC2_Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderBot
{
	public class Debut_ProxyHatch : BuildOrder
	{
		Unit ExtraExtractor;
		Unit Drone;
		public Debut_ProxyHatch()
		{
			AbortCondition = new MinSupplyCondition(25);

			BO = new Queue<Command>();
			BO.Enqueue(new TalkCommand("Proxy Hatch debut"));

			BO.Enqueue(new BuildUnitCommand(Units.DRONE));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));

			BO.Enqueue(new MoveUnitCommand(Drone, new System.Numerics.Vector3(50, 50, 0)));
			BO.Enqueue(new ConstructGasCommand());
			BO.Enqueue(new GetUnitCommand(Units.EXTRACTOR, ExtraExtractor));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));

			BO.Enqueue(new CancelBuildingCommand(ExtraExtractor));
			BO.Enqueue(new BuildUnitCommand(Units.OVERLORD));
			BO.Enqueue(new BuildUnitCommand(Units.DRONE));

		}
	}
}
