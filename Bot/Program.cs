﻿using System;
using SC2APIProtocol;

namespace Bot {
    internal class Program {
        // Settings for your bot.
        private static readonly Bot bot = new BeholderBot();
        private const Race race = Race.Zerg;

        // Settings for single player mode.
//        private static string mapName = "AbyssalReefLE.SC2Map";
//        private static string mapName = "AbiogenesisLE.SC2Map";
//        private static string mapName = "FrostLE.SC2Map";
        private static readonly string mapName = "DiscoBloodbathLE.SC2Map";

        private static readonly Race opponentRace = Race.Protoss;
        private static readonly Difficulty opponentDifficulty = Difficulty.Medium;

        public static GameConnection gc;

        private static void Main(string[] args) {
            try {
                gc = new GameConnection();
                if (args.Length == 0){
                    gc.readSettings();
                     gc.RunSinglePlayer(bot, mapName, race, opponentRace, opponentDifficulty).Wait();
                }
                else
                    gc.RunLadder(bot, race, args).Wait();
            }
            catch (Exception ex) {
                Logger.Info(ex.ToString());
            }

            Logger.Info("Terminated.");
        }
    }
}