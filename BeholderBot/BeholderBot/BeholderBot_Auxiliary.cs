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


        private List<KeyValuePair<double, Vector3>> SortedExpandLocations;

        private List<KeyValuePair<double, Vector3>> GetSortedExpandLocationsForMe()
        {
            if (SortedExpandLocations == null)
            {
                SortedExpandLocations = new List<KeyValuePair<double, Vector3>>();
                foreach (var location in MapHelper.GetExpandLocations())
                {
                    double distance = MapHelper.GetPathDistance(location.Position, 
                        StartLocation + new Vector3(2, 2, 0));//need to offset start location since it is not pathable itself (we have a building there!)
                    if(distance!=-1)
                        SortedExpandLocations.Add(new KeyValuePair<double, Vector3>(distance, location.Position));
                }
            }
            SortedExpandLocations = SortedExpandLocations.OrderBy(_ => _.Key).ToList();
            return SortedExpandLocations;
        }

        private List<KeyValuePair<double, Vector3>> GetSortedExpandLocationsForEnemy()
        {
            List<KeyValuePair<double, Vector3>> result = new List<KeyValuePair<double, Vector3>>();
            foreach (var location in MapHelper.GetExpandLocations())
            {
                double distance = MapHelper.GetPathDistance(location.Position,
                    EnemyLocations[0] + new Vector3(2, 2, 0));//need to offset start location since it is not pathable itself (we have a building there!)
                if (distance != -1)
                    SortedExpandLocations.Add(new KeyValuePair<double, Vector3>(distance, location.Position));
            }
            result = result.OrderBy(_ => _.Key).ToList();
            return result;
        }

		public bool Expand()
        {
            int currentBases = Expands.Count();
            Unit worker = GetAvailableWorker();
            Vector3? expandPosition = GetSortedExpandLocationsForMe()[currentBases].Value;
            
            if (expandPosition != null)
            {
                if (Controller.Construct(GetAvailableWorker(), Units.HATCHERY, expandPosition)) 
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

        public bool Proxy()
        {
            Unit worker = GetAvailableWorker();
            Vector3? expandPosition = GetSortedExpandLocationsForEnemy()[1].Value;

            if (expandPosition != null)
            {
                if (Controller.Construct(GetAvailableWorker(), Units.HATCHERY, expandPosition))
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
