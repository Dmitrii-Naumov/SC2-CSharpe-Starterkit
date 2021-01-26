using System.Collections.Generic;
using SC2APIProtocol;
using System.Linq;
using System.Numerics;
using SC2_Connector;
using Unit = SC2_Connector.Unit;

namespace BeholderBot
{
	public partial class Beholder : Bot
	{
		#region Constructor
		public Beholder()
		{
			ActiveTasks = new List<GameplayTask>();
		}
		#endregion
		#region state
		public MapInfo CurrentMap = new MapInfo();
		public BuildOrder CurrentDebut = new Debut_17Hatch(); // new Debut_ProxyHatch();// new Debut_12Pool();
															  //public Command CurrentPrimaryCommand =
															  //public Command CurrentSecondaryCommand = 

		List<GameplayTask> ActiveTasks;

		//Main Base is base[0]
		//List of bases
		List<Unit> Expands;

		//List of Macro Hatcheries
		List<Unit> MacroHatches;

		//List of Proxy Hatcheries
		List<Unit> ProxyHatches;

		/// <summary>
		/// Defines if mining vespen a priority right now.  
		/// </summary>
		/// 
		VespenPriority VespenMining;

		public Race GetRace()
		{
			return Race.Zerg;
		}
		#endregion

		#region Methods



		//Updates List of hatcheries
		public void RefreshHatcheries()
		{
			foreach (var hatch in Controller.GetHatcheries())
			{
				foreach (var expLocation in CurrentMap.GetExpandLocations())
					if (Controller.IsInRange(expLocation, hatch, 2))
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

			foreach (var task in ActiveTasks)
			{
				task.Execute();
			}
			LogInfo();
			Talk();
			IsItGG();

			if (CurrentDebut.AbortConditionMet())
			{
				MidGameBehavior();
			}
			else
			{
				CurrentDebut.ExecuteBO(this);
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

		private void Atack()
		{
			//attack when we have enough units
			var army = Controller.GetUnits(Units.ArmyUnits);
			if (army.Count > 20)
			{
				if (Controller.EnemyLocations.Count > 0)
					Controller.Attack(army, Controller.EnemyLocations[0]);
			}
		}

		private void TechUp()
		{
			if (Controller.CanConstruct(Units.SPAWNING_POOL))
				if (Controller.GetTotalCount(Units.SPAWNING_POOL) < 1)
					Controller.Construct(GetAvailableWorker(), Units.SPAWNING_POOL);
		}

		private void Talk()
		{
			if (Controller.Frame == Controller.SecsToFrames(1))
				Controller.Chat("good luck and have fun");
		}

		private void LogInfo()
		{
			if (Controller.Frame == 0)
			{
				Logger.Info("BeholderBot");
				Logger.Info("--------------------------------------");
				Logger.Info("Map: {0}", Controller.GetMapName());
				Logger.Info("--------------------------------------");
			}
		}

		private void BuildArmy()
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
			if (Controller.Frame % 11 == 0)
			{
				if (ShouldExpand() && Controller.CanAfford(Units.HATCHERY))
				{
					Expand();
				}
			}

			if (IsALotOfResources() && NotManyLarvae())
				BuildMacroHatch();

			if (Controller.Frame % 7 == 0
				&& Controller.MaxSupply - Controller.CurrentSupply <= 5
				&& Controller.GetPendingCount(Units.OVERLORD) < 1)
				Controller.BuildUnit(Units.OVERLORD);


			//distribute workers optimally every 10 frames
			if (Controller.Frame % 10 == 0)
				DistributeWorkers();

			if (Controller.Frame % 10 == 0)
				DistributeOverlords();
		}

		private bool ShouldExpand()
		{
			return Controller.GetUnits(Units.DRONE).Count > 16;
		}

		private void SpreadCreep()
		{
			//foreach (var queen in Controller.GetUnits(Units.QUEEN))
			//{
			//	if (queen.Energy >= 25 && queen.Orders.Count == 0)
			//	{
			//		queen
			//	}
			//}
		}

		private void DistributeOverlords()
		{
			//send scouting unless it is dangerous. If it is dangerous, keep near spores
		}

		private void Inject()
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

		private bool IsEnoughQueens()
		{
			return Controller.GetUnits(Units.QUEEN).Count >
				Controller.GetHatcheries().Count + 2;
		}

		private void BuildMacroHatch()
		{
			Controller.Construct(GetAvailableWorker(), Units.HATCHERY);
		}

		private bool NotManyLarvae()
		{
			if (Controller.GetUnits(Units.LARVA).Count < 3)
				return true;
			return false;
		}

		private bool IsALotOfResources()
		{
			if (Controller.Minerals > 1000)
				return true;
			return false;
		}

		private bool IsEnoughDrones()
		{
			return Controller.GetUnits(Units.DRONE).Count > 21;

		}

		private void IsItGG()
		{
			var structures = Controller.GetUnits(Units.Structures);
			if (structures.Count == 1)
			{
				//last building                
				if (structures[0].Integrity < 0.4) //being attacked or burning down                 
					if (!Controller.ChatLog.Contains("gg"))
						Controller.Chat("gg");
			}
		}
	}
}