using System.Collections.Generic;

namespace Bot
{
    internal static class Abilities
    {
        //you can get all these values from the stableid.json file (just search for it on your PC)

        public static int RESEARCH_BANSHEE_CLOAK = 790;
        public static int RESEARCH_INFERNAL_PREIGNITER = 761;
        public static int RESEARCH_UPGRADE_MECH_AIR = 3699;
        public static int RESEARCH_UPGRADE_MECH_ARMOR = 3700;
        public static int RESEARCH_UPGRADE_MECH_GROUND = 3701;

        public static int CANCEL_CONSTRUCTION = 314;
        public static int CANCEL = 3659;
        public static int CANCEL_LAST = 3671;
        public static int LIFT = 3679;
        public static int LAND = 3678;

        public static int SMART = 1;
        public static int STOP = 4;
        public static int ATTACK = 23;
        public static int MOVE = 16;
        public static int PATROL = 17;
        public static int RALLY = 3673;
        public static int REPAIR = 316;

        public static int THOR_SWITCH_AP = 2362;
        public static int THOR_SWITCH_NORMAL = 2364;
        public static int SCANNER_SWEEP = 399;
        public static int YAMATO = 401;
        public static int CALL_DOWN_MULE = 171;
        public static int CLOAK = 3676;
        public static int REAPER_GRENADE = 2588;
        public static int DEPOT_RAISE = 558;
        public static int DEPOT_LOWER = 556;
        public static int SIEGE_TANK = 388;
        public static int UNSIEGE_TANK = 390;
        public static int TRANSFORM_TO_HELLBAT = 1998;
        public static int TRANSFORM_TO_HELLION = 1978;
        public static int UNLOAD_BUNKER = 408;
        public static int SALVAGE_BUNKER = 32;

        //gathering/returning minerals
        public static int GATHER_RESOURCES = 295;
        public static int RETURN_RESOURCES = 296;


        //gathering/returning minerals
        public static int GATHER_MINERALS = 295;
        public static int RETURN_MINERALS = 296;

        public static int LARVATRAIN_DRONE = 1342;
        public static int LARVATRAIN_ZERGLING = 1343;
        public static int LARVATRAIN_OVERLORD = 1344;
        public static int LARVATRAIN_HYDRALISK = 1345;
        public static int LARVATRAIN_MUTALISK = 1346;
        public static int LARVATRAIN_ULTRALISK = 1348;
        public static int LARVATRAIN_ROACH = 1351;
        public static int LARVATRAIN_INFESTOR = 1352;
        public static int LARVATRAIN_CORRUPTOR = 1353;
        public static int LARVATRAIN_VIPER = 1354;
        public static int LARVATRAIN_SWARMHOST = 1356;


        public static int EFFECT_INJECTLARVA = 251;
        public static int BUILD_CREEPTUMOR_QUEEN = 1694;
        public static int BUILD_CREEPTUMOR_TUMOR = 1733;

        public static int GetID(uint unit)
        {
            return (int)Controller.gameData.Units[(int)unit].AbilityId;
        }

    }
}