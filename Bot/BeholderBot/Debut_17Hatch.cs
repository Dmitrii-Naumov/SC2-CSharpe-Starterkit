using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
	public class Debut_17Hatch : BuildOrder
	{
		public Debut_17Hatch()
		{
			AbortCondition = new MinSupplyCondition(25);

			BO = new Queue<CommandWithCondition>();
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.OVERLORD)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new ConstructSingleCommand(Units.SPAWNING_POOL)));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new ConstructSingleCommand(Units.SPAWNING_POOL)));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new UnitsCondition(Units.ZERGLING, 6), new AttackCommand()));
			BO.Enqueue(new CommandWithCondition(new UnitsCondition(Units.ZERGLING, 8), new AttackCommand()));
		}
	}
}
