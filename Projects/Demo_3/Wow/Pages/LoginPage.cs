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

            public LoginForm(Manager manager)
            {
                this.manager = manager;
                this.LoginInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=email");
                this.PasswordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=password");
                this.SubmitInput = manager.ActiveBrowser.Find.ByName<HtmlInputSubmit>("loginButton");
            }

            public HtmlInputEmail LoginInput { get; private set; }
            public HtmlInputPassword PasswordInput { get; private set; }
            public HtmlInputSubmit SubmitInput { get; private set; }           
        }

        private Manager manager;
        private LoginForm loginForm;

        public LoginPage(Manager manager)
        {
            this.manager = manager;
            this.LoginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            this.LoginDescription = manager.ActiveBrowser.Find.ByXPath("//div[@class='text-primary']/h2/small");
        }

        public HtmlButton LoginButton { get; private set; }
        public Element LoginDescription { get; private set; }
        
        // Get Data

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

        // Set Data

        private void ClickLoginButton()
        {
            this.LoginButton.Click();
            loginForm = new LoginForm(manager);
        }

        // Business Logic

        private void SetLoginData(IUser user)
        {
            ClickLoginButton();
            this.loginForm.LoginInput.Text = user.GetEmail();
            this.loginForm.PasswordInput.Text = user.GetPassword();
            this.loginForm.SubmitInput.Click();
        }

        public UserPage SuccessUserLogin(IUser admin)
        {
            SetLoginData(admin);
            return new UserPage(manager);
        }
    }
}