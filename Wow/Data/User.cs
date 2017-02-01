using System;

namespace Wow.Data
{
    // Builder Interfaces
    public interface IEmail
    {
        IPassword SetEmail(string email);
    }

    public interface IPassword
    {
        IName SetPassword(string password);
    }

    public interface IName
    {
        IAdmin SetName(string name);
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

    // Dependency Inversion Interface
    public interface IUser
    {
        string GetEmail();
        string GetPassword();
        string GetName();
        bool GetIsAdmin();
        bool GetIsTeacher();
        bool GetIsStudent();
    }

    public class User : IEmail, IPassword, IName, IAdmin, ITeacher, IStudent, IBuilder, IUser
    {
        private string email;
        private string password;
        private string name;
        private bool isAdmin;
        private bool isTeacher;
        private bool isStudent;

        private User() { }

        private bool LogicExpressionForEqualMathod(User user)
        {
            return (this.email == user.email) && (this.password == user.password) && (this.name == user.name) &&
                   (this.isAdmin == user.isAdmin) &&
                   (this.isTeacher == user.isTeacher) &&
                   (this.isStudent == user.isStudent);
        }

        private static bool LogicExpressionForEqualMathod(User userFirst, User userSecond)
        {
            return (userFirst.email == userSecond.email) && (userFirst.password == userSecond.password) &&
                   (userFirst.name == userSecond.name) &&
                   (userFirst.isAdmin == userSecond.isAdmin) &&
                   (userFirst.isTeacher == userSecond.isTeacher) &&
                   (userFirst.isStudent == userSecond.isStudent);
        }

        // Static Factory
        public static IEmail Get()
        {
            return new User();
        }

        public IPassword SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public IName SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public IAdmin SetName(string name)
        {
            this.name = name;
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

        public string GetEmail()
        {
            return this.email;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public string GetName()
        {
            return this.name;
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

        public override bool Equals(Object obj)
        {
            User user = obj as User;
            if ((System.Object)user == null)
                return false;

            return LogicExpressionForEqualMathod(user);
        }

        public bool Equals(User user)
        {
            if ((object)user == null)
                return false;

            return LogicExpressionForEqualMathod(user);
        }

        public override int GetHashCode()
        {
            return this.GetEmail().GetHashCode() ^ this.GetPassword().GetHashCode() ^ this.GetName().GetHashCode() ^
                   this.GetIsAdmin().GetHashCode() ^ this.GetIsTeacher().GetHashCode() ^ this.GetIsStudent().GetHashCode();
        }

        public static bool operator ==(User firstUser, User secondUser)
        {
            if (System.Object.ReferenceEquals(firstUser, secondUser))
                return true;

            if ((object)firstUser == null || (object)secondUser == null)
                return false;

            return LogicExpressionForEqualMathod(firstUser, secondUser);
        }

        public static bool operator !=(User firstUser, User secondUser)
        {
            return !(firstUser == secondUser);
        }
    }
}