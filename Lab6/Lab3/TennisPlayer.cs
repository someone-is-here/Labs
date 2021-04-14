using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3 {
    class TennisPlayer : Sportsman, ITennisPlayer,IPlayer {
        public enum Fields {
            GrassCourts,
            ClayCourts,
            HardCourts,
            ArtificialGrass
        }
        public enum Types {
            Singles,
            Doubles,
            MixedDoubles
        }
        public int RankingPosition { get; set; } 
        public Types PlayType { get; set; }
        public Fields FieldForGame { get; set; }
        public int HitAccuracy { get; set; }
        public bool IsWimbledonWinner { get; set; }
        public double HitRate { get; set; }
        public TennisPlayer():base() {
            RankingPosition = 0;
            HitRate = 0;
            PlayType = Types.Singles;
            FieldForGame = Fields.GrassCourts;
            IsWimbledonWinner = false;
        }
        public TennisPlayer(bool sex, bool marriage, string homeAddress, string name, string surname, string country, DateTime dateOfBirth, TypesOfSports sport, int howLongInSport, int numOfGoldMedals, bool isMaster, bool isOlympicChampion, int RankingPos, Types type, Fields field, bool IsWimbledonWinner,double hitRate,int hitAccuracy) : base(sex, marriage, homeAddress, name, surname, country, dateOfBirth, sport, howLongInSport, numOfGoldMedals, isMaster, isOlympicChampion) {
            this.RankingPosition = RankingPos;
            this.PlayType = type;
            this.FieldForGame = field;
            this.IsWimbledonWinner = IsWimbledonWinner;
            this.HitRate = hitRate;
            this.HitAccuracy = hitAccuracy;
        }
        public void GenTennisPlayer() {
            Random rand = new Random();
            GenSportsmenFields();
            HitRate = rand.NextDouble();
            SportType = TypesOfSports.Tennis;
            RankingPosition = rand.Next(1, 200);
            PlayType += rand.Next(3);
            FieldForGame += rand.Next(4);
            IsWimbledonWinner = (rand.Next(2)) > 0 ? true : false;
            HitAccuracy = rand.Next(100);
        }
        public override void Attack() {
            Random rand = new Random();
            string attackResult = (rand.Next(2) > 0) ? " hitting the field!" : " missed it!";
            int speed = rand.Next(50, 150);
            if (attackResult == "hitting the field!") {
                HitRate += (double)speed / 500.0;
            } else {
                if (HitRate > 0) {
                    HitRate -= (double)speed / 500.0;
                }
                if (HitRate < 0) {
                    HitRate = 0;
                }
            }
            Console.WriteLine($"{this.Name} {attackResult}");
        }
        public override void ShowStatus() {
            base.ShowStatus();
            string IsWinnerW = (IsWimbledonWinner == true) ? "won wimbledon" : "not yet";
            Console.WriteLine($"Play {PlayType} on {FieldForGame}");
            Console.WriteLine($"Is Wimbledon winer: {IsWinnerW}");
            Console.WriteLine($"Ranking position: {RankingPosition}");
            Console.WriteLine($"Hit Rate: {HitRate}");
        }
        public override string ToString() {
            string isMasterInSport = (IsMaster == true) ? "master" : "not yet";
            string isOlympicChamp = (IsOlympicChampion == true) ? "Olympic champion" : "not yet";
            string gender = (sex == true) ? "women" : "men";
            string isMarried = (marriage == true) ? "married" : "single";
            string IsWinnerW = (IsWimbledonWinner == true) ? "won wimbledon" : "not yet";
            return $"{Name} {Surname} from {Country} \nAge: {Age} \nHome address: {HomeAddress} \nSex: {gender} \nStatus: {isMarried} \nDate of birth: {DateOfBirth.ToString("dd.MM.yyyy")}\n" +
                $"Type of sport: {SportType}\nHow long you in sport: {HowLongInSport}\nIs sport master: {isMasterInSport}\nNumber of gold medals: {NumOfGoldMedals}\nOlympic champion status: {isOlympicChamp}\n" +
                $"Ranking position: {RankingPosition}\n{PlayType} player\nBest field: {FieldForGame}\nIs Wibledon winner: {IsWinnerW}\n ";
        }
    }
}
