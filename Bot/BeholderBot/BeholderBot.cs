using System.Collections.Generic;
using SC2APIProtocol;
using System.Linq;
using System.Numerics;

namespace Bot {
    public partial class BeholderBot : Bot 
	{


		#region state

		public BuildOrder CurrentDebut = new Debut_17Hatch(); // new Debut_ProxyHatch();// new Debut_12Pool();
															  //public Command CurrentPrimaryCommand =
															  //public Command CurrentSecondaryCommand = 

		//Main Base is base[0]
		//List of bases
		List<Unit> Expands;

		//List of Macro Hatcheries
		List<Unit> MacroHatches;

		//List of Proxy Hatcheries
		List<Unit> ProxyHatches;

		#endregion

		#region Methods

		public void RefreshState()
		{
			RefreshHatcheries();
		}

		//Updates List of hatcheries
		public void RefreshHatcheries()
		{
			foreach (var hatch in Controller.GetHatcheries())
			{
				foreach (var expLocation in Controller.GetExpandLocations())
					if (Controller.IsInRangeOfResource(expLocation, hatch.Position))
					{
					}
			}
		}


		#endregion

		//the following will be called every frame
		//you can increase the amount of frames that get processed for each step at once in Wrapper/GameConnection.cs: stepSize  
		public IEnumerable<Action> OnFrame()
		{
			Controller.OpenFrame();

			LogInfo();
			Talk();
			IsItGG();

			if (CurrentDebut.AbortConditionMet())
			{
				MidGameBehavior();
			}
			else
			{
				CurrentDebut.ExecuteBO();
			}

			return Controller.CloseFrame();
		}

		private void MidGameBehavior()
		{
			Macro();
			TechUp();
			BuildArmy();
			Atack();
		}

		private static void Atack()
		{
			//attack when we have enough units
			var army = Controller.GetUnits(Units.ArmyUnits);
			if (army.Count > 20)
			{
				if (Controller.enemyLocations.Count > 0)
					Controller.Attack(army, Controller.enemyLocations[0]);
			}
		}

		private static void TechUp()
		{
			if (Controller.CanConstruct(Units.SPAWNING_POOL))
				if (Controller.GetTotalCount(Units.SPAWNING_POOL) < 1)
					Controller.Construct(Units.SPAWNING_POOL);
		}

		private static void Talk()
		{
			if (Controller.frame == Controller.SecsToFrames(1))
				Controller.Chat("good luck and have fun");
		}

		private static void LogInfo()
		{
			if (Controller.frame == 0)
			{
				Logger.Info("BeholderBot");
				Logger.Info("--------------------------------------");
				Logger.Info("Map: {0}", Controller.gameInfo.MapName);
				Logger.Info("--------------------------------------");
			}
		}

		private static void BuildArmy()
		{
			Controller.BuildUnit(Units.ZERGLING);
		}

		private void Macro()
		{
			if (!IsEnoughDrones())
				Controller.BuildUnit(Units.DRONE);

			if (!IsEnoughQueens())
				Controller.BuildUnit(Units.QUEEN);

			Inject();
			SpreadCreep();
			if (Controller.frame % 11 == 0)
			{
				if (ShouldExpand() && Controller.CanAfford(Units.HATCHERY))
				{
					Controller.Expand();
				}
			}

			if (IsALotOfResources() && NotManyLarvae())
				BuildMacroHatch();

			if (Controller.frame % 7 == 0
				&& Controller.maxSupply - Controller.currentSupply <= 5
				&& Controller.GetPendingCount(Units.OVERLORD) < 1)
				Controller.BuildUnit(Units.OVERLORD);


			//distribute workers optimally every 10 frames
			if (Controller.frame % 10 == 0)
				Controller.DistributeWorkers();

			if (Controller.frame % 10 == 0)
				DistributeOverlords();
		}

		private static bool ShouldExpand()
		{
			return Controller.GetUnits(Units.DRONE).Count > 16;
		}

		private static void SpreadCreep()
		{
			//foreach (var queen in Controller.GetUnits(Units.QUEEN))
			//{
			//	if (queen.Energy >= 25 && queen.Orders.Count == 0)
			//	{
			//		queen
			//	}
			//}
		}

		private static void DistributeOverlords()
		{
			//send scouting unless it is dangerous. If it is dangerous, keep near spores
		}

		private static void Inject()
		{
			foreach (var rc in Controller.GetHatcheries().Where(_ => !_.IsInjected))
			{
				foreach (var queen in Controller.GetUnits(Units.QUEEN))
				{
					if (queen.Energy >= 25 && queen.Orders.Count == 0)
					{
						if (Controller.IsInRange(queen.Position, new List<Unit>() { rc }, 5))
						{
							Controller.Inject(new List<Unit>() { queen }, rc);
							break;
						}
					}
				}
			}
		}

		private static bool IsEnoughQueens()
		{
			return Controller.GetUnits(Units.QUEEN).Count >
				Controller.GetHatcheries().Count + 2;
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
				if (structures[0].Integrity < 0.4) //being attacked or burning down                 
					if (!Controller.chatLog.Contains("gg"))
						Controller.Chat("gg");
			}
		}
	}
}