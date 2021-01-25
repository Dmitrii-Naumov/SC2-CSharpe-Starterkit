using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;
using Bot.Auxiliary;
using SC2APIProtocol;
using Action = SC2APIProtocol.Action;

namespace Bot {
    public static class Controller {
		
        #region Implementation
		//editable
		private static readonly int frameDelay = 0; //too fast? increase this to e.g. 20

        //don't edit
        private static readonly List<Action> actions = new List<Action>();
        private static readonly Random random = new Random();
        private const double FRAMES_PER_SECOND = 22.4;

        public static ResponseGameInfo gameInfo;
        public static ResponseData gameData;
        public static ResponseObservation obs;
        public static ulong frame;
        public static uint currentSupply;
        public static uint maxSupply;
        public static uint minerals;
        public static uint vespene;

        public static readonly List<Vector3> enemyLocations = new List<Vector3>();
        public static readonly List<string> chatLog = new List<string>();


        public static void OpenFrame()
        {
            if (gameInfo == null || gameData == null || obs == null)
            {
                if (gameInfo == null)
                    Logger.Info("GameInfo is null! The application will terminate.");
                else if (gameData == null)
                    Logger.Info("GameData is null! The application will terminate.");
                else
                    Logger.Info("ResponseObservation is null! The application will terminate.");
                Pause();
                Environment.Exit(0);
            }

            actions.Clear();

            foreach (var chat in obs.Chat)
                chatLog.Add(chat.Message);

            frame = obs.Observation.GameLoop;
            currentSupply = obs.Observation.PlayerCommon.FoodUsed;
            maxSupply = obs.Observation.PlayerCommon.FoodCap;
            minerals = obs.Observation.PlayerCommon.Minerals;
            vespene = obs.Observation.PlayerCommon.Vespene;

            //initialization
            if (frame == 0)
            {
                var resourceCenters = GetUnits(Units.ResourceCenters);
                if (resourceCenters.Count > 0)
                {
                    var rcPosition = resourceCenters[0].Position;

                    foreach (var startLocation in gameInfo.StartRaw.StartLocations)
                    {
                        var enemyLocation = new Vector3(startLocation.X, startLocation.Y, 0);
                        var distance = Vector3.Distance(enemyLocation, rcPosition);
                        if (distance > 30)
                            enemyLocations.Add(enemyLocation);
                    }
                }
            }

            if (frameDelay > 0)
                Thread.Sleep(frameDelay);
        }

        public static List<Action> CloseFrame()
        {
            return actions;
        }

        private static Action CreateRawUnitCommand(int ability)
        {
            var action = new Action();
            action.ActionRaw = new ActionRaw();
            action.ActionRaw.UnitCommand = new ActionRawUnitCommand();
            action.ActionRaw.UnitCommand.AbilityId = ability;
            return action;
        }

        private static Point2D VectorToPoint(Vector3 vector)
        {
            var point= new Point2D();
            point.X = vector.X;
            point.Y = vector.Y;
            return point;
        }

        private static void AddUnitTagsToAction(List<Unit> units, Action action)
        {
            foreach (var unit in units)
                action.ActionRaw.UnitCommand.UnitTags.Add(unit.Tag);
        }


        private static void AddAction(Action action)
        {
            actions.Add(action);
        }

        #region Gameplay Specific Details
        private static int GetEggAbility(uint unitType)
        {
            switch (unitType)
            {
                //T1
                case Units.DRONE: return Abilities.LARVATRAIN_DRONE;
                case Units.OVERLORD: return Abilities.LARVATRAIN_OVERLORD;
                case Units.ZERGLING: return Abilities.LARVATRAIN_ZERGLING;
                case Units.ROACH: return Abilities.LARVATRAIN_ROACH;

                //T2
                case Units.MUTALISK: return Abilities.LARVATRAIN_MUTALISK;
                case Units.HYDRALISK: return Abilities.LARVATRAIN_HYDRALISK;
                case Units.CORRUPTOR: return Abilities.LARVATRAIN_ROACH;
                case Units.INFESTOR: return Abilities.LARVATRAIN_MUTALISK;
                case Units.SWARMHOSTMP: return Abilities.LARVATRAIN_SWARMHOST;

                //T3
                case Units.VIPER: return Abilities.LARVATRAIN_VIPER;
                case Units.ULTRALISK: return Abilities.LARVATRAIN_ULTRALISK;
                default: throw new NotImplementedException();
            }
        }
        private static bool IsTechAvailable(uint unitType)
        {
            switch (unitType)
            {
                case Units.DRONE:
                    return GetUnits(Units.LARVA, onlyCompleted: true).Count > 0;
                case Units.OVERLORD:
                    return GetUnits(Units.LARVA, onlyCompleted: true).Count > 0;
                case Units.ZERGLING:
                    return GetUnits(Units.SPAWNING_POOL, onlyCompleted: true).Count > 0;
                case Units.QUEEN:
                    return GetUnits(Units.SPAWNING_POOL, onlyCompleted: true).Count > 0;
                default: throw new NotImplementedException();
            }

        }
        private static List<Vector3> GetPointsInRadius(Vector3 value, int maxRadius)
        {
            List<Vector3> result = new List<Vector3>();
            for (int i = 0; i < maxRadius; i++)
            {
                for (int j = 0; j < maxRadius; j++)
                {
                    result.Add(new Vector3(value.X - (maxRadius / 2) + i, value.Y - (maxRadius / 2) + j, value.Z));
                }
            }
            return result;
        }
        #endregion
        #endregion

        #region Public Methods
        #region Not Gameplay Actions
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                //do nothing
            }
        }

        public static ulong SecsToFrames(int seconds)
        {
            return (ulong)(FRAMES_PER_SECOND * seconds);
        }

        public static void Chat(string message, bool team = false)
        {
            var actionChat = new ActionChat();
            actionChat.Channel = team ? ActionChat.Types.Channel.Team : ActionChat.Types.Channel.Broadcast;
            actionChat.Message = message;

            var action = new Action();
            action.ActionChat = actionChat;
            AddAction(action);
        }

        public static string GetUnitName(uint unitType)
        {
            return gameData.Units[(int)unitType].Name;
        }

        public static void FocusCamera(Vector3 Position)
        {
            var action = new Action();
            action.ActionRaw = new ActionRaw();
            action.ActionRaw.CameraMove = new ActionRawCameraMove();
            action.ActionRaw.CameraMove.CenterWorldSpace = new Point();
            action.ActionRaw.CameraMove.CenterWorldSpace.X = Position.X;
            action.ActionRaw.CameraMove.CenterWorldSpace.Y = Position.Y;
            action.ActionRaw.CameraMove.CenterWorldSpace.Z = Position.Z;
            Controller.AddAction(action);
        }
        #endregion

        #region Gameplay Actions
        #region Unit Commands
        public static void Move(List<Unit> units, Vector3 target)
        {
            var action = Controller.CreateRawUnitCommand(Abilities.MOVE);
            action.ActionRaw.UnitCommand.TargetWorldSpacePos = VectorToPoint(target);
            AddUnitTagsToAction(units, action);
            Controller.AddAction(action);
        }

        public static void Smart(List<Unit> units, Unit target)
        {
            var action = Controller.CreateRawUnitCommand(Abilities.SMART);
            action.ActionRaw.UnitCommand.TargetUnitTag = target.Tag;
            AddUnitTagsToAction(units, action);
            Controller.AddAction(action);
        }

        public static void Train(Unit producingStructure, uint unitType, bool queue = false)
        {
            if (!queue && producingStructure.Orders.Count > 0)
                return;

            var abilityID = Abilities.GetID(unitType);
            var action = Controller.CreateRawUnitCommand(abilityID);
            action.ActionRaw.UnitCommand.UnitTags.Add(producingStructure.Tag);
            Controller.AddAction(action);

            var targetName = Controller.GetUnitName(unitType);
            Logger.Info("Started training: {0}", targetName);
        }

        public static void Attack(List<Unit> units, Vector3 target)
		{
			var action = CreateRawUnitCommand(Abilities.ATTACK);

			action.ActionRaw.UnitCommand.TargetWorldSpacePos = VectorToPoint(target);
			AddUnitTagsToAction(units, action);
			AddAction(action);
		}

		public static void Inject(List<Unit> units, Unit target)
        {
            var action = CreateRawUnitCommand(Abilities.EFFECT_INJECTLARVA);
            action.ActionRaw.UnitCommand.TargetUnitTag = target.Tag;
            AddUnitTagsToAction(units, action);
            AddAction(action);
        }
        #endregion

        public static double GetPathDistance(Vector3 location, Vector3 position)
        {
            return Vector3.Distance(location, position);
        }

        public static int GetTotalCount(uint unitType)
        {
            var pendingCount = GetPendingCount(unitType, inConstruction: false);
            var constructionCount = GetUnits(unitType).Count;
            return pendingCount + constructionCount;
        }

        public static int GetPendingCount(uint unitType, bool inConstruction = true)
        {
            var workers = GetUnits(Units.Workers);
            var abilityID = Abilities.GetID(unitType);

            var counter = 0;

            //count workers that have been sent to build this structure
            foreach (var worker in workers)
            {
                if (worker.Order.AbilityId == abilityID)
                    counter += 1;
            }

            //count buildings that are already in construction
            if (inConstruction)
            {
                foreach (var unit in GetUnits(Units.EGG))
                    if (unit.Order.AbilityId == GetEggAbility(unitType))
                        counter += 1;
            }

            //count eggs that are already in construction
            if (inConstruction)
            {
                foreach (var unit in GetUnits(unitType))
                    if (unit.BuildProgress < 1)
                        counter += 1;
            }

            return counter;
        }

        public static List<Unit> GetHatcheries()
        {
            return Controller.GetUnits(new HashSet<uint>() { Units.HATCHERY, Units.LAIR, Units.HIVE });
        }

        /// <summary>
        /// Checks if there are available larvae and orders a larva to train the unit.
        /// Also checks <see cref="CanConstruct(uint)"/>
        /// </summary>
        /// <param name="unitType"></param>
        /// <param name="withLarva"></param>
        /// <returns></returns>
        public static bool BuildUnit(uint unitType, Unit withLarva = null)
        {
            if (!Controller.CanConstruct(unitType))
                return false;
            if (withLarva == null)
            {
                var larvae = Controller.GetUnits(Units.LARVA);
                foreach (var larva in larvae)
                {
                    if (larva.Orders.Count == 0)
                    {
                        withLarva = larva;
                    }
                }
            }
            if (withLarva != null)
            {
                withLarva.Train(unitType);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Unit GetUnitByTag(ulong unitTag)
        {
            foreach (var unit in obs.Observation.RawData.Units)
                if (unit.Tag == unitTag)
                {
                    return new Unit(unit);
                }
            return null;
        }

        public static List<Unit> GetUnits(HashSet<uint> hashset, Alliance alliance = Alliance.Self, bool onlyCompleted = false, bool onlyVisible = false)
        {
            //ideally this should be cached in the future and cleared at each new frame
            var units = new List<Unit>();
            foreach (var unit in obs.Observation.RawData.Units)
                if (hashset.Contains(unit.UnitType) && unit.Alliance == alliance)
                {
                    if (onlyCompleted && unit.BuildProgress < 1)
                        continue;

                    if (onlyVisible && (unit.DisplayType != DisplayType.Visible))
                        continue;

                    units.Add(new Unit(unit));
                }
            return units;
        }

        public static List<Unit> GetUnits(uint unitType, Alliance alliance = Alliance.Self, bool onlyCompleted = false, bool onlyVisible = false)
        {
            //ideally this should be cached in the future and cleared at each new frame
            var units = new List<Unit>();
            foreach (var unit in obs.Observation.RawData.Units)
                if (unit.UnitType == unitType && unit.Alliance == alliance)
                {
                    if (onlyCompleted && unit.BuildProgress < 1)
                        continue;

                    if (onlyVisible && (unit.DisplayType != DisplayType.Visible))
                        continue;

                    units.Add(new Unit(unit));
                }
            return units;
        }

        public static bool CanAfford(uint unitType)
        {
            var unitData = gameData.Units[(int)unitType];
            return (minerals >= unitData.MineralCost) && (vespene >= unitData.VespeneCost);
        }

        public static List<Unit> GetLarvae()
        {
            return Controller.GetUnits(Units.LARVA);
        }

        public static Unit GetClosestLarva(Vector3? targetPosition = null)
        {
            return Controller.GetUnits(Units.LARVA).FirstOrDefault();
        }

        public static bool BuildUnit(uint unitType)
        {
            if (Controller.CanConstruct(unitType))
            {
                if (unitType == Units.QUEEN)
                {
                    var rcs = Controller.GetUnits(
                        new HashSet<uint>() { Units.HATCHERY, Units.LAIR, Units.HIVE },
                        onlyCompleted: true);
                    foreach (var rc in rcs)
                    {
                        if (Controller.CanConstruct(unitType) && rc.Orders.Count == 0)
                        {
                            rc.Train(unitType);
                            return true;
                        }
                    }
                }
                else
                {
                    var larvae = Controller.GetUnits(Units.LARVA);
                    foreach (var larva in larvae)
                    {
                        if (Controller.CanConstruct(unitType) && larva.Orders.Count == 0)
                        {
                            larva.Train(unitType);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool CanConstruct(uint unitType)
        {
            //is it a structure?
            if (Units.Structures.Contains(unitType))
            {
                //we need worker for every structure
                if (GetUnits(Units.Workers).Count == 0) return false;

                //we need an RC for any structure
                var resourceCenters = GetUnits(Units.ResourceCenters, onlyCompleted: true);
                if (resourceCenters.Count == 0) return false;


                return CanAfford(unitType);
            }

            //it's an actual unit
            else
            {
                //do we have enough supply?
                var requiredSupply = Controller.gameData.Units[(int)unitType].FoodRequired;
                if (requiredSupply > (maxSupply - currentSupply))
                    return false;


                if (!IsTechAvailable(unitType))
                    return false;
            }
            return CanAfford(unitType);
        }

        public static bool CanPlace(uint unitType, Vector3 targetPos)
        {
            //Note: this is a blocking call! Use it sparingly, or you will slow down your execution significantly!
            var abilityID = Abilities.GetID(unitType);

            RequestQueryBuildingPlacement queryBuildingPlacement = new RequestQueryBuildingPlacement();
            queryBuildingPlacement.AbilityId = abilityID;
            queryBuildingPlacement.TargetPos = new Point2D();
            queryBuildingPlacement.TargetPos.X = targetPos.X;
            queryBuildingPlacement.TargetPos.Y = targetPos.Y;

            Request requestQuery = new Request();
            requestQuery.Query = new RequestQuery();
            requestQuery.Query.Placements.Add(queryBuildingPlacement);

            var result = Program.gc.SendQuery(requestQuery.Query);
            if (result.Result.Placements.Count > 0)
                return (result.Result.Placements[0].Result == ActionResult.Success);
            return false;
        }

        public static bool IsInRange(Vector3 targetPosition, List<Unit> units, float maxDistance)
        {
            return (GetFirstInRange(targetPosition, units, maxDistance) != null);
        }

        public static Unit GetFirstInRange(Vector3 targetPosition, List<Unit> units, float maxDistance)
        {
            //squared distance is faster to calculate
            var maxDistanceSqr = maxDistance * maxDistance;
            foreach (var unit in units)
            {
                if (Vector3.DistanceSquared(targetPosition, unit.Position) <= maxDistanceSqr)
                    return unit;
            }
            return null;
        }

        public static bool IsInRangeOfResource(Vector3 resourceFieldPosition, Vector3 unitPostion)
        {
            return Math.Round(unitPostion.Z) == Math.Round(resourceFieldPosition.Z)
                                    && Vector3.DistanceSquared(unitPostion, resourceFieldPosition) < SquaredDistanceExpandToResourceField;
        }

        public static bool Construct(uint unitType, Vector3? constructionSpot = null)
        {
            if (constructionSpot == null)
            {
                Vector3 startingSpot;
                var resourceCenters = GetUnits(Units.ResourceCenters);
                if (resourceCenters.Count > 0)
                    startingSpot = resourceCenters[0].Position;
                else
                {
                    Logger.Error("Unable to construct: {0}. No resource center was found.", GetUnitName(unitType));
                    return false;
                }


                const int radius = 12;

                //trying to find a valid construction spot
                var mineralFields = GetUnits(Units.MineralFields, onlyVisible: true, alliance: Alliance.Neutral);

                while (true)
                {
                    constructionSpot = new Vector3(startingSpot.X + random.Next(-radius, radius + 1), startingSpot.Y + random.Next(-radius, radius + 1), 0);

                    //avoid building in the mineral line
                    if (IsInRange(constructionSpot.Value, mineralFields, 5)) continue;

                    //check if the building fits
                    if (!CanPlace(unitType, constructionSpot.Value)) continue;

                    //ok, we found a spot
                    break;
                }
            }
            else
            {
                if (!CanPlace(unitType, constructionSpot.Value))
                {
                    int maxRadius = 11;

                    List<Vector3> points = GetPointsInRadius(constructionSpot.Value, maxRadius);
                    bool foundSpot = false;
                    foreach (var point in points)
                    {
                        if (CanPlace(unitType, point))
                        {
                            constructionSpot = point;
                            foundSpot = true;
                            break;
                        }
                    }
                    if (!foundSpot)
                    {
                        Logger.Error("Unable to construct a {0} building here", GetUnitName(unitType));
                        return false;
                    }
                }
            }

            var worker = GetAvailableWorker(constructionSpot.Value);
            if (worker == null)
            {
                Logger.Error("Unable to find worker to construct: {0}", GetUnitName(unitType));
                return false;
            }

            var abilityID = Abilities.GetID(unitType);
            var constructAction = CreateRawUnitCommand(abilityID);
            constructAction.ActionRaw.UnitCommand.UnitTags.Add(worker.Tag);
            constructAction.ActionRaw.UnitCommand.TargetWorldSpacePos = new Point2D();
            constructAction.ActionRaw.UnitCommand.TargetWorldSpacePos.X = constructionSpot.Value.X;
            constructAction.ActionRaw.UnitCommand.TargetWorldSpacePos.Y = constructionSpot.Value.Y;
            AddAction(constructAction);

            Logger.Info("Constructing: {0} @ {1} / {2}", GetUnitName(unitType), constructionSpot.Value.X, constructionSpot.Value.Y);
            return true;
        }
        #endregion
        #endregion
    }
}