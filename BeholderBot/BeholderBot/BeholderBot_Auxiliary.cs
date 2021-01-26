using SC2_Connector;
using SC2APIProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static SC2_Connector.Controller;
using Unit = SC2_Connector.Unit;

namespace BeholderBot
{
	public partial class Beholder : Bot
	{
		public void RefreshState()
		{
			RefreshHatcheries();
		}

		#region Drones Management
		public void DistributeWorkers()
        {
            //TODO priority saturation gas vs minerals
            //consider long distance mining
            // 3 workers can be put on crystals that are further and 2 should be on closer ones
            // only mine from crystals/geysers that are safe

            var workers = Controller.GetUnits(Units.Workers);
            List<Unit> idleWorkers = new List<Unit>();
            foreach (var worker in workers)
            {
                if (worker.Order.AbilityId != 0) continue;
                idleWorkers.Add(worker);
            }

            if (idleWorkers.Count > 0)
            {
                var resourceCenters = GetUnits(Units.ResourceCenters, onlyCompleted: true);
                var mineralFields = GetUnits(Units.MineralFields, onlyVisible: true, alliance: Alliance.Neutral);

                foreach (var rc in resourceCenters)
                {
                    //get one of the closer mineral fields
                    var mf = GetFirstInRange(rc.Position, mineralFields, 7);
                    if (mf == null) continue;

                    //only one at a time
                    Logger.Info("Distributing idle worker: {0}", idleWorkers[0].Tag);
                    Controller.Smart(idleWorkers[0], mf);
                    return;
                }
                //nothing to be done
                return;
            }
            else
            {
                //let's see if we can distribute between bases                
                var resourceCenters = GetUnits(Units.ResourceCenters, onlyCompleted: true);
                Unit transferFrom = null;
                Unit transferTo = null;
                foreach (var rc in resourceCenters)
                {
                    if (rc.AssignedWorkers <= rc.IdealWorkers)
                        transferTo = rc;
                    else
                        transferFrom = rc;
                }

                if ((transferFrom != null) && (transferTo != null))
                {
                    var mineralFields = GetUnits(Units.MineralFields, onlyVisible: true, alliance: Alliance.Neutral);

                    var sqrDistance = 7 * 7;
                    foreach (var worker in workers)
                    {
                        if (worker.Order.AbilityId != Abilities.GATHER_MINERALS) continue;
                        if (Vector3.DistanceSquared(worker.Position, transferFrom.Position) > sqrDistance) continue;

                        var mf = GetFirstInRange(transferTo.Position, mineralFields, 7);
                        if (mf == null) continue;

                        //only one at a time
                        Logger.Info("Distributing idle worker: {0}", worker.Tag);
                        Controller.Smart(worker, mf);
                        return;
                    }
                }
            }
        }

        public Unit GetAvailableWorker(Vector3? targetPosition = null)
        {
            var workers = GetUnits(Units.Workers);
            foreach (var worker in workers)
            {
                // TODO: select closer worker 
                // TODO: select worker who is not currently gathering/carrying mineral/scouting

                //  if (worker.order.AbilityId != Abilities.GATHER_MINERALS) continue;

                return worker;
            }

            return null;
        }
        #endregion
        public bool Expand()
        {
            double mindistance = 99999999;
            double minAlloweddistance = 10;
            Vector3? expandPosition = null;
            foreach (var location in CurrentMap.GetExpandLocations())
            {
                double distance = GetPathDistance(location, GetHatcheries()[0].Position);
                bool alreadyHaveHatch = false;
                foreach (var hatch in GetHatcheries())
                {
                    if (GetPathDistance(location, hatch.Position) < minAlloweddistance)
                    {
                        alreadyHaveHatch = true;
                        break;
                    }
                }

                if (distance < mindistance && !alreadyHaveHatch)
                {
                    mindistance = distance;
                    expandPosition = location;
                }
            }
            if (expandPosition != null)
            {
                if (Controller.Construct(GetAvailableWorker(), Units.HATCHERY, expandPosition)) ;
                {
                    Logger.Info("Expanding");
                    return true;
                }
                return false;
            }
            else
            {
                Logger.Error("All expands are already taken");
                return false;
            }

        }

    }
}
