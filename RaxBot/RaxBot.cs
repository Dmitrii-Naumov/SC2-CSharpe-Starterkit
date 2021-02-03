using SC2_Connector;
using SC2APIProtocol;
using System.Collections.Generic;
using System.Numerics;
using Unit = SC2_Connector.Unit;

namespace RaxBot
{
    public class RaxBot : Bot
    {
		public Race GetRace()
		{
            return Race.Terran;
		}

		//the following will be called every frame
		//you can increase the amount of frames that get processed for each step at once in Wrapper/GameConnection.cs: stepSize  
		public void OnFrame()
        {
            if (Controller.Frame == 0)
            {
                Logger.Info("RaxBot");
                Logger.Info("--------------------------------------");
                Logger.Info("Map: {0}", MapHelper.GetMapName());
                Logger.Info("--------------------------------------");
            }

            if (Controller.Frame == Controller.SecsToFrames(1))
                Controller.Chat("gl hf");

            var structures = Controller.GetUnits(Units.Structures);
            if (structures.Count == 1)
            {
                //last building                
                if (structures[0].Integrity < 0.4) //being attacked or burning down                 
                    if (!Controller.ChatLog.Contains("gg"))
                        Controller.Chat("gg");
            }

            var resourceCenters = Controller.GetUnits(Units.ResourceCenters);
            foreach (var rc in resourceCenters)
            {
                if (Controller.CanConstruct(Units.SCV))
                    Controller.Train(rc, Units.SCV);
            }


            //keep on buildings depots if supply is tight
            if (Controller.MaxSupply - Controller.CurrentSupply <= 5)
                if (Controller.CanConstruct(Units.SUPPLY_DEPOT))
                    if (Controller.GetPendingCount(Units.SUPPLY_DEPOT) == 0)
                        Controller.Construct(GetAvailableWorker(), Units.SUPPLY_DEPOT);


            //distribute workers optimally every 10 frames
            if (Controller.Frame % 10 == 0)
                DistributeWorkers();



            //build up to 4 barracks at once
            if (Controller.CanConstruct(Units.BARRACKS))
                if (Controller.GetTotalCount(Units.BARRACKS) < 4)
                    Controller.Construct(GetAvailableWorker(), Units.BARRACKS);

            //train marine
            foreach (var barracks in Controller.GetUnits(Units.BARRACKS, onlyCompleted: true))
            {
                if (Controller.CanConstruct(Units.MARINE))
                    Controller.Train(barracks, Units.MARINE);
            }

            //attack when we have enough units
            var army = Controller.GetUnits(Units.ArmyUnits);
            if (army.Count > 20)
            {
                if (Controller.EnemyLocations.Count > 0)
                    Controller.Attack(army, Controller.EnemyLocations[0]);
            }

        }
		#region Useful Methods
		public static Unit GetAvailableWorker()
        {
            var workers = Controller.GetUnits(Units.Workers);
            foreach (var worker in workers)
            {
                if (worker.Order.AbilityId != Abilities.GATHER_MINERALS) continue;

                return worker;
            }

            return null;
        }
        public static void DistributeWorkers()
        {
            var workers = Controller.GetUnits(Units.Workers);
            List<Unit> idleWorkers = new List<Unit>();
            foreach (var worker in workers)
            {
                if (worker.Order.AbilityId != 0) continue;
                idleWorkers.Add(worker);
            }

            if (idleWorkers.Count > 0)
            {
                var resourceCenters = Controller.GetUnits(Units.ResourceCenters, onlyCompleted: true);
                var mineralFields = Controller.GetUnits(Units.MineralFields, onlyVisible: true, alliance: Alliance.Neutral);

                foreach (var rc in resourceCenters)
                {
                    //get one of the closer mineral fields
                    var mf = Controller.GetFirstInRange(rc.Position, mineralFields, 7);
                    if (mf == null) continue;

                    //only one at a time
                    Logger.Info("Distributing idle worker: {0}", idleWorkers[0].Tag);
                   Controller.Smart( idleWorkers[0],mf);
                    return;
                }
                //nothing to be done
                return;
            }
            else
            {
                //let's see if we can distribute between bases                
                var resourceCenters = Controller.GetUnits(Units.ResourceCenters, onlyCompleted: true);
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
                    var mineralFields = Controller.GetUnits(Units.MineralFields, onlyVisible: true, alliance: Alliance.Neutral);

                    var sqrDistance = 7 * 7;
                    foreach (var worker in workers)
                    {
                        if (worker.Order.AbilityId != Abilities.GATHER_MINERALS) continue;
                        if (Vector3.DistanceSquared(worker.Position, transferFrom.Position) > sqrDistance) continue;

                        var mf = Controller.GetFirstInRange(transferTo.Position, mineralFields, 7);
                        if (mf == null) continue;

                        //only one at a time
                        Logger.Info("Distributing idle worker: {0}", worker.Tag);
                        Controller.Smart(worker, mf);
                        return;
                    }
                }
            }
        }
        #endregion
    }
}