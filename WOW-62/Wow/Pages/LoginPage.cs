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

        internal class SignUpForm
        {
            private Manager manager;
            public HtmlInputText NameInput { get; set; }
            public HtmlInputText SurnameInput { get; set; }
            public HtmlSelect SelectLanguageInput { get; set; }
            public HtmlInputEmail EmailInput { get; set; }
            public HtmlInputPassword PasswordInput { get; set; }
            public HtmlInputPassword RepeatPasswordInput { get; set; }
            public HtmlButton ConfirmSignUpButton { get; set; }
            public Element ErrorMessage { get; set; }

            public SignUpForm(Manager manager)
            {
                this.manager = manager;
                this.NameInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=nameValue");
                this.SurnameInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=surnameValue");
                this.SelectLanguageInput = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=languageId");
                this.EmailInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=emailValue");
                this.PasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=passwordValue");
                this.RepeatPasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=repeatPasswordValue");
                this.ConfirmSignUpButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("ng-click=registerButtonClick()");
            }
        }

        // Fields
        private Manager manager;
        private LoginForm loginForm;
        private SignUpForm signUpForm;

        // get Data
        public HtmlButton LoginButton { get; private set; }
        public HtmlButton SignUpButton { get; private set; }
        public Element LoginDescription { get; private set; }

        // Constructor
        public LoginPage(Manager manager)
        {
            this.manager = manager;
            this.LoginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            this.SignUpButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-primary");
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

        internal void SetSignUpData(IUser user)
        {
            this.signUpForm.NameInput.Text = user.GetFirstname();
            this.signUpForm.SurnameInput.Text = user.GetLastname();
            string selectedLanguage = user.GetLanguage();
            this.signUpForm.SelectLanguageInput.SelectByText(selectedLanguage);
            this.signUpForm.EmailInput.Text = user.GetEmail();
            this.signUpForm.PasswordInput.Text = user.GetPassword();
            this.signUpForm.RepeatPasswordInput.Text = user.GetPassword();
        }

        internal void ClickSubmitSignUpButton()
        {
            this.signUpForm.ConfirmSignUpButton.Click();
        }

        public string GetSignUpErrorMessage()
        {
            signUpForm.ErrorMessage = manager.ActiveBrowser.Find.ByAttributes("class=text-danger ng-binding");
            return signUpForm.ErrorMessage.TextContent.Trim();
        }

        internal SignUpForm InvalidSignUpData(IUser user)
        {
            SetSignUpData(user);
            return new SignUpForm(manager);
        }

        public UsersPage SuccessAdminLogin(IUser admin)
        {
            SetLoginData(admin);
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
