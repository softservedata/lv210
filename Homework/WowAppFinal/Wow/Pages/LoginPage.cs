using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Data;

namespace Wow.Pages
{
    public class LoginPage
    {
        private class LoginForm
        {
            public static readonly string LoginFormByAttribute = "id=myModalLabel";

            protected internal LoginForm(Manager manager)
            {
                this.LoginInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=email");
                this.PasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=password");
                this.SubmitInput = manager.ActiveBrowser.Find.ByName<HtmlInputSubmit>("loginButton");
            }

            public HtmlInputEmail LoginInput { get; private set; }
            public HtmlInputPassword PasswordInput { get; private set; }
            public HtmlInputSubmit SubmitInput { get; private set; }
        }

        private class SignUpForm
        {
            public static readonly string InvalidEmail = "You should use a valid e-mail address";

            private Manager manager;

            protected internal SignUpForm(Manager manager)
            {
                this.manager = manager;
                this.NameInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=nameValue");
                this.SurnameInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=surnameValue");
                this.PasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=password");
                this.SelectLanguage = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-model=languageId");
                this.EmailInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=emailValue");
                this.PasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=passwordValue");
                this.RepeatPasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=repeatPasswordValue");
                this.SignUpSubmitButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-block btn-primary");
                this.ErrorMessage = null;
            }

            public HtmlInputText NameInput { get; private set; }
            public HtmlInputText SurnameInput { get; private set; }
            public HtmlSelect SelectLanguage { get; private set; }
            public HtmlInputEmail EmailInput { get; private set; }
            public HtmlInputPassword PasswordInput { get; private set; }
            public HtmlInputPassword RepeatPasswordInput { get; private set; }
            public HtmlButton SignUpSubmitButton { get; private set; }
            public HtmlControl ErrorMessage { get; private set; }

            public void InitErrorMessage()
            {
                this.ErrorMessage = manager.ActiveBrowser.Find.ByAttributes<HtmlControl>("class=text-danger ng-binding");
            }
        }

        private Manager manager;
        private LoginForm loginForm;
        private SignUpForm signUpForm;

        public LoginPage(Manager manager)
        {
            this.manager = manager;
            this.LoginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            this.SignUnButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-primary");
            this.LoginDescription = manager.ActiveBrowser.Find.ByXPath("//div[@class='text-primary']/h2/small");
        }

        public HtmlButton LoginButton { get; private set; }
        public HtmlButton SignUnButton { get; private set; }
        public Element LoginDescription { get; private set; }

        // Page Object

        // Getter to LoginForm
        private HtmlInputEmail GetLoginInput()
        {
            return this.loginForm.LoginInput;
        }

        private HtmlInputPassword GetPasswordInput()
        {
            return this.loginForm.PasswordInput;
        }

        private HtmlInputSubmit GetSubmitInput()
        {
            return this.loginForm.SubmitInput;
        }

        // Getters to SingInForm
        private HtmlInputText GetNameInput()
        {
            return this.signUpForm.NameInput;
        }

        private HtmlInputText GetSurnameInput()
        {
            return this.signUpForm.SurnameInput;
        }

        private HtmlSelect GetSelectLanguageField()
        {
            return this.signUpForm.SelectLanguage;
        }

        private HtmlInputEmail GetEmailInput()
        {
            return this.signUpForm.EmailInput;
        }

        private HtmlInputPassword GetPasswordForSignInInput()
        {
            return this.signUpForm.PasswordInput;
        }

        private HtmlInputPassword GetRepeatPasswordForSignInInput()
        {
            return this.signUpForm.RepeatPasswordInput;
        }

        private HtmlButton GetSignInSubmitButton()
        {
            return this.signUpForm.SignUpSubmitButton;
        }

        // Functional

        private string GetLoginButtonText()
        {
            return this.LoginButton.TextContent;
        }

        public string GetLoginDescriptionText()
        {
            return this.LoginDescription.TextContent;
        }

        public string GetErrorMessageText()
        {
            return this.signUpForm.ErrorMessage.BaseElement.InnerText;
        }

        public static string GetErrorMessageForInvalidEmail()
        {
            return SignUpForm.InvalidEmail;
        }

        // Set Data

        public void ClickLoginButton()
        {
            if (this.manager.ActiveBrowser.Find.AllByAttributes<HtmlControl>(LoginForm.LoginFormByAttribute).Count == 0)
            {
                this.LoginButton.Click();
                this.loginForm = new LoginForm(this.manager);
            }
        }

        public void ClickSignUpButton()
        {
            this.SignUnButton.Click();
            this.signUpForm = new SignUpForm(this.manager);
        }

        public UsersPage ClickSubmitLogin()
        {
            this.loginForm.SubmitInput.Click();
            return new UsersPage(this.manager);
        }

        public void ClickSubmitSignUp()
        {
            this.signUpForm.SignUpSubmitButton.Click();
            this.signUpForm.InitErrorMessage();
        }

        // Business Logic
        public void SetLoginData(IUser user)
        {
            this.loginForm.LoginInput.Text = user.GetEmail();
            this.loginForm.PasswordInput.Text = user.GetPassword();
        }

        public void SetSignUpData(IUser user)
        {
            this.signUpForm.NameInput.Text = user.GetFirstName();
            this.signUpForm.SurnameInput.Text = user.GetLastName();
            this.signUpForm.SelectLanguage.SelectByText(user.GetLanguage());
            this.signUpForm.EmailInput.Text = user.GetEmail();
            this.signUpForm.PasswordInput.Text = user.GetPassword();
            this.signUpForm.RepeatPasswordInput.Text = user.GetPassword();
        }

        public UsersPage SuccessUserLogin(IUser user)
        {
            ClickLoginButton();
            SetLoginData(user);
            ClickSubmitLogin();
            return new UsersPage(manager);
        }
    }
}