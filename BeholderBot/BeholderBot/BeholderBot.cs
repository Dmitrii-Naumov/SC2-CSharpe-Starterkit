using System.Collections.Generic;
using SC2APIProtocol;
using System.Linq;
using System.Numerics;
using SC2_Connector;
using Unit = SC2_Connector.Unit;
using BeholderBot.Tasks;

namespace BeholderBot
{
	public partial class Beholder : Bot
	{
		#region Constructor
		public Beholder()
		{
			ActiveTasks = new List<GameplayTask>();
			ASyncCommands = new List<Command>();
			RepetativeCommands = new List<Command>();
		}
		#endregion
		#region state
		public BuildOrder CurrentDebut = new Debut_ProxyHatch(); //new Debut_17Hatch(); // // new Debut_12Pool();
																//public Command CurrentPrimaryCommand =
																//public Command CurrentSecondaryCommand = 

		public Vector3 StartLocation;
		
		List<GameplayTask> ActiveTasks;
		public List<Command> ASyncCommands;
		public List<Command> RepetativeCommands;

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
			Expands = new List<Unit>();
			foreach (var hatch in Controller.GetHatcheries())
			{
				foreach (var expLocation in MapHelper.GetExpandLocations())
				{
					if (Controller.Distance(expLocation.Position, hatch) < 6)
					{
						Expands.Add(hatch);
					}
				}
			}
		}


		#endregion

		//the following will be called every frame
		//you can increase the amount of frames that get processed for each step at once in Wrapper/GameConnection.cs: stepSize  
		public void OnFrame()
		{
			Initialization();

			foreach (var task in ActiveTasks)
			{
				if (Controller.Frame % task.ExcecutionFrequencyDivider == 0)
					task.Execute();
			}
			foreach (var task in RepetativeCommands)
			{
				task.TryExecute(this);
			}

			foreach (var task in ASyncCommands)
			{
				if (task.TryExecute(this))
					ASyncCommands.Remove(task);
			}

			if (CurrentDebut.AbortConditionMet())
			{
				MidGameBehavior();
			}
			else
			{
				CurrentDebut.ExecuteBO(this);
			}

		}

		private void Initialization()
		{
			if (Controller.Frame == Controller.SecsToFrames(1))
			{
				SayGlHF();
				LogInfo();
				StartLocation = Controller.GetHatcheries().FirstOrDefault().Position;
				RefreshState();
				
				ActiveTasks.Add(new DistributeWorkers());
				ActiveTasks.Add(new DistributeOverlords());
				ActiveTasks.Add(new SpreadCreep());
				ActiveTasks.Add(new CheckForGG() { ExcecutionFrequencyDivider = 25 });
			}
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
		private void SayGlHF()
		{
			Controller.Chat("good luck and have fun");
		}

		private void LogInfo()
		{
			Logger.Info("BeholderBot");
			Logger.Info("--------------------------------------");
			Logger.Info("Map: {0}", MapHelper.GetMapName());
			Logger.Info("--------------------------------------");
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
		}

		private bool ShouldExpand()
		{
			return Controller.GetUnits(Units.DRONE).Count > 16;
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
	}
}