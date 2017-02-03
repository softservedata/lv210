using System;

namespace Wow.Data
{
    // builder interfaces
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

    // dependency inversion interface
    public interface IUser
    {
        string GetName();
        string GetFirstName();
        string GetLastName();
        string GetLanguage();
        string GetEmail();
        string GetPassword();
        bool GetIsAdmin();
        bool GetIsTeacher();
        bool GetIsStudent();
    }

    public class User : IFirstName, ILastName, ILanguage, IEmail, IPassword, IAdmin, ITeacher,
        IStudent, IBuilder, IUser, IEquatable<User>
    {
        private const string Space = " ";

        private string firstName;
        private string lastName;
        private string language;
        private string email;
        private string password;
        private bool isAdmin;
        private bool isTeacher;
        private bool isStudent;

        private User()
        {
        }

        public static IFirstName Get()
        {
            return new User();
        }

        // Setters
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
        public string GetName()
        {
            return lastName.Equals(string.Empty) ? firstName : string.Join(Space, firstName, lastName);
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
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

        public override bool Equals(object obj)
        {
            User user = obj as User;
            if ((object)user == null)
            {
                return false;
            }

            return LogicExpressionForEqualMethod(user);
        }

        public bool Equals(User user)
        {
            if ((object)user == null)
            {
                return false;
            }

            return LogicExpressionForEqualMethod(user);
        }

        public override int GetHashCode()
        {
            return this.GetEmail().GetHashCode() ^ this.GetPassword().GetHashCode() ^ this.GetName().GetHashCode() ^
                   this.GetIsAdmin().GetHashCode() ^ this.GetIsTeacher().GetHashCode() ^ this.GetIsStudent().GetHashCode();
        }

        public static bool operator ==(User firstUser, User secondUser)
        {
            if (object.ReferenceEquals(firstUser, secondUser))
            {
                return true;
            }

            if ((object)firstUser == null || (object)secondUser == null)
            {
                return false;
            }

            return LogicExpressionForEqualMethod(firstUser, secondUser);
        }

        public static bool operator !=(User firstUser, User secondUser)
        {
            return !(firstUser == secondUser);
        }

        #region MethodForComparison

        private bool AreEmailsEqual(User user)
        {
            return (object.ReferenceEquals(this.email, user.email))
                   || ((this.email != null) && (this.email.Equals(user.email)));
        }

        private static bool AreEmailsEqual(User userFirst, User userSecond)
        {
            return (object.ReferenceEquals(userFirst.email, userSecond.email))
                   || ((userFirst.email != null) && (userFirst.email.Equals(userSecond.email)));
        }

        private bool AreFirstNamesEqual(User user)
        {
            return (object.ReferenceEquals(this.firstName, user.firstName))
                   || ((this.firstName != null) && (this.firstName.Equals(user.firstName)));
        }

        private static bool AreFirstNamesEqual(User userFirst, User userSecond)
        {
            return (object.ReferenceEquals(userFirst.firstName, userSecond.firstName))
                   || ((userFirst.firstName != null) && (userFirst.firstName.Equals(userSecond.firstName)));
        }

        private bool AreLastNamesEqual(User user)
        {
            return (object.ReferenceEquals(this.lastName, user.lastName))
                   || ((this.lastName != null) && (this.lastName.Equals(user.lastName)));
        }

        private static bool AreLastNamesEqual(User userFirst, User userSecond)
        {
            return (object.ReferenceEquals(userFirst.lastName, userSecond.lastName))
                   || ((userFirst.lastName != null) && (userFirst.lastName.Equals(userSecond.lastName)));
        }

        private bool ArePasswordsEqual(User user)
        {
            return (object.ReferenceEquals(this.password, user.password))
                   || ((this.password != null) && (this.password.Equals(user.password)));
        }

        private static bool ArePasswordsEqual(User userFirst, User userSecond)
        {
            return (object.ReferenceEquals(userFirst.password, userSecond.password))
                   || ((userFirst.password != null) && (userFirst.password.Equals(userSecond.password)));
        }

        private bool AreLanguagesEqual(User user)
        {
            return (object.ReferenceEquals(this.language, user.language))
                   || ((this.language != null) && (this.language.Equals(user.language)));
        }

        private static bool AreLanguagesEqual(User userFirst, User userSecond)
        {
            return (object.ReferenceEquals(userFirst.language, userSecond.language))
                   || ((userFirst.language != null) && (userFirst.language.Equals(userSecond.language)));
        }

        private bool LogicExpressionForEqualMethod(User user)
        {
            return (this.AreEmailsEqual(user)) && (this.ArePasswordsEqual(user)) && (this.AreFirstNamesEqual(user))
                   && (this.AreLastNamesEqual(user)) && (this.AreLanguagesEqual(user))
                   && (this.isAdmin.Equals(user.isAdmin)) && (this.isTeacher.Equals(user.isTeacher))
                   && (this.isStudent.Equals(user.isStudent));
        }

        private static bool LogicExpressionForEqualMethod(User userFirst, User userSecond)
        {
            return AreEmailsEqual(userFirst, userSecond) && ArePasswordsEqual(userFirst, userSecond) &&
                   AreFirstNamesEqual(userFirst, userSecond) &&
                   AreLastNamesEqual(userFirst, userSecond) && AreLanguagesEqual(userFirst, userSecond) &&
                   (userFirst.isAdmin.Equals(userSecond.isAdmin)) &&
                   (userFirst.isTeacher.Equals(userSecond.isTeacher)) &&
                   (userFirst.isStudent.Equals(userSecond.isStudent));
        }

        #endregion
    }
}