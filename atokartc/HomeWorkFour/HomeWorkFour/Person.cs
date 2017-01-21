using System;

namespace HomeWorkFour
{
    /// <summary>
    /// Create Console Application project in VS.
    ///    Add class Person to the project.
    ///    Class Person should consists of
    ///    a) two private fields: name and birthYear(the birthday year) .
    ///	   b) two properties for access to these fields(only get)
    ///    c) default constructor and constructor with 2 parameters
    ///    d) methods:
    ///           Age - to calculate the age of person
    ///           Input - to input information about person
    ///           Output - to output information about person
    ///           ChangeName - to change the name of person
    ///    In the method Main() create 5 objects of Person type and input information about them.
    ///           Then calculate and write to console the name and Age of each person;
    ///           Change the name of persons, which Age is less then 16, to "Very Young".
    ///           Output information about all persons.
    ///    B*) In the previos class use birthDate field(full Date of birthday: day, month, year) instead of birthYear field.
    ///    As a type for this field use DataTime type. 
    /// </summary>
    public class Person
    {
        #region Fields
        private string name;
        private int birthYear;
        #endregion
        #region Properties
        public string Name
        {
            get { return name; }
        }

        public int Year
        {
            get { return birthYear; }
        }
        #endregion
        #region Constructors
        public Person() { }

        public Person(string name, int birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }
        #endregion

        #region Methods
        private int GetPositiveInt()
        {
            int readedVar = -1;
            bool isIntEntered = Int32.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered == false || readedVar <= 0)
            {
                Console.WriteLine("Please, enter an positive integer");
                return this.GetPositiveInt();
            }
            return readedVar;
        }

        public int Age()
        {
            return DateTime.Now.Year - this.birthYear;
        }
        /// <summary>
        /// Gives possibility to manually input information about person
        /// </summary>
        /// <returns></returns>
        public Person Input()
        {
            Console.WriteLine("Enter person's name:");
            this.name = Console.ReadLine();

            Console.WriteLine("Enter person's birth year:");
            int birthYear = GetPositiveInt();

            return new Person(name, birthYear);
        }

        public void Output()
        {
            int age = Age();
            Console.WriteLine("Person's name is: {0}, birth year is: {1}, age is {2}", 
                name, birthYear, age);
        }

        public void ChangeName(string newName)
        {
            this.name = newName;
        }
        #endregion
    }
}
