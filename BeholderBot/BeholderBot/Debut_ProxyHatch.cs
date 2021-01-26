using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeholderBot
{
	//public class Debut_ProxyHatch : BuildOrder
	//{
	//	public override bool AbortConditionMet()
	//	{
	//		return Controller.currentSupply > 18;
	//	}

	//	public override void ExecuteBO()
	//	{
	//		if (Controller.GetTotalCount(Units.DRONE) == 13 && Controller.GetPendingCount(Units.OVERLORD) < 1)
	//		{
	//			Controller.BuildUnit(Units.OVERLORD);
	//		}
	//		Controller.BuildUnit(Units.DRONE);
	//		if (Controller.currentSupply==14 && Controller.GetPendingCount(Units.DRONE)==0)
	//		{
	//			Unit proxyDrone = Controller.GetAvailableWorker(new System.Numerics.Vector3());
	//			if (proxyDrone.unitType == Units.DRONE)
	//			{
	//				proxyDrone.Move(Controller.enemyLocations.FirstOrDefault());
	//			}
	//		}
	//	}
	//}
}
