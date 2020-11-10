using System.Collections.Generic;
using SC2APIProtocol;

namespace Bot {
    internal class BeholderBot : Bot {
        
        //the following will be called every frame
        //you can increase the amount of frames that get processed for each step at once in Wrapper/GameConnection.cs: stepSize  
        public IEnumerable<Action> OnFrame()
		{
			Controller.OpenFrame();

			if (Controller.frame == 0)
			{
				Logger.Info("BeholderBot");
				Logger.Info("--------------------------------------");
				Logger.Info("Map: {0}", Controller.gameInfo.MapName);
				Logger.Info("--------------------------------------");
			}

			if (Controller.frame == Controller.SecsToFrames(1))
				Controller.Chat("good luck and have fun");

			IsItGG();
			Macro();



			//build up to 4 barracks at once
			if (Controller.CanConstruct(Units.SPAWNING_POOL))
				if (Controller.GetTotalCount(Units.SPAWNING_POOL) < 1)
					Controller.Construct(Units.SPAWNING_POOL);

			BuildArmy();

			//attack when we have enough units
			var army = Controller.GetUnits(Units.ArmyUnits);
			if (army.Count > 20)
			{
				if (Controller.enemyLocations.Count > 0)
					Controller.Attack(army, Controller.enemyLocations[0]);
			}

			return Controller.CloseFrame();
		}

		private static void BuildArmy()
		{
			BuildUnit(Units.ZERGLING);
		}

		private static void BuildUnit(uint unitType)
		{
			var larvae = Controller.GetUnits(Units.LARVA);
			foreach (var larva in larvae)
			{
				if (Controller.CanConstruct(unitType) && larva.orders.Count == 0)
					larva.Train(unitType);
			}
		}

		private static void Macro()
		{
			var resourceCenters = Controller.GetUnits(Units.ResourceCenters);

			var larvae = Controller.GetUnits(Units.LARVA);
			if(!IsEnoughDrones())
			BuildUnit(Units.DRONE);

			if (IsALotOfResources() && NotManyLarvae())
				BuildMacroHatch();

			if (Controller.maxSupply - Controller.currentSupply <= 5
				&& Controller.GetPendingCount(Units.OVERLORD)<1)
				BuildUnit(Units.OVERLORD);


			//distribute workers optimally every 10 frames
			if (Controller.frame % 10 == 0)
				Controller.DistributeWorkers();
		}

		private static void BuildMacroHatch()
		{
			Controller.Construct(Units.HATCHERY);
		}

		private static bool NotManyLarvae()
		{
			if (Controller.GetUnits(Units.LARVA).Count < 3)
				return true;
			return false;
		}

		private static bool IsALotOfResources()
		{
			if (Controller.minerals > 1000)
				return true;
			return false;
		}

		private static bool IsEnoughDrones()
		{
			return Controller.GetUnits(Units.DRONE).Count > 21;
				
		}

		private static void IsItGG()
		{
			var structures = Controller.GetUnits(Units.Structures);
			if (structures.Count == 1)
			{
				//last building                
				if (structures[0].integrity < 0.4) //being attacked or burning down                 
					if (!Controller.chatLog.Contains("gg"))
						Controller.Chat("gg");
			}
		}
	}
}