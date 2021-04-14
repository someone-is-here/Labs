using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3 {
    struct HandballTeam {
        public HandballPlayer[] players;
        public string couch;
        public Teams Team;
    }
    enum Teams {
        Fireballs,
        GreatBallsOfFire,
        DribbleDown,
        HandballHustlers,
        OhShootHandballers,
        WildFish,
        SuperSonicSandals,
        DownAndOutfield,
        InGoodHands
    }
    struct Game {
        public HandballTeam team1;
        public HandballTeam team2;
        public int score1;
        public int score2;
        public int gameEnd;
        public Game(HandballTeam team1, HandballTeam team2, int score1, int score2, int gameEnd) {
            this.team1 = team1;
            this.team2 = team2;
            this.score1 = score1;
            this.score2 = score2;
            this.gameEnd = gameEnd;
        }
    }
    class HandballPlayer : Sportsman, IPlayer {
        public enum Position {
            Goalkeeper,
            Fullbacks,
            Wingers,
            CircleRunner,
            Center
        }

        public Position Pos { get; set; }
        public int HitAccuracy { get; set; }
        public Teams Team { get; set; }
        public HandballTeam handballTeam = new HandballTeam();
        public HandballPlayer() : base() {
            Pos = Position.Center;
            handballTeam.couch = "";
            handballTeam.Team = Teams.Fireballs;
            handballTeam.players = new HandballPlayer[7];
            HitAccuracy = 0;
        }
        private Game game;
        public HandballPlayer(Position pos, string couch,Teams tm, HandballPlayer[] players,int hitAccuracy) {
            Pos = pos;
            handballTeam.couch = couch;
            handballTeam.Team = tm;
            handballTeam.players = players;
            if (players.Length >= 7) {
                for (int i = 0; i < handballTeam.players.Length; i++) {
                    handballTeam.players[i] = players[i];
                }
            }
            this.HitAccuracy = hitAccuracy;
            this.game = new Game(handballTeam, new HandballTeam(), 0, 0, 10);
        }
        public override void Attack() {
            Random rand = new Random();
            Console.WriteLine($"{this.game.team1.Team} VS  {this.game.team2.Team}");
            string attackResult = (rand.Next(2) > 0) ? "hitting the field!" : "missed it!";
            Console.WriteLine($"{this.game.team1.Team} {attackResult}");
            if (attackResult == "hitting the field!") {
                this.game.score1++;
            }       
            
            attackResult = (rand.Next(2) > 0) ? "hitting the field!" : "missed it!";
            Console.WriteLine($"{this.game.team2.Team} {attackResult}");
            if (attackResult == "hitting the field!") {
                this.game.score2++;
            }

            if (this.game.score1 == this.game.gameEnd || this.game.score2 == this.game.gameEnd) {
                if (this.game.score1 > this.game.score2) {
                    Console.WriteLine($"Team {this.game.team1.Team} wins!!!");
                } else {
                    Console.WriteLine($"Team {this.game.team2.Team} wins!!!");
                }
                this.game = new Game(handballTeam, new HandballTeam(), 0, 0, 10);
            }
            Console.WriteLine($"{this.game.score1} :  {this.game.score2}");
        }
        private void GenHandballPlayer() {
            Random rand = new Random();
            GenSportsmenFields();
            SportType = TypesOfSports.Handball;
            string[] namesForGeneration = { "Alexandra", "Tanusha", "Veronika", "Anna", "Angelina", "Nial", "Alexey", "Alexandr", "Nikita", "Daniil" };
            handballTeam.couch = namesForGeneration[rand.Next(namesForGeneration.Length)];
            handballTeam.Team = Teams.Fireballs;
            handballTeam.Team += rand.Next(8);
            Pos = Position.Goalkeeper;
            Pos += rand.Next(5);
            HitAccuracy = rand.Next(100);
        }
        private void GenTeam() {
            handballTeam.players[0] = this;
            for (int i = 1; i < handballTeam.players.Length; i++) {
                handballTeam.players[i] = new HandballPlayer();
                handballTeam.players[i].GenHandballPlayer();
                if (i != 0) {
                    handballTeam.players[i].Team = handballTeam.players[0].Team;
                } 
            }
        }
        public void GenPlayer() {
            GenHandballPlayer();
            GenTeam();
            this.game = new Game(handballTeam, new HandballTeam(), 0, 0, 10);
        }
        public void ShowTeamMembers() {
            Console.WriteLine("Team members: ");
            for (int i = 0; i < handballTeam.players.Length; i++) {
                Console.WriteLine(handballTeam.players[i]);
            }
            Console.WriteLine();
        }
        public override void ShowStatus() {
            base.ShowStatus();
            Console.WriteLine($"Play for team: {Team} on position {Pos}");
        }
        public override string ToString() {
            string isMasterInSport = (IsMaster == true) ? "master" : "not yet";
            string isOlympicChamp = (IsOlympicChampion == true) ? "Olympic champion" : "not yet";
            string gender = (sex == true) ? "women" : "men";
            string isMarried = (marriage == true) ? "married" : "single";
            return $"{Name} {Surname} from {Country} \nAge: {Age} \nHome address: {HomeAddress} \nSex: {gender} \nStatus: {isMarried} \nDate of birth: {DateOfBirth.ToString("dd.MM.yyyy")}\n" +
                $"Type of sport: {SportType}\nHow long you in sport: {HowLongInSport}\nIs sport master: {isMasterInSport}\nNumber of gold medals: {NumOfGoldMedals}\nOlympic champion status: {isOlympicChamp}\n" +
                $"Couch: {handballTeam.couch}\nTeam: {handballTeam.Team}\nPlayer's position: {Pos}\n";
        }
    }
}
