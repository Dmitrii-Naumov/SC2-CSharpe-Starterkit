using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
	public class Debut_12Pool : BuildOrder
	{
		public Debut_12Pool()
		{
			AbortCondition = new MinSupplyCondition(17);

			BO = new Queue<CommandWithCondition>();
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new ConstructSingleCommand(Units.SPAWNING_POOL)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.OVERLORD)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.ZERGLING)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new AttackCommand()));
		}
	}
}
