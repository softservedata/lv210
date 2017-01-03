﻿using System;
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
            this.LoginButton.Click();
            loginForm = new LoginForm(manager);
        }

        // Business Logic
        private void SetLoginData(User user)
        {
            ClickLoginButton();
            this.loginForm.LoginInput.Text = user.Email;
            this.loginForm.PasswordInput.Text = user.Password;
            this.loginForm.SubmitInput.Click();
        }

        public UsersPage SuccessAdminLogin(User admin)
        {
            //public AdminHomePage SuccessAdminLogin(String login, String password) {
            SetLoginData(admin);
            //SetLoginData(login, password);
            // Return a new page object representing the destination.
            return new UsersPage(manager);
        }

        public TeacherPage SuccessTeacherLogin(User teacher)
        {
            SetLoginData(teacher);
            return new TeacherPage(manager);
        }

        public StudentPage SuccessStudentLogin(User student)
        {
            SetLoginData(student);
            return new StudentPage(manager);
        }
    }
}
