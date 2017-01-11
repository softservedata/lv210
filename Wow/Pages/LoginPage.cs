using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
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

        private class SignUpForm
        {
            // Fields
            private Manager manager;

            // get Data
            public HtmlInputText NameInput { get; private set; }
            public HtmlInputText SurnameInput { get; private set; }
            public HtmlSelect LanguageSelect { get; private set; }
            public HtmlInputEmail EmailInput { get; private set; }
            public HtmlInputPassword PasswordInput { get; private set; }
            public HtmlInputPassword RepeatPassword { get; private set; }
            public HtmlButton SignUp { get; private set; }

            public SignUpForm(Manager manager)
            {
                this.manager = manager;
                this.NameInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=nameValue");
                this.SurnameInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=surnameValue");
                this.LanguageSelect = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=languageId");
                this.EmailInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=emailValue");
                this.PasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=passwordValue");
                this.RepeatPassword = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=repeatPasswordValue");
                this.SignUp = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-block btn-primary");
            }
        }
        
        private Manager manager;

        // get Data
        public HtmlButton LoginButton { get; private set; }
        public Element LoginDescription { get; private set; }
        public HtmlButton SignUpButton { get; private set; }
        //
        private LoginForm loginForm;
        private SignUpForm signUpForm;

        // Constructor
        public LoginPage(Manager manager)
        {
            this.manager = manager;
            this.LoginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            this.LoginDescription = manager.ActiveBrowser.Find.ByXPath("//div[@class='text-primary']/h2/small");
            this.SignUpButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-primary");
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
            this.LoginButton.Click();
            loginForm = new LoginForm(manager);
        }

        public void ClickSignUpButton()
        {
            this.SignUpButton.Click();
            signUpForm = new SignUpForm(manager);
        }

        // Business Logic
        private void SetLoginData(IUser user)
        {
            ClickLoginButton();
            this.loginForm.LoginInput.Text = user.GetEmail();
            this.loginForm.PasswordInput.Text = user.GetPassword();
            this.loginForm.SubmitInput.Click();
        }

        private void SetSignUpData(IUser user)
        {
            ClickSignUpButton();
            this.signUpForm.NameInput.Text = user.GetName();
            this.signUpForm.NameInput.Text = user.GetName();
            this.
        }
        public UsersPage SuccessAdminLogin(IUser admin)
        {
            //public AdminHomePage SuccessAdminLogin(String login, String password) {
            SetLoginData(admin);
            //SetLoginData(login, password);
            // Return a new page object representing the destination.
            return new UsersPage(manager);
        }

        public TeacherPage SuccessTeacherLogin(IUser teacher)
        {
            SetLoginData(teacher);
            return new TeacherPage(manager);
        }

        public StudentPage SuccessStudentLogin(IUser student)
        {
            SetLoginData(student);
            return new StudentPage(manager);
        }
    }
}
