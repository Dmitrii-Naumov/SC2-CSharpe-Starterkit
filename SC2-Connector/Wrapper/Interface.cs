using System.Collections.Generic;
using SC2APIProtocol;

namespace SC2_Connector
{
    public interface Bot
    {
        void OnFrame();
        Race GetRace();
    }
}