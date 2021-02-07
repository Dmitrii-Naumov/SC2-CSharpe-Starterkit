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

			BO = new Queue<CommandWithCondition>();
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new TalkCommand("17 Hatch debut")));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.OVERLORD)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new ExpandCommand()));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new ConstructCommand(Units.EXTRACTOR)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new ConstructCommand(Units.SPAWNING_POOL)));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.OVERLORD)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new UnitsCondition(Units.ZERGLING, 6), new AttackCommand()));
			BO.Enqueue(new CommandWithCondition(new UnitsCondition(Units.ZERGLING, 8), new AttackCommand()));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new TalkCommand("BO Completed")));
		}
	}
}
