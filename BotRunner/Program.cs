using System;
using BeholderBot;
using SC2_Connector;
using SC2APIProtocol;

namespace BotRunner
{
    internal class Program
    {
        // Settings for your bot.
        private static readonly Bot bot = new Beholder();
        //private static readonly Bot bot = new RaxBot.RaxBot();

        // Settings for single player mode.
        //        private static string mapName = "AbyssalReefLE.SC2Map";
        //        private static string mapName = "AbiogenesisLE.SC2Map";
        //        private static string mapName = "FrostLE.SC2Map";
        private static readonly string mapName = "DiscoBloodbathLE.SC2Map";

        private static readonly Race opponentRace = Race.Protoss;
        private static readonly Difficulty opponentDifficulty = Difficulty.Medium;


        private static void Main(string[] args)
        {
            try
            {
                Controller.Connection = new GameConnection();
                if (args.Length == 0)
                {
                    Controller.Connection.readSettings();
                    Controller.Connection.RunSinglePlayer(bot, mapName, bot.GetRace(), opponentRace, opponentDifficulty).Wait();
                }
                else
                    Controller.Connection.RunLadder(bot, bot.GetRace(), args).Wait();
            }
            catch (Exception ex)
            {
                Logger.Info(ex.ToString());
            }

            Logger.Info("Terminated.");
        }
    }
}