using System;

namespace HomeWorkFour
{
    /// <summary>
    /// In the previos class use birthDate field(full Date of birthday: day, month, year) instead of birthYear field.
    /// As a type for this field use DataTime type.
    /// </summary>

    class Person
    {
        #region Fields
        private string name;
        private DateTime birthYear;
        #endregion
        #region Properties
        public string Name
        {
            get { return name; }
        }

        public DateTime Year
        {
            get { return birthYear; }
        }
        #endregion
        #region Constructors
        public Person() { }

        public Person(string name, DateTime birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }
        #endregion

        #region Methods
        public int Age()
        {
            return DateTime.Now.Year - birthYear.Year;
        }
        /// <summary>
        /// Gives possibility to manually input information about person
        /// </summary>
        /// <returns></returns>
        public Person Input()
        {
            Console.WriteLine("Enter person's name:");
            this.name = Console.ReadLine();

            Console.WriteLine("Enter person's age:");
            var year = DateTime.TryParse(Console.ReadLine(), out birthYear);

            return new Person(name, birthYear);
        }

        public void Output()
        {
            int age = Age();
            Console.WriteLine("Person's name is: {0}, birth year is: {1}, age is {2}", name, birthYear, age);
        }

        public void ChangeName(string newName)
        {
            this.name = newName;
        }
        #endregion
    }
}
