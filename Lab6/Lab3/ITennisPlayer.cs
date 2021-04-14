using System;

namespace Lab3 {
    public interface ITennisPlayer {
        int RankingPosition { get; set; }
        bool IsWimbledonWinner { get; set; }
        double HitRate { get; set; }
        void GenTennisPlayer();
    }
}
