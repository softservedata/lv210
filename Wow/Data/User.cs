using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    // builder interfaces
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

    // dependency inversion interface
    public interface IUser
    {
        string GetEmail();
        string GetPassword();
        bool GetIsAdmin();
        bool GetIsTeacher();
        bool GetIsStudent();
    }
    
    public class User : IEmail, IPassword, IAdmin, ITeacher, IStudent, IBuilder, IUser
    {
        private string email;
        private string password; // { get; private set; }
        private bool isAdmin;
        private bool isTeacher;
        private bool isStudent;

        // Constructor
        /*
        public User(string email, string password, bool isAdmin, bool isTeacher, bool isStudent)
        {
            this.email = email;
            this.password = password;
            this.isAdmin = isAdmin;
            this.isTeacher = isTeacher;
            this.isStudent = isStudent;
        }
        */
        private User()
        {
            // default
        }

        // static factory
        // public static User Get() // old
        public static IEmail Get()
        {
            return new User();
        }

        // setters

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

        // getters

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
