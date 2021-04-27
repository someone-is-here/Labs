using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3 {
    public interface IPlayer {
        int HitAccuracy { get; set; }
        void ShowHitAccuracy() {
            Console.WriteLine($"Hit accuracy: {HitAccuracy}%");
        }
    }
}
