using System.Collections.Generic;

namespace Bot {
    internal static class Units {
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
        public const uint INVESTATION_PIT = 94;
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

        public const uint SWARMHOSTBURROWEDMP = 493;
        public const uint SWARMHOSTMP = 494;
        public const uint ORACLE = 495;
        public const uint TEMPEST = 496;
        public const uint WARHOUND = 497;
        public const uint WIDOWMINE = 498;
        public const uint VIPER = 499;
        public const uint WIDOWMINEBURROWED = 500;
        public const uint LURKERMPEGG = 501;
        public const uint LURKERMP = 502;
        public const uint LURKERMPBURROWED = 503;
        public const uint LURKERDENMP = 504;
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


        public static readonly HashSet<uint> All = new HashSet<uint> {
            HELLBAT,
            LIBERATOR,
            WIDOW_MINE,
            WIDOW_MINE_BURROWED,
            CYCLONE,
            ADEPT,
            MULE,
            COLOSSUS,
            TECHLAB,
            REACTOR,
            INFESTOR_TERRAN,
            BANELING_COCOON,
            BANELING,
            MOTHERSHIP,
            POINT_DEFENSE_DRONE,
            CHANGELING,
            CHANGELING_ZEALOT,
            CHANGELING_MARINE_SHIELD,
            CHANGELING_MARINE,
            CHANGELING_ZERGLING_WINGS,
            CHANGELING_ZERGLING,
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
            HATCHERY,
            CREEP_TUMOR,
            EXTRACTOR,
            SPAWNING_POOL,
            EVOLUTION_CHAMBER,
            HYDRALISK_DEN,
            SPIRE,
            ULTRALISK_CAVERN,
            INVESTATION_PIT,
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
            PLANETARY_FORTRESS,
            ULTRALISK_BURROWED,
            ORBITAL_COMMAND,
            WARP_GATE,
            ORBITAL_COMMAND_FLYING,
            FORCE_FIELD,
            WARP_PRISM_PHASING,
            CREEP_TUMOR_BURROWED,
            CREEP_TUMOR_QUEEN,
            SPINE_CRAWLER_UPROOTED,
            SPORE_CRAWLER_UPROOTED,
            ARCHON,
            NYDUS_CANAL,
            BROODLING_ESCORT,
            RICH_MINERAL_FIELD,
            RICH_MINERAL_FIELD_750,
            URSADON,
            XEL_NAGA_TOWER,
            INFESTED_TERRANS_EGG,
            LARVA,
            MINERAL_FIELD,
            VESPENE_GEYSER,
            SPACE_PLATFORM_GEYSER,
            RICH_VESPENE_GEYSER,
            MINERAL_FIELD_750,
            PROTOSS_VESPENE_GEYSER,
            LAB_MINERAL_FIELD,
            LAB_MINERAL_FIELD_750,
            PURIFIER_RICH_MINERAL_FIELD,
            PURIFIER_RICH_MINERAL_FIELD_750,
            PURIFIER_VESPENE_GEYSER,
            SHAKURAS_VESPENE_GEYSER,
            PURIFIER_MINERAL_FIELD,
            PURIFIER_MINERAL_FIELD_750,
            BATTLE_STATION_MINERAL_FIELD,
            BATTLE_STATION_MINERAL_FIELD_750
        };


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
            INVESTATION_PIT,
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
            INVESTATION_PIT,
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
            INVESTATION_PIT,
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
            QUEEN,
            QUEEN_BURROWED,
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
            EXTRACTOR,
            ASSIMILATOR,
            REFINERY
        };

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

    }
}