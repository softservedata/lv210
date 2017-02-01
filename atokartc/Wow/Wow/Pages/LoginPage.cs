using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using NLog;
using Wow.Data;

namespace Wow.Pages
{
    public class LoginPage
    {
        // Components
        private class LoginForm
        {
            // Fields
            private Manager manager;

            // get Data
            public HtmlInputEmail LoginInput { get; private set; }
            public HtmlInputPassword PasswordInput { get; private set; }
            public HtmlInputSubmit SubmitInput { get; private set; }

            // Constructor
            public LoginForm(Manager manager)
            {
                this.manager = manager;
                this.LoginInput =  manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=email");
                this.PasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=password");
                this.SubmitInput = manager.ActiveBrowser.Find.ByName<HtmlInputSubmit>("loginButton");
            }
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        // Expected Data
        public static readonly string LOGIN_DESCRIPTION_TEXT = "SoftServe Language School";

        // Check Login Form
        private const string LOGIN_FORM_BY_ATTRIBUTE = "id=myModalLabel";

        // Fields
        private Manager manager;

        // get Data
        public HtmlButton LoginButton { get; private set; }
        public Element LoginDescription { get; private set; }
        //
        private LoginForm loginForm;

        // Constructor
        public LoginPage(Manager manager)
        {
            this.manager = manager;
            this.LoginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            this.LoginDescription = manager.ActiveBrowser.Find.ByXPath("//div[@class='text-primary']/h2/small");
        }

        // Page Object
        // get Data
        public HtmlInputEmail GetLoginInput()
        {
            ClickLoginButton();
            return this.loginForm.LoginInput;
        }

        public HtmlInputPassword GetPasswordInput()
        {
            ClickLoginButton();
            return this.loginForm.PasswordInput;
        }

        public HtmlInputSubmit GetSubmitInput()
        {
            ClickLoginButton();
            return this.loginForm.SubmitInput;
        }

        // Functional
        public string GetLoginButtonText()
        {
            return this.LoginButton.TextContent.Trim();
        }

        public string GetLoginDescriptionText()
        {
            return this.LoginDescription.TextContent.Trim();
        }

        // set Data
        public void ClickLoginButton()
        {
            if (manager.ActiveBrowser.Find.AllByAttributes<HtmlControl>(LOGIN_FORM_BY_ATTRIBUTE).Count == 0)
            {
                logger.Debug("ClickLoginButton() this.LoginButton.Click() and new LoginForm(manager);");
                this.LoginButton.Click();
                loginForm = new LoginForm(manager);
            }
        }

        // Business Logic
        private void SetLoginData(IUser user)
        {
            ClickLoginButton();
            this.loginForm.LoginInput.Text = user.GetEmail();
            this.loginForm.PasswordInput.Text = user.GetPassword();
            this.loginForm.SubmitInput.Click();
        }

        public UsersPage SuccessAdminLogin(IUser admin)
        {
            //public AdminHomePage SuccessAdminLogin(String login, String password) {
            SetLoginData(admin);
            //SetLoginData(login, password);
            // Return a new page object representing the destination.
            return new UsersPage(manager);
        }

        public UsersPage SuccessTeacherLogin(IUser teacher)
        {
            SetLoginData(teacher);
            return new UsersPage(manager);
        }

        public StudentPage SuccessStudentLogin(IUser student)
        {
            SetLoginData(student);
            return new StudentPage(manager);
        }
    }
}
