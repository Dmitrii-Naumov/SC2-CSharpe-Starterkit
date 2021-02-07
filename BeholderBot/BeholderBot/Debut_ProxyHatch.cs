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
		public Debut_ProxyHatch()
		{
			AbortCondition = new MinSupplyCondition(25);

			BO = new Queue<CommandWithCondition>();
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new TalkCommand("Proxy Hatch debut")));

			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new ExtraDroneCommand()));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.OVERLORD)));
			BO.Enqueue(new CommandWithCondition(new EmptyCondition(), new BuildUnitCommand(Units.DRONE)));

		}
	}
}
