using System;

namespace Lab3 {
    public interface ITennisPlayer {
        public int RankingPosition { get; set; }
        public bool IsWimbledonWinner { get; set; }
        public double HitRate { get; set; }
        public void GenTennisPlayer();
    }
}
