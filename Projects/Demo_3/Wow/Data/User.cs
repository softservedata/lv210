using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Wow.Data
{
    public interface IFirstName                 
    {
        ILastName SetFirstName(string firstName);
    }

    public interface ILastName                  
    {
        ILanguage SetLastName(string lastName);
    }

    public interface ILanguage                  
    {
        IEmail SetLanguage(string language);
    }

    public interface IEmail
    {
        IPassword SetEmail(string email);
    }

    public interface IPassword
    {
        IAdmin SetPassword(string password);
    }

    public interface IAdmin
    {
        ITeacher SetIsAdmin(bool isAdmin);
    }

    public interface ITeacher
    {
        IStudent SetIsTeacher(bool isTeacher);
    }

    public interface IStudent
    {
        IBuilder SetIsStudent(bool isStudent);
    }

    public interface IBuilder
    {
        User Build();
    }

    public interface IUser
    {
        string GetFirstName();  
        string GetLastName();  
        string GetFullName();   
        string GetLanguage(); 
        string GetEmail();
        string GetPassword();
        bool GetIsAdmin();
        bool GetIsTeacher();
        bool GetIsStudent();
    }

    [DataContract]
    [Serializable]
    public class User : IFirstName, ILastName, ILanguage, IEmail, IPassword, IAdmin, ITeacher, IStudent, IBuilder, IUser
    {

        [DataMember]
        private string firstName;
        [DataMember]
        private string lastName;
        [DataMember]
        private string language;
        [DataMember]
        private string email;
        [DataMember]
        private string password;
        [DataMember]
        private bool isAdmin;
        [DataMember]
        private bool isTeacher;
        [DataMember]
        private bool isStudent;

        private User() { }

        public static IFirstName Get()
        {
            return new User();
        }

        public ILastName SetFirstName(string firstName)    
        {
            this.firstName = firstName;
            return this;
        }

        public ILanguage SetLastName(string lastName)      
        {
            this.lastName = lastName;
            return this;
        }

        public IEmail SetLanguage(string language)      
        {
            this.language = language;
            return this;
        }

        public IPassword SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public IAdmin SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public ITeacher SetIsAdmin(bool isAdmin)
        {
            this.isAdmin = isAdmin;
            return this;
        }

        public IStudent SetIsTeacher(bool isTeacher)
        {
            this.isTeacher = isTeacher;
            return this;
        }

        public IBuilder SetIsStudent(bool isStudent)
        {
            this.isStudent = isStudent;
            return this;
        }

        public User Build()
        {
            return this;
        }

        // Getters

        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public string GetFullName()
        {
            return String.Format($"{GetFirstName()} {GetLastName()}");
        }

        public string GetLanguage()
        {
            return this.language;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public bool GetIsAdmin()
        {
            return this.isAdmin;
        }

        public bool GetIsTeacher()
        {
            return this.isTeacher;
        }

        public bool GetIsStudent()
        {
            return this.isStudent;
        }    
    }
}