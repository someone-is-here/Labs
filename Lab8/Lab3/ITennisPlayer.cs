using System;

namespace Lab3 {
    public interface ITennisPlayer {
        static int RankingPosition { get; set; }
        bool IsWimbledonWinner { get; set; }
        double HitRate { get; set; }
        void GenTennisPlayer();
        int this[string str] { get; set; }
    }
}
