using System;

namespace Lab3 {
    public interface ICharacterTraitsForSportsman {
        int Persistance { get; set; }
        int Motivation { get; set; }
        int Stability { get; set; }
        int this[string characterTrait] { get; set; }
        void GenCharacterTraits();
        void ShowCharacterTraits();
    }
}
