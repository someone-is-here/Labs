using System;

namespace Lab3 {
    public interface IPerson {
        int Age { get; set; }
        DateTime DateOfBirth { get; set; }
        bool Sex { get; set; }
        bool Marriage { get; set; }
        string HomeAddress { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Country { get; set; }
        static int PeopleNum { get; set; }
        void GenFields();
        void ShowInfo();
    }
}
