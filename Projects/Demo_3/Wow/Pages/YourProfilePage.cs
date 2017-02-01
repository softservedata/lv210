using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Data;

namespace Wow.Pages
{
    public class YourProfilePage : HeadPage
    {
        private class EditNameForm : EditForm
        {
            public EditNameForm(Manager manager) : base(manager)
            {
                this.NewNameField = manager.ActiveBrowser.Find.ById<HtmlInputText>("userNewName");
                this.ConfirmChanges = manager.ActiveBrowser.Find.ByXPath<HtmlInputSubmit>("//input[@id='editUserProfileBtn' and @value='Change Name']");
                this.CancelChanges = manager.ActiveBrowser.Find.ByXPath<HtmlInputSubmit>("//form[@id='editNameForm']//input[@id='editUserProfileBtn' and @value='Cancel']");
            }
            
            public HtmlInputText NewNameField { get; protected set; }
        }

        private class EditPasswordForm : EditForm
        {
            public EditPasswordForm(Manager manager) : base(manager)
            {
                this.CurrentPasswordField = manager.ActiveBrowser.Find.ById<HtmlInputPassword>("userCurrentPassword");
                this.NewPasswordField = manager.ActiveBrowser.Find.ById<HtmlInputPassword>("password");
                this.ConfirmPasswordField = manager.ActiveBrowser.Find.ById<HtmlInputPassword>("userConfirmNewPassword");
                this.ConfirmChanges = manager.ActiveBrowser.Find.ByXPath<HtmlInputSubmit>("//input[@id='editUserProfileBtn' and @value='Change Password']");
                this.CancelChanges = manager.ActiveBrowser.Find.ByXPath<HtmlInputSubmit>("//form[@id='editPasswordForm']//input[@id='editUserProfileBtn' and @value='Cancel']");
            }

            public HtmlInputPassword CurrentPasswordField { get; private set; }
            public HtmlInputPassword NewPasswordField { get; private set; }
            public HtmlInputPassword ConfirmPasswordField { get; private set; }
        }

        private EditNameForm editNameForm;
        private EditPasswordForm editPasswordForm;

        public YourProfilePage(Manager manager) : base(manager)
        {
            this.YourProfileLabel = manager.ActiveBrowser.Find.ByContent<HtmlControl>("Your Profile");
            this.UserName = manager.ActiveBrowser.Find.ByXPath<HtmlSpan>("//label[@id='userNameStyle']/span");
            this.EditUserName = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editName");
            this.EditUserPassword = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editPassword");
        }

        public HtmlControl YourProfileLabel { get; private set; }
        public HtmlSpan UserName { get; private set; }
        public HtmlAnchor EditUserName { get; private set; }
        public HtmlAnchor EditUserPassword { get; private set; }

        // Get Data

        public string GetNameValue()
        {
            return UserName.TextContent;
        }

        public HtmlInputText GetNewNameField()
        {
            return editNameForm.NewNameField;
        }

        private HtmlInputPassword GetCurrentPasswordField()
        {
            return this.editPasswordForm.CurrentPasswordField;
        }

        private HtmlInputPassword GetNewPasswordField()
        {
            return this.editPasswordForm.NewPasswordField;
        }

        private HtmlInputPassword GetConfirmPasswordField()
        {
            return this.editPasswordForm.ConfirmPasswordField;
        }

        // Set Data

        public void SetNewName(string newName)
        {
            editNameForm.NewNameField.Text = newName;
        }

        public void SetCurrentPassword(string currentPassword)
        {
            editPasswordForm.CurrentPasswordField.Text = currentPassword;
        }

        public void SetNewPassword(string newPassword)
        {
            editPasswordForm.NewPasswordField.Text = newPassword;
        }

        public void SetConfirmPassword(string confirmPassword)
        {
            editPasswordForm.ConfirmPasswordField.Text = confirmPassword;
        }

        // Functional

        public void ClickEditName()
        {
            EditUserName.Click();
            editNameForm = new EditNameForm(manager);
        }

        public void ClickEditPassword()
        {
            EditUserPassword.Click();
            editPasswordForm = new EditPasswordForm(manager);
        }

        public bool ArePasswordFieldsEnabled()
        {
            return GetCurrentPasswordField().IsEnabled &&
                   GetNewPasswordField().IsEnabled &&
                   GetConfirmPasswordField().IsEnabled;
        }

        public void CancelNameChanges()
        {
            editNameForm.CancelChanges.Click();
        }

        public void CancelPasswordChanges()
        {
            editPasswordForm.CancelChanges.Click();
        }
    }
}