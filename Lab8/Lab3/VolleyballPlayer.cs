using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3 {
    class VolleyballPlayer : Sportsman, IPlayer, IComparable<VolleyballPlayer>{
        public enum Position {
            Setter,
            OutsideHitter,
            OppositeHitter,
            MiddleBlocker,
            Libero
        }
        public enum Teams {
            Minchanka,
            Uralochka,
            DinamoMoscow,
            ZarechieOdintsovo,
            DinamoKazan,
            VKLokomotivKaliningrad,
            Protone,
            Lipetsk,
            Sparta,
            Leningradka,
            DinamoKrasnadar
        }
        private string couch;
        public string Couch {
            get {
                return couch;
            }
            set {
                if (value.Length > 0) {
                    couch = value;
                }
            }
        }
        public Teams Team { get; set; }
        public delegate void HitAccuracyHandler(int value);
        public event HitAccuracyHandler hitHandler;
        public Position Pos { get; set; }
        public int HitAccuracy { get; set; }
        public VolleyballPlayer() : base() {
            this.couch = "";
            this.Team = Teams.Minchanka;
            this.Pos = Position.Setter;
            this.HitAccuracy = 0;
        }
        public VolleyballPlayer(bool sex, bool marriage, string homeAddress, string name, string surname, string country, DateTime dateOfBirth, TypesOfSports sport, int howLongInSport, int numOfGoldMedals, bool isMaster, bool isOlympicChampion, Teams team, Position pos, string couch, int hit) : base(sex, marriage, homeAddress, name, surname, country, dateOfBirth,sport,howLongInSport,numOfGoldMedals,isMaster,isOlympicChampion) {
            this.couch = couch;
            this.Team = team;
            this.Pos = pos;
            this.HitAccuracy = hit;
        }

        public override void Attack() {
            Random rand = new Random();
            string attackResult = (rand.Next(2) > 0) ? "hitting the field!" : "missed it!";
            if (attackResult == "hitting the field!") {
                hitHandler?.Invoke(HitAccuracy + 1);
                HitAccuracy++;
            } else {
                if (HitAccuracy > 0) {
                    hitHandler?.Invoke(HitAccuracy - 1);
                    HitAccuracy--;
                }
            }
            Console.WriteLine($"{this.Name} {attackResult}");
        }
        public override void ShowStatus() {
            base.ShowStatus();
            Console.WriteLine($"Team: {Team}");
            Console.WriteLine($"Position: {Pos}");
        }
        public void GenVolleyballPlayer() {
            Random rand = new Random();
            GenSportsmenFields();
            HitAccuracy = rand.Next(100);
            SportType = TypesOfSports.Volleyball;
            string[] namesForGeneration = { "Alexandra", "Tanusha", "Veronika", "Anna", "Angelina", "Nial", "Alexey", "Alexandr", "Nikita", "Daniil" };
            couch = namesForGeneration[rand.Next(namesForGeneration.Length)];
            Team = Teams.Minchanka;
            Team += rand.Next(11);
            Pos = Position.Setter;
            Pos += rand.Next(5);
        }
        public int CompareTo(VolleyballPlayer volleyballPlayer) {
            Console.WriteLine("VP");
            if (this.HitAccuracy > volleyballPlayer.HitAccuracy) {
                return 1;
            } else if (this.HitAccuracy < volleyballPlayer.HitAccuracy) {
                return -1;
            } else {
                return 0;
            }
        }
        public override string ToString() {
            string isMasterInSport = (IsMaster == true) ? "master" : "not yet";
            string isOlympicChamp = (IsOlympicChampion == true) ? "Olympic champion" : "not yet";
            string gender = (sex == true) ? "women" : "men";
            string isMarried = (marriage == true) ? "married" : "single";
            return $"{Name} {Surname} from {Country} \nAge: {Age} \nHome address: {HomeAddress} \nSex: {gender} \nStatus: {isMarried} \nDate of birth: {DateOfBirth.ToString("dd.MM.yyyy")}\n" +
                $"Type of sport: {SportType}\nHow long you in sport: {HowLongInSport}\nIs sport master: {isMasterInSport}\nNumber of gold medals: {NumOfGoldMedals}\nOlympic champion status: {isOlympicChamp}\n" +
                $"Couch: {Couch}\nTeam: {Team}\nPlayer's position: {Pos}\nHit accuracy: {HitAccuracy}\n";
        }
    }
}
