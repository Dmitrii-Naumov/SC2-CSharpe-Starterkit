﻿using System.Collections.Generic;
using System.Linq;
using static SC2_Connector.Extensions;

namespace SC2_Connector
{
    public static class Units
    {
		#region Unit IDs
		public const uint COLOSSUS = 4;
        public const uint TECHLAB = 5;
        public const uint REACTOR = 6;
        public const uint INFESTOR_TERRAN = 7;
        public const uint BANELING_COCOON = 8;
        public const uint BANELING = 9;
        public const uint MOTHERSHIP = 10;
        public const uint POINT_DEFENSE_DRONE = 11;
        public const uint CHANGELING = 12;
        public const uint CHANGELING_ZEALOT = 13;
        public const uint CHANGELING_MARINE_SHIELD = 14;
        public const uint CHANGELING_MARINE = 15;
        public const uint CHANGELING_ZERGLING_WINGS = 16;
        public const uint CHANGELING_ZERGLING = 17;
        public const uint COMMAND_CENTER = 18;
        public const uint SUPPLY_DEPOT = 19;
        public const uint REFINERY = 20;
        public const uint BARRACKS = 21;
        public const uint ENGINEERING_BAY = 22;
        public const uint MISSILE_TURRET = 23;
        public const uint BUNKER = 24;
        public const uint SENSOR_TOWER = 25;
        public const uint GHOST_ACADEMY = 26;
        public const uint FACTORY = 27;
        public const uint STARPORT = 28;
        public const uint ARMORY = 29;
        public const uint FUSION_CORE = 30;
        public const uint AUTO_TURRET = 31;
        public const uint SIEGE_TANK_SIEGED = 32;
        public const uint SIEGE_TANK = 33;
        public const uint VIKING_ASSAULT = 34;
        public const uint VIKING_FIGHTER = 35;
        public const uint COMMAND_CENTER_FLYING = 36;
        public const uint BARRACKS_TECHLAB = 37;
        public const uint BARRACKS_REACTOR = 38;
        public const uint FACTORY_TECHLAB = 39;
        public const uint FACTORY_REACTOR = 40;
        public const uint STARPORT_TECHLAB = 41;
        public const uint STARPORT_REACTOR = 42;
        public const uint FACTORY_FLYING = 43;
        public const uint STARPORT_FLYING = 44;
        public const uint SCV = 45;
        public const uint BARRACKS_FLYING = 46;
        public const uint SUPPLY_DEPOT_LOWERED = 47;
        public const uint MARINE = 48;
        public const uint REAPER = 49;
        public const uint WIDOW_MINE = 498;
        public const uint WIDOW_MINE_BURROWED = 500;
        public const uint LIBERATOR = 689;
        public const uint GHOST = 50;
        public const uint MARAUDER = 51;
        public const uint MULE = 268;
        public const uint THOR = 52;
        public const uint HELLION = 53;
        public const uint HELLBAT = 484;
        public const uint CYCLONE = 692;
        public const uint MEDIVAC = 54;
        public const uint BANSHEE = 55;
        public const uint RAVEN = 56;
        public const uint BATTLECRUISER = 57;
        public const uint NUKE = 58;
        public const uint NEXUS = 59;
        public const uint PYLON = 60;
        public const uint ASSIMILATOR = 61;
        public const uint GATEWAY = 62;
        public const uint FORGE = 63;
        public const uint FLEET_BEACON = 64;
        public const uint TWILIGHT_COUNSEL = 65;
        public const uint PHOTON_CANNON = 66;
        public const uint STARGATE = 67;
        public const uint TEMPLAR_ARCHIVE = 68;
        public const uint DARK_SHRINE = 69;
        public const uint ROBOTICS_BAY = 70;
        public const uint ROBOTICS_FACILITY = 71;
        public const uint CYBERNETICS_CORE = 72;
        public const uint ZEALOT = 73;
        public const uint STALKER = 74;
        public const uint ADEPT = 311;
        public const uint HIGH_TEMPLAR = 75;
        public const uint DARK_TEMPLAR = 76;
        public const uint SENTRY = 77;
        public const uint PHOENIX = 78;
        public const uint CARRIER = 79;
        public const uint VOID_RAY = 80;
        public const uint WARP_PRISM = 81;
        public const uint OBSERVER = 82;
        public const uint IMMORTAL = 83;
        public const uint PROBE = 84;
        public const uint INTERCEPTOR = 85;
        public const uint HATCHERY = 86;
        public const uint CREEP_TUMOR = 87;
        public const uint EXTRACTOR = 88;
        public const uint SPAWNING_POOL = 89;
        public const uint EVOLUTION_CHAMBER = 90;
        public const uint HYDRALISK_DEN = 91;
        public const uint SPIRE = 92;
        public const uint ULTRALISK_CAVERN = 93;
        public const uint INFESTATION_PIT = 94;
        public const uint NYDUS_NETWORK = 95;
        public const uint BANELING_NEST = 96;
        public const uint ROACH_WARREN = 97;
        public const uint SPINE_CRAWLER = 98;
        public const uint SPORE_CRAWLER = 99;
        public const uint LAIR = 100;
        public const uint HIVE = 101;
        public const uint GREATER_SPIRE = 102;
        public const uint EGG = 103;
        public const uint DRONE = 104;
        public const uint ZERGLING = 105;
        public const uint OVERLORD = 106;
        public const uint HYDRALISK = 107;
        public const uint MUTALISK = 108;
        public const uint ULTRALISK = 109;
        public const uint ROACH = 110;
        public const uint RAVAGERCOCOON = 687;
        public const uint RAVAGER = 688;
        public const uint RAVAGERBURROWED = 690;
        public const uint TRANSPORTOVERLORDCOCOON = 892;
        public const uint LURKEREGG = 910;
        public const uint LURKER = 911;
        public const uint INFESTOR = 111;
        public const uint CORRUPTOR = 112;
        public const uint BROOD_LORD_COCOON = 113;
        public const uint BROOD_LORD = 114;
        public const uint BANELING_BURROWED = 115;
        public const uint DRONE_BURROWED = 116;
        public const uint HYDRALISK_BURROWED = 117;
        public const uint ROACH_BURROWED = 118;
        public const uint ZERGLING_BURROWED = 119;
        public const uint INFESTOR_TERRAN_BURROWED = 120;
        public const uint QUEEN_BURROWED = 125;
        public const uint QUEEN = 126;
        public const uint INFESTOR_BURROWED = 127;
        public const uint OVERLORD_COCOON = 128;
        public const uint OVERSEER = 129;
        public const uint LOCUSTMP = 489;
        public const uint COLLAPSIBLEROCKTOWERDEBRIS = 490;

        public static uint DISRUPTOR = 694;
        public static uint DISRUPTOR_PHASED = 733;

        public const uint SWARMHOSTBURROWEDMP = 493;
        public const uint SWARMHOST = 494;
        public const uint ORACLE = 495;
        public const uint TEMPEST = 496;
        public const uint WARHOUND = 497;
        public const uint WIDOWMINE = 498;
        public const uint VIPER = 499;
        public const uint WIDOWMINEBURROWED = 500;
        public const uint LURKERMPEGG = 501;
        public const uint LURKERMP = 502;
        public const uint LURKERMPBURROWED = 503;
        public const uint LURKER_DEN = 504;
        public const uint PLANETARY_FORTRESS = 130;
        public const uint ULTRALISK_BURROWED = 131;
        public const uint ORBITAL_COMMAND = 132;
        public const uint WARP_GATE = 133;
        public const uint ORBITAL_COMMAND_FLYING = 134;
        public const uint FORCE_FIELD = 135;
        public const uint WARP_PRISM_PHASING = 136;
        public const uint CREEP_TUMOR_BURROWED = 137;
        public const uint CREEP_TUMOR_QUEEN = 138;
        public const uint SPINE_CRAWLER_UPROOTED = 139;
        public const uint SPORE_CRAWLER_UPROOTED = 140;
        public const uint ARCHON = 141;
        public const uint NYDUS_CANAL = 142;
        public const uint BROODLING_ESCORT = 143;
        public const uint RICH_MINERAL_FIELD = 146;
        public const uint RICH_MINERAL_FIELD_750 = 147;
        public const uint URSADON = 148;
        public const uint XEL_NAGA_TOWER = 149;
        public const uint INFESTED_TERRANS_EGG = 150;
        public const uint LARVA = 151;
        public const uint MINERAL_FIELD = 341;
        public const uint VESPENE_GEYSER = 342;
        public const uint SPACE_PLATFORM_GEYSER = 343;
        public const uint RICH_VESPENE_GEYSER = 344;
        public const uint MINERAL_FIELD_750 = 483;
        public const uint PROTOSS_VESPENE_GEYSER = 608;
        public const uint LAB_MINERAL_FIELD = 665;
        public const uint LAB_MINERAL_FIELD_750 = 666;
        public const uint PURIFIER_RICH_MINERAL_FIELD = 796;
        public const uint PURIFIER_RICH_MINERAL_FIELD_750 = 797;
        public const uint PURIFIER_VESPENE_GEYSER = 880;
        public const uint SHAKURAS_VESPENE_GEYSER = 881;
        public const uint PURIFIER_MINERAL_FIELD = 884;
        public const uint PURIFIER_MINERAL_FIELD_750 = 885;
        public const uint BATTLE_STATION_MINERAL_FIELD = 886;
        public const uint BATTLE_STATION_MINERAL_FIELD_750 = 887;
        #endregion

        public static readonly HashSet<uint> Zerg = new HashSet<uint> {
            INFESTOR_TERRAN,
            BANELING_COCOON,
            BANELING,
            CHANGELING,
            CHANGELING_ZEALOT,
            CHANGELING_MARINE_SHIELD,
            CHANGELING_MARINE,
            CHANGELING_ZERGLING_WINGS,
            CHANGELING_ZERGLING,
            HATCHERY,
            CREEP_TUMOR,
            EXTRACTOR,
            SPAWNING_POOL,
            EVOLUTION_CHAMBER,
            HYDRALISK_DEN,
            SPIRE,
            ULTRALISK_CAVERN,
            INFESTATION_PIT,
            NYDUS_NETWORK,
            BANELING_NEST,
            ROACH_WARREN,
            SPINE_CRAWLER,
            SPORE_CRAWLER,
            LAIR,
            HIVE,
            GREATER_SPIRE,
            EGG,
            DRONE,
            ZERGLING,
            OVERLORD,
            HYDRALISK,
            MUTALISK,
            ULTRALISK,
            ROACH,
            INFESTOR,
            CORRUPTOR,
            BROOD_LORD_COCOON,
            BROOD_LORD,
            BANELING_BURROWED,
            DRONE_BURROWED,
            HYDRALISK_BURROWED,
            ROACH_BURROWED,
            ZERGLING_BURROWED,
            INFESTOR_TERRAN_BURROWED,
            QUEEN_BURROWED,
            QUEEN,
            INFESTOR_BURROWED,
            OVERLORD_COCOON,
            OVERSEER,
            ULTRALISK_BURROWED,
            CREEP_TUMOR_BURROWED,
            CREEP_TUMOR_QUEEN,
            SPINE_CRAWLER_UPROOTED,
            SPORE_CRAWLER_UPROOTED,
            NYDUS_CANAL,
            BROODLING_ESCORT,
            LARVA,
            VIPER
        };

        public static readonly HashSet<uint> Terran = new HashSet<uint> {
            HELLBAT,
            LIBERATOR,
            WIDOW_MINE,
            WIDOW_MINE_BURROWED,
            CYCLONE,
            MULE,
            TECHLAB,
            REACTOR,
            POINT_DEFENSE_DRONE,
            COMMAND_CENTER,
            SUPPLY_DEPOT,
            REFINERY,
            BARRACKS,
            ENGINEERING_BAY,
            MISSILE_TURRET,
            BUNKER,
            SENSOR_TOWER,
            GHOST_ACADEMY,
            FACTORY,
            STARPORT,
            ARMORY,
            FUSION_CORE,
            AUTO_TURRET,
            SIEGE_TANK_SIEGED,
            SIEGE_TANK,
            VIKING_ASSAULT,
            VIKING_FIGHTER,
            COMMAND_CENTER_FLYING,
            BARRACKS_TECHLAB,
            BARRACKS_REACTOR,
            FACTORY_TECHLAB,
            FACTORY_REACTOR,
            STARPORT_TECHLAB,
            STARPORT_REACTOR,
            FACTORY_FLYING,
            STARPORT_FLYING,
            SCV,
            BARRACKS_FLYING,
            SUPPLY_DEPOT_LOWERED,
            MARINE,
            REAPER,
            GHOST,
            MARAUDER,
            THOR,
            HELLION,
            MEDIVAC,
            BANSHEE,
            RAVEN,
            BATTLECRUISER,
            NUKE,
            PLANETARY_FORTRESS,
            ORBITAL_COMMAND,
            ORBITAL_COMMAND_FLYING
        };

        public static readonly HashSet<uint> Protoss = new HashSet<uint> {
            ADEPT,
            COLOSSUS,
            MOTHERSHIP,
            NEXUS,
            PYLON,
            ASSIMILATOR,
            GATEWAY,
            FORGE,
            FLEET_BEACON,
            TWILIGHT_COUNSEL,
            PHOTON_CANNON,
            STARGATE,
            TEMPLAR_ARCHIVE,
            DARK_SHRINE,
            ROBOTICS_BAY,
            ROBOTICS_FACILITY,
            CYBERNETICS_CORE,
            ZEALOT,
            STALKER,
            HIGH_TEMPLAR,
            DARK_TEMPLAR,
            SENTRY,
            PHOENIX,
            CARRIER,
            VOID_RAY,
            WARP_PRISM,
            OBSERVER,
            IMMORTAL,
            PROBE,
            INTERCEPTOR,
            WARP_GATE,
            FORCE_FIELD,
            WARP_PRISM_PHASING,
            ARCHON,
            PROTOSS_VESPENE_GEYSER
        };

        public static readonly HashSet<uint> Structures = new HashSet<uint> {
            ARMORY,
            ASSIMILATOR,
            BANELING_NEST,
            BARRACKS,
            BARRACKS_FLYING,
            BARRACKS_REACTOR,
            BARRACKS_TECHLAB,
            BUNKER,
            COMMAND_CENTER,
            COMMAND_CENTER_FLYING,
            CYBERNETICS_CORE,
            DARK_SHRINE,
            ENGINEERING_BAY,
            EVOLUTION_CHAMBER,
            EXTRACTOR,
            FACTORY,
            FACTORY_FLYING,
            FACTORY_REACTOR,
            FACTORY_TECHLAB,
            FLEET_BEACON,
            FORGE,
            FUSION_CORE,
            GATEWAY,
            GHOST_ACADEMY,
            GREATER_SPIRE,
            HATCHERY,
            HIVE,
            HYDRALISK_DEN,
            INFESTATION_PIT,
            LAIR,
            MISSILE_TURRET,
            NEXUS,
            NYDUS_NETWORK,
            ORBITAL_COMMAND,
            ORBITAL_COMMAND_FLYING,
            PHOTON_CANNON,
            PLANETARY_FORTRESS,
            PYLON,
            REACTOR,
            REFINERY,
            ROACH_WARREN,
            ROBOTICS_BAY,
            ROBOTICS_FACILITY,
            SENSOR_TOWER,
            SPAWNING_POOL,
            SPINE_CRAWLER,
            SPINE_CRAWLER_UPROOTED,
            SPIRE,
            SPORE_CRAWLER,
            SPORE_CRAWLER_UPROOTED,
            STARPORT,
            STARGATE,
            STARPORT_FLYING,
            STARPORT_REACTOR,
            STARPORT_TECHLAB,
            SUPPLY_DEPOT,
            SUPPLY_DEPOT_LOWERED,
            TECHLAB,
            TEMPLAR_ARCHIVE,
            TWILIGHT_COUNSEL,
            ULTRALISK_CAVERN,
            WARP_GATE
        };

        public static readonly HashSet<uint> Production = new HashSet<uint> {
            ARMORY,
            BANELING_NEST,
            BARRACKS,
            BARRACKS_TECHLAB,
            COMMAND_CENTER,
            CYBERNETICS_CORE,
            ENGINEERING_BAY,
            EVOLUTION_CHAMBER,
            FACTORY,
            FACTORY_TECHLAB,
            FLEET_BEACON,
            FORGE,
            FUSION_CORE,
            GATEWAY,
            GHOST_ACADEMY,
            GREATER_SPIRE,
            HATCHERY,
            HIVE,
            HYDRALISK_DEN,
            INFESTATION_PIT,
            LAIR,
            NEXUS,
            NYDUS_NETWORK,
            ORBITAL_COMMAND,
            PLANETARY_FORTRESS,
            ROACH_WARREN,
            ROBOTICS_BAY,
            ROBOTICS_FACILITY,
            SPAWNING_POOL,
            SPIRE,
            STARPORT,
            STARGATE,
            STARPORT_TECHLAB,
            TECHLAB,
            TEMPLAR_ARCHIVE,
            TWILIGHT_COUNSEL,
            ULTRALISK_CAVERN,
            WARP_GATE
        };

        public static readonly HashSet<uint> ArmyUnits = new HashSet<uint> {
            HELLBAT,
            LIBERATOR,
            WIDOW_MINE,
            WIDOW_MINE_BURROWED,
            CYCLONE,
            ADEPT,
            ARCHON,
            AUTO_TURRET,
            BANELING,
            BANELING_BURROWED,
            BANELING_COCOON,
            BANSHEE,
            BATTLECRUISER,
            BROOD_LORD,
            BROOD_LORD_COCOON,
            CARRIER,
            COLOSSUS,
            CORRUPTOR,
            DARK_TEMPLAR,
            GHOST,
            HELLION,
            HIGH_TEMPLAR,
            HYDRALISK,
            HYDRALISK_BURROWED,
            IMMORTAL,
            INFESTED_TERRANS_EGG,
            INFESTOR_BURROWED,
            INFESTOR_TERRAN,
            INFESTOR_TERRAN_BURROWED,
            MARAUDER,
            MARINE,
            MEDIVAC,
            MOTHERSHIP,
            MUTALISK,
            PHOENIX,
            //QUEEN,
            //QUEEN_BURROWED,
            RAVEN,
            REAPER,
            ROACH,
            ROACH_BURROWED,
            SENTRY,
            SIEGE_TANK,
            SIEGE_TANK_SIEGED,
            STALKER,
            THOR,
            ULTRALISK,
            URSADON,
            VIKING_ASSAULT,
            VIKING_FIGHTER,
            VOID_RAY,
            ZEALOT,
            ZERGLING,
            ZERGLING_BURROWED
        };

        public static readonly HashSet<uint> ResourceCenters = new HashSet<uint> {
            COMMAND_CENTER,
            COMMAND_CENTER_FLYING,
            HATCHERY,
            LAIR,
            HIVE,
            NEXUS,
            ORBITAL_COMMAND,
            ORBITAL_COMMAND_FLYING,
            PLANETARY_FORTRESS
        };

        public static readonly HashSet<uint> TerranResourceCenters = new HashSet<uint> {
            COMMAND_CENTER,
            COMMAND_CENTER_FLYING,
            ORBITAL_COMMAND,
            ORBITAL_COMMAND_FLYING,
            PLANETARY_FORTRESS
        };

        public static readonly HashSet<uint> ZergResourceCenters = new HashSet<uint> {
            HATCHERY,
            LAIR,
            HIVE
        };

        public static readonly HashSet<uint> MineralFields = new HashSet<uint> {
            RICH_MINERAL_FIELD,
            RICH_MINERAL_FIELD_750,
            MINERAL_FIELD,
            MINERAL_FIELD_750,
            LAB_MINERAL_FIELD,
            LAB_MINERAL_FIELD_750,
            PURIFIER_RICH_MINERAL_FIELD,
            PURIFIER_RICH_MINERAL_FIELD_750,
            PURIFIER_MINERAL_FIELD,
            PURIFIER_MINERAL_FIELD_750,
            BATTLE_STATION_MINERAL_FIELD,
            BATTLE_STATION_MINERAL_FIELD_750
        };

        public static readonly HashSet<uint> GasGeysers = new HashSet<uint> {
            VESPENE_GEYSER,
            SPACE_PLATFORM_GEYSER,
            RICH_VESPENE_GEYSER,
            PROTOSS_VESPENE_GEYSER,
            PURIFIER_VESPENE_GEYSER,
            SHAKURAS_VESPENE_GEYSER, 
        };

        public static readonly HashSet<uint> GasBuildings = new HashSet<uint> 
        {
            EXTRACTOR,
            ASSIMILATOR,
            REFINERY
        };

        public static readonly HashSet<uint> ResourceField = MineralFields.Concat(GasGeysers).Concat(GasBuildings).ToHashSet();

        public static readonly HashSet<uint> Workers = new HashSet<uint> {
            SCV,
            PROBE,
            DRONE
        };

        public static readonly HashSet<uint> Mechanical = new HashSet<uint> {
            HELLBAT,
            BANSHEE,
            THOR,
            SIEGE_TANK,
            SIEGE_TANK_SIEGED,
            BATTLECRUISER,
            VIKING_ASSAULT,
            VIKING_FIGHTER,
            HELLION,
            CYCLONE,
            WIDOW_MINE,
            WIDOW_MINE_BURROWED,
            LIBERATOR,
            RAVEN,
            MEDIVAC
        };

        public static readonly HashSet<uint> Liftable = new HashSet<uint> {
            COMMAND_CENTER,
            ORBITAL_COMMAND,
            BARRACKS,
            FACTORY,
            STARPORT
        };

        public static readonly HashSet<uint> StaticAirDefense = new HashSet<uint> {
            PHOTON_CANNON,
            MISSILE_TURRET,
            SPORE_CRAWLER,
            BUNKER
        };

        public static readonly HashSet<uint> StaticGroundDefense = new HashSet<uint> {
            PHOTON_CANNON,
            BUNKER,
            SPINE_CRAWLER,
            PLANETARY_FORTRESS
        };

        public static readonly HashSet<uint> SiegeTanks = new HashSet<uint> {
            SIEGE_TANK,
            SIEGE_TANK_SIEGED
        };

        public static readonly HashSet<uint> Vikings = new HashSet<uint> {
            VIKING_ASSAULT,
            VIKING_FIGHTER
        };

        public static readonly HashSet<uint> FromBarracks = new HashSet<uint> {
            REAPER,
            MARINE,
            MARAUDER,
            GHOST
        };

        public static readonly HashSet<uint> FromFactory = new HashSet<uint> {
            THOR,
            WIDOWMINE,
            HELLION,
            HELLBAT,
            SIEGE_TANK,
            CYCLONE
        };

        public static readonly HashSet<uint> FromStarport = new HashSet<uint> {
            VIKING_FIGHTER,
            RAVEN,
            BANSHEE,
            BATTLECRUISER,
            LIBERATOR
        };

        public static readonly HashSet<uint> AddOns = new HashSet<uint> {
            TECHLAB,
            REACTOR,
            BARRACKS_REACTOR,
            BARRACKS_TECHLAB,
            FACTORY_TECHLAB,
            FACTORY_REACTOR,
            STARPORT_TECHLAB,
            STARPORT_REACTOR
        };

        public static readonly HashSet<uint> SupplyDepots = new HashSet<uint> {
            SUPPLY_DEPOT,
            SUPPLY_DEPOT_LOWERED
        };

        public static readonly HashSet<uint> Gateways = new HashSet<uint> {
            WARP_GATE,
            GATEWAY
        };

        public static readonly Dictionary<uint, HashSet<uint>> TechTree = new Dictionary<uint, HashSet<uint>>()
        {
            { BANELING_NEST, new HashSet<uint>{ SPAWNING_POOL } },
            { SPINE_CRAWLER, new HashSet<uint>{ SPAWNING_POOL } },
            { SPORE_CRAWLER, new HashSet<uint>{ SPAWNING_POOL } },
            { ROACH_WARREN, new HashSet<uint>{ SPAWNING_POOL } },
            { HYDRALISK_DEN, new HashSet<uint>{ LAIR } },
            { LURKER_DEN, new HashSet<uint>{ HYDRALISK_DEN } },
            { INFESTATION_PIT, new HashSet<uint>{ LAIR } },
            { SPIRE, new HashSet<uint>{ LAIR } },
            { ULTRALISK_CAVERN, new HashSet<uint>{ HIVE } },
            { LAIR, new HashSet<uint>{ SPAWNING_POOL } },
            { HIVE, new HashSet<uint>{ INFESTATION_PIT } },
            { GREATER_SPIRE, new HashSet<uint>{ HIVE } },
            { QUEEN, new HashSet<uint> { SPAWNING_POOL } },
            { ZERGLING, new HashSet<uint> { SPAWNING_POOL } },
            { BANELING, new HashSet<uint> { BANELING_NEST } },
            { ROACH, new HashSet<uint> { ROACH_WARREN } },
            { HYDRALISK, new HashSet<uint> { HYDRALISK_DEN } },
            { MUTALISK, new HashSet<uint> { SPIRE } },
            { CORRUPTOR, new HashSet<uint> { SPIRE } },
            { INFESTOR, new HashSet<uint> { INFESTATION_PIT } },
            { SWARMHOST, new HashSet<uint> { INFESTATION_PIT } },
            { LURKER, new HashSet<uint> { LURKER_DEN } },
            { OVERSEER, new HashSet<uint> { LAIR, HIVE } },
            { VIPER , new HashSet<uint> { HIVE } },
            { ULTRALISK , new HashSet<uint> { ULTRALISK_CAVERN } },
            { BROOD_LORD , new HashSet<uint> { GREATER_SPIRE } },

            { CYBERNETICS_CORE , Gateways },
            { STARGATE , new HashSet<uint> { CYBERNETICS_CORE }  },
            { FLEET_BEACON , new HashSet<uint> { STARGATE }  },
            { ROBOTICS_FACILITY , new HashSet<uint> { CYBERNETICS_CORE }  },
            { ROBOTICS_BAY , new HashSet<uint> { ROBOTICS_FACILITY }  },
            { TWILIGHT_COUNSEL , new HashSet<uint> { CYBERNETICS_CORE }  },
            { DARK_SHRINE , new HashSet<uint> { TWILIGHT_COUNSEL }  },
            { TEMPLAR_ARCHIVE , new HashSet<uint> { TWILIGHT_COUNSEL }  },
            { ADEPT , new HashSet<uint> { CYBERNETICS_CORE } },
            { STALKER , new HashSet<uint> { CYBERNETICS_CORE } },
            { SENTRY , new HashSet<uint> { CYBERNETICS_CORE } },
            { HIGH_TEMPLAR , new HashSet<uint> { TEMPLAR_ARCHIVE } },
            { DARK_TEMPLAR , new HashSet<uint> { DARK_SHRINE } },
            { COLOSSUS , new HashSet<uint> { ROBOTICS_BAY } },
            { DISRUPTOR , new HashSet<uint> { ROBOTICS_BAY } },
            { CARRIER , new HashSet<uint> { FLEET_BEACON } },
            { TEMPEST , new HashSet<uint> { FLEET_BEACON } },
            { MOTHERSHIP , new HashSet<uint> { FLEET_BEACON } },

            { ORBITAL_COMMAND, new HashSet<uint> { BARRACKS } },
            { PLANETARY_FORTRESS, new HashSet<uint> { ENGINEERING_BAY } },
            { BARRACKS, new HashSet<uint> { SUPPLY_DEPOT } },
            { FACTORY, new HashSet<uint> { BARRACKS } },
            { STARPORT, new HashSet<uint> { FACTORY } },
            { FUSION_CORE, new HashSet<uint> { STARPORT } },
            { GHOST_ACADEMY, new HashSet<uint> { BARRACKS } },
            { ARMORY, new HashSet<uint> { FACTORY } },
            { GHOST , new HashSet<uint> { GHOST_ACADEMY } },
            { HELLBAT , new HashSet<uint> { ARMORY } },
            { THOR , new HashSet<uint> { ARMORY } },
            { BATTLECRUISER , new HashSet<uint> { FUSION_CORE } },
        };
        public static readonly Dictionary<uint, HashSet<uint>> ProducingStructure = new Dictionary<uint, HashSet<uint>>()
        {
            { EXTRACTOR, new HashSet<uint>{ DRONE }},
            { HATCHERY, new HashSet<uint>{ DRONE } },
            { SPAWNING_POOL, new HashSet<uint>{ DRONE } },
            { BANELING_NEST, new HashSet<uint>{ DRONE } },
            { EVOLUTION_CHAMBER, new HashSet<uint>{ DRONE } },
            { SPINE_CRAWLER, new HashSet<uint>{ DRONE } },
            { SPORE_CRAWLER, new HashSet<uint>{ DRONE } },
            { ROACH_WARREN, new HashSet<uint>{ DRONE } },
            { HYDRALISK_DEN, new HashSet<uint>{ DRONE } },
            { LURKER_DEN, new HashSet<uint>{ DRONE } },
            { INFESTATION_PIT, new HashSet<uint>{ DRONE } },
            { SPIRE, new HashSet<uint>{ DRONE } },
            { ULTRALISK_CAVERN, new HashSet<uint>{ DRONE } },
            { LAIR, new HashSet<uint>{ HATCHERY } },
            { HIVE, new HashSet<uint>{ LAIR } },
            { GREATER_SPIRE, new HashSet<uint>{ SPIRE } },
            { QUEEN, ZergResourceCenters },
            { OVERLORD, new HashSet<uint> { LARVA } },
            { DRONE, new HashSet<uint> { LARVA } },
            { ZERGLING, new HashSet<uint> { LARVA } },
            { BANELING, new HashSet<uint> { ZERGLING } },
            { ROACH, new HashSet<uint> { LARVA } },
            { RAVAGER, new HashSet<uint> { LARVA } },
            { HYDRALISK, new HashSet<uint> { LARVA } },
            { MUTALISK, new HashSet<uint> { LARVA } },
            { CORRUPTOR, new HashSet<uint> { LARVA } },
            { INFESTOR, new HashSet<uint> { LARVA } },
            { SWARMHOST, new HashSet<uint> { LARVA } },
            { LURKER, new HashSet<uint> { HYDRALISK } },
            { OVERSEER, new HashSet<uint> { OVERLORD } },
            { VIPER , new HashSet<uint> { LARVA } },
            { ULTRALISK , new HashSet<uint> { LARVA } },
            { BROOD_LORD , new HashSet<uint> { CORRUPTOR } },

            { ASSIMILATOR, new HashSet<uint> { PROBE } },
            { NEXUS, new HashSet<uint> { PROBE } },
            { GATEWAY, new HashSet<uint> { PROBE } },
            { WARP_GATE, new HashSet<uint> { GATEWAY } },
            { PYLON, new HashSet<uint> { PROBE } },
            { FORGE, new HashSet<uint> { PROBE } },
            { CYBERNETICS_CORE, new HashSet<uint> { PROBE } },
            { STARGATE , new HashSet<uint> { PROBE }  },
            { FLEET_BEACON , new HashSet<uint> { PROBE }  },
            { ROBOTICS_FACILITY , new HashSet<uint> { PROBE }  },
            { ROBOTICS_BAY , new HashSet<uint> { PROBE }  },
            { TWILIGHT_COUNSEL , new HashSet<uint> { PROBE }  },
            { DARK_SHRINE , new HashSet<uint> { PROBE }  },
            { TEMPLAR_ARCHIVE , new HashSet<uint> { PROBE }  },
            { PROBE, new HashSet<uint> { NEXUS } },
            { ZEALOT, Gateways },
            { ADEPT, Gateways },
            { STALKER, Gateways },
            { SENTRY, Gateways },
            { HIGH_TEMPLAR, Gateways },
            { DARK_TEMPLAR, Gateways },
            { ARCHON, new HashSet<uint> { DARK_TEMPLAR, HIGH_TEMPLAR } },
            { IMMORTAL, new HashSet<uint> { ROBOTICS_FACILITY } },
            { WARP_PRISM, new HashSet<uint> { ROBOTICS_FACILITY } },
            { OBSERVER, new HashSet<uint> { ROBOTICS_FACILITY } },
            { COLOSSUS, new HashSet<uint> { ROBOTICS_FACILITY } },
            { DISRUPTOR, new HashSet<uint> { ROBOTICS_FACILITY } },
            { ORACLE, new HashSet<uint> { STARGATE } },
            { VOID_RAY, new HashSet<uint> { STARGATE } },
            { PHOENIX, new HashSet<uint> { STARGATE } },
            { CARRIER, new HashSet<uint> { STARGATE } },
            { TEMPEST, new HashSet<uint> { STARGATE } },
            { MOTHERSHIP, new HashSet<uint> { NEXUS } },

            { COMMAND_CENTER, new HashSet<uint> { SCV } },
            { ORBITAL_COMMAND, new HashSet<uint> { COMMAND_CENTER } },
            { PLANETARY_FORTRESS, new HashSet<uint> { COMMAND_CENTER } },
            { SUPPLY_DEPOT, new HashSet<uint> { SCV } },
            { BARRACKS, new HashSet<uint> { SCV } },
            { ENGINEERING_BAY, new HashSet<uint> { SCV } },
            { FACTORY, new HashSet<uint> { SCV } },
            { STARPORT, new HashSet<uint> { SCV } },
            { FUSION_CORE, new HashSet<uint> { SCV } },
            { GHOST_ACADEMY, new HashSet<uint> { SCV } },
            { ARMORY, new HashSet<uint> { SCV } },
            { SCV , TerranResourceCenters },
            { MARINE , new HashSet<uint> { BARRACKS } },
            { MARAUDER , new HashSet<uint> { BARRACKS } },
            { REAPER , new HashSet<uint> { BARRACKS } },
            { GHOST , new HashSet<uint> { BARRACKS } },
            { WIDOWMINE , new HashSet<uint> { FACTORY } },
            { HELLION , new HashSet<uint> { FACTORY } },
            { HELLBAT , new HashSet<uint> { FACTORY } },
            { CYCLONE , new HashSet<uint> { FACTORY } },
            { SIEGE_TANK , new HashSet<uint> { FACTORY } },
            { THOR , new HashSet<uint> { FACTORY } },
            { VIKING_ASSAULT , new HashSet<uint> { STARPORT } },
            { LIBERATOR , new HashSet<uint> { STARPORT } },
            { MEDIVAC , new HashSet<uint> { STARPORT } },
            { RAVEN , new HashSet<uint> { STARPORT } },
            { BATTLECRUISER , new HashSet<uint> { STARPORT } },
        };

        public static readonly HashSet<uint> RequireCreep = new HashSet<uint>()
        {
             SPAWNING_POOL,
             BANELING_NEST,
             EVOLUTION_CHAMBER,
             SPINE_CRAWLER,
             SPORE_CRAWLER,
             ROACH_WARREN,
             HYDRALISK_DEN,
             LURKER_DEN,
             INFESTATION_PIT,
             SPIRE,
             ULTRALISK_CAVERN, 
             CREEP_TUMOR
        };
    }
}