using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    // builder interfaces
    public interface IFirstname
    {
        ILastname SetFirstname(string firstname);
    }

    public interface ILastname
    {
        ILanguage SetLastname(string lastname);
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
        IConfirmPassword SetPassword(string password);
    }

    public interface IConfirmPassword
    {
        IAdmin SetConfirmPassword(string password);
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
        string GetName();
        string GetFirstname();
        string GetLastname();
        string GetLanguage();
        string GetEmail();
        string GetPassword();
        bool GetIsAdmin();
        bool GetIsTeacher();
        bool GetIsStudent();
    }

    public class User : IFirstname, ILastname, ILanguage, IEmail, IPassword, IConfirmPassword, IAdmin, ITeacher, IStudent, IBuilder, IUser
    {
        private const string SPACE = " ";
        private string firstname;
        private string lastname;
        private string language;
        private string email;
        private string password;
        private bool isAdmin;
        private bool isTeacher;
        private bool isStudent;
        private User()
        {
            
        }
        
        public static IFirstname Get()
        {
            return new User();
        }

        public ILastname SetFirstname(string firstname)
        {
            this.firstname = firstname;
            return this;
        }

        public ILanguage SetLastname(string lastname)
        {
            this.lastname = lastname;
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

        public IConfirmPassword SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public IAdmin SetConfirmPassword(string password)
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

        public string GetName()
        {
            return GetFirstname() + SPACE + GetLastname();
        }

        public string GetFirstname()
        {
            return this.firstname;
        }

        public string GetLastname()
        {
            return this.lastname;
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
