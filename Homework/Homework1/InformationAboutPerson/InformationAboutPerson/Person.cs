using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using FluentValidation;
using FluentValidation.Results;


namespace InformationAboutPerson
{
    public class Person
    {
        public string Name { get; private set; } // Name of the person
        public int Age { get; private set; } // Age of the person

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public IList<ValidationFailure> Validate()
        {
            var validator = new PersonValidator();
            var result = validator.Validate(this);

            return result.Errors;
        }

        public override string ToString()
        {
            return $"\nName is {this.Name}, age is {this.Age}.";
        }
    }
}
