using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Wow.Data
{
    // Builder

    public interface IFirstName                 // ++++ 28.01
    {
        ILastName SetFirstName(string firstName);
    }

    public interface ILastName                  // ++++ 28.01
    {
        ILanguage SetLastName(string lastName);
    }

    public interface ILanguage                  // ++++ 28.01
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

    //public interface IName            // ---
    //{
    //    IAdmin SetName(string name);
    //}

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

    // Dependency Inversion Interface

    public interface IUser
    {
        string GetFirstName();  //+++
        string GetLastName();   //+++
        string GetFullName();   //+++
        string GetLanguage();   //+++
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

        //private bool LogicExpressionForEqualMathod(User user) // to del
        //{
        //    return (this.email == user.email) && (this.password == user.password) && (this.name == user.name) &&
        //           (this.isAdmin == user.isAdmin) &&
        //           (this.isTeacher == user.isTeacher) &&
        //           (this.isStudent == user.isStudent);
        //}

        //private static bool LogicExpressionForEqualMathod(User userFirst, User userSecond)
        //{
        //    return (userFirst.email == userSecond.email) && (userFirst.password == userSecond.password) &&
        //           (userFirst.name == userSecond.name) &&
        //           (userFirst.isAdmin == userSecond.isAdmin) &&
        //           (userFirst.isTeacher == userSecond.isTeacher) &&
        //           (userFirst.isStudent == userSecond.isStudent);
        //}

        // Static Factory

        public static IFirstName Get()
        {
            return new User();
        }

        // Setters

        public ILastName SetFirstName(string firstName)     //+++
        {
            this.firstName = firstName;
            return this;
        }

        public ILanguage SetLastName(string lastName)       //+++
        {
            this.lastName = lastName;
            return this;
        }

        public IEmail SetLanguage(string language)      //+++
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

        //public override bool Equals(Object obj)
        //{
        //    User user = obj as User;
        //    if ((System.Object)user == null)
        //        return false;

        //    return LogicExpressionForEqualMathod(user);
        //}

        //public bool Equals(User user)
        //{
        //    if ((object)user == null)
        //        return false;

        //    return LogicExpressionForEqualMathod(user);
        //}

        //public override int GetHashCode()
        //{
        //    return this.GetEmail().GetHashCode() ^ this.GetPassword().GetHashCode() ^ this.GetName().GetHashCode() ^
        //           this.GetIsAdmin().GetHashCode() ^ this.GetIsTeacher().GetHashCode() ^ this.GetIsStudent().GetHashCode();
        //}

        //public static bool operator ==(User firstUser, User secondUser)
        //{
        //    if (System.Object.ReferenceEquals(firstUser, secondUser))
        //        return true;

        //    if ((object)firstUser == null || (object)secondUser == null)
        //        return false;

        //    return LogicExpressionForEqualMathod(firstUser, secondUser);
        //}

        //public static bool operator !=(User firstUser, User secondUser)
        //{
        //    return !(firstUser == secondUser);
        //}
    }
}