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
            private Manager manager;
            
            public HtmlInputEmail LoginInput { get; private set; }
            public HtmlInputPassword PasswordInput { get; private set; }
            public HtmlInputSubmit SubmitInput { get; private set; }
            public Element ErrorMessage { get; internal set; }
            
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
        
        private Manager manager;
        
        public HtmlButton LoginButton { get; private set; }
        public HtmlButton SignupButton { get; private set; }
        public Element LoginDescription { get; private set; }
        private LoginForm loginForm;
        private SignUpForm signupForm;
        
        public LoginPage(Manager manager)
        {
            this.manager = manager;
            this.LoginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            this.SignupButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-primary");
            this.LoginDescription = manager.ActiveBrowser.Find.ByXPath("//div[@class='text-primary']/h2/small");
        }

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
        
        public string GetLoginButtonText()
        {
            return this.LoginButton.TextContent.Trim();
        }

        public string GetLoginDescriptionText()
        {
            return this.LoginDescription.TextContent.Trim();
        }

        public string GetLoginErrorMessageText(IUser user)
        {
            loginForm.ErrorMessage = manager.ActiveBrowser.Find.ByAttributes("class=text-danger ng-binding");
            return this.loginForm.ErrorMessage.TextContent.Trim();
        }
        
        public void ClickLoginButton()
        {
            this.LoginButton.Click();
            loginForm = new LoginForm(manager);
        }

        public void ClickSignupButton()
        {
            this.SignupButton.Click();
            signupForm = new SignUpForm(manager);
        }
        
        internal void SetLoginData(IUser user)
        {
            if (this.loginForm == null)
            {
                ClickLoginButton();
            }
            
            this.loginForm.LoginInput.Text = user.GetEmail();
            this.loginForm.PasswordInput.Text = user.GetPassword();
            SubmitLogin();
        }

        public void SubmitLogin()
        {
            this.loginForm.SubmitInput.Click();
        }

        internal void SetSignupData(IUser user)
        {
            this.signupForm.NameInput.Text = user.GetFirstname();
            this.signupForm.SurnameInput.Text = user.GetLastname();
            string selectedLanguage = user.GetLanguage();
            this.signupForm.SelectLanguageInput.SelectByText(selectedLanguage);
            this.signupForm.EmailInput.Text = user.GetEmail();
            this.signupForm.PasswordInput.Text = user.GetPassword();
            this.signupForm.RepeatPasswordInput.Text = user.GetPassword();
        }

        public void ClickSubmitSignUpButton()
        {
            this.signupForm.ConfirmSignUpButton.Click();
        }

        public string GetSignupErrorMessage()
        {
            signupForm.ErrorMessage = manager.ActiveBrowser.Find.ByAttributes("class=text-danger ng-binding");
            return signupForm.ErrorMessage.TextContent.Trim();
        }

        internal SignUpForm InvalidSignupData(IUser user)
        {
            SetSignupData(user);
            
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
