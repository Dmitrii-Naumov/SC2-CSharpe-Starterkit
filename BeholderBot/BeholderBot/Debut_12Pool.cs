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

			BO = new Queue<CommandWithCondition>(); 
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new TalkCommand("12 Pool debut")));
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
