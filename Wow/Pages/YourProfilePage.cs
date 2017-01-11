using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Data;

namespace Wow.Pages
{
    public class YourProfilePage : HeadPage
    {
        private class EditNameForm
        {
            private Manager manager;

            public Element NewNameLabel { get; private set; }
            public HtmlInputText NewNameField { get; private set; }
            public HtmlInputSubmit ChangeName { get; private set; }
            public HtmlInputSubmit Cancel { get; private set; }

            public EditNameForm(Manager manager)
            {
                this.manager = manager;
                this.NewNameLabel = manager.ActiveBrowser.Find.ByContent("l:New Name");
                this.NewNameField = manager.ActiveBrowser.Find.ById<HtmlInputText>("userNewName");
                this.ChangeName = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Change Name");
                this.Cancel = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Cancel");
            }
        }

        private class EditPasswordForm
        {
            private Manager manager;

            public Element NewPasswordLabel { get; private set; }
            public HtmlInputPassword CurrentPasswordField { get; private set; }
            public HtmlInputPassword NewPasswordField { get; private set; }
            public HtmlInputPassword ConfirmPasswordField { get; private set; }
            public HtmlInputSubmit ChangePassword { get; private set; }
            public HtmlInputSubmit Cancel { get; private set; }

            public EditPasswordForm(Manager manager)
            {
                this.manager = manager;
                this.NewPasswordLabel = manager.ActiveBrowser.Find.ByContent("l:New Password");
                this.CurrentPasswordField = manager.ActiveBrowser.Find.ById<HtmlInputPassword>("userCurrentPassword");
                this.NewPasswordField = manager.ActiveBrowser.Find.ById<HtmlInputPassword>("password");
                this.ConfirmPasswordField = manager.ActiveBrowser.Find.ById<HtmlInputPassword>("userConfirmNewPassword");
                this.ChangePassword = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Change Password");
                this.Cancel = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Cancel");
            }
        }

        private EditNameForm editNameForm;
        private EditPasswordForm editPasswordForm;

        public Element YourProfileLabel { get; private set; }
        public HtmlSpan Name { get; private set; }
        public HtmlAnchor EditName { get; private set; }
        public HtmlAnchor EditPassword { get; private set; }
        public Element Message { get; private set; }

        public YourProfilePage(Manager manager) : base(manager)
        {
            this.YourProfileLabel = manager.ActiveBrowser.Find.ByContent("Your Profile");
            this.Name = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>(new string[] { "ng-bind=userName", "class=ng-binding" });
            this.EditName = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editName");
            this.EditPassword = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editPassword");
            this.Message = null;
        }

        public YourProfilePage(Manager manager, Element message) : base(manager)
        {
            this.YourProfileLabel = manager.ActiveBrowser.Find.ByContent("Your Profile");
            this.Name = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>(new string[] { "ng-bind=userName", "class=ng-binding" });
            this.EditName = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editName");
            this.EditPassword = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editPassword");
            this.Message = message;
        }

        public Element GetNewNameLabel()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            return this.editNameForm.NewNameLabel;
        }

        public HtmlInputText GetNewNameField()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            return this.editNameForm.NewNameField;
        }

        public HtmlInputSubmit GetChangeName()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            return this.editNameForm.ChangeName;
        }

        public HtmlInputSubmit GetCancel()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            return this.editNameForm.Cancel;
        }

        public Element GetNewPasswordLabel()
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            return this.editPasswordForm.NewPasswordLabel;
        }

        public HtmlInputPassword GetCurrentPasswordField()
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            return this.editPasswordForm.CurrentPasswordField;
        }

        public HtmlInputPassword GetNewPasswordField()
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            return this.editPasswordForm.NewPasswordField;
        }

        public HtmlInputPassword GetConfirmPasswordField()
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            return this.editPasswordForm.ConfirmPasswordField;
        }

        public HtmlInputSubmit GetChangePassword()
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            return this.editPasswordForm.ChangePassword;
        }

        public HtmlInputSubmit GetCancelPassword()
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            return this.editPasswordForm.Cancel;
        }

        public string GetNameValue()
        {
            return this.Name.TextContent;
        }

        public void ClickEditName()
        {
            this.EditName.Click();
            editNameForm = new EditNameForm(manager);
        }

        public void SetNewName(string newName)
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            this.editNameForm.NewNameField.Text = newName;
        }

        public string GetMessageText()
        {
            return this.Message.TextContent;
        }

        public string GetNewNameFieldText()
        {
            return GetNewNameField().Text;
        }

        // Set data for password edit form
        public void ClickEditPassword()
        {
            this.EditPassword.Click();
            editPasswordForm = new EditPasswordForm(manager);
        }

        public void SetCurrentPassword(string currentPassword)
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            this.editPasswordForm.CurrentPasswordField.Text = currentPassword;
        }

        public void SetNewPassword(string newPassword)
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            this.editPasswordForm.NewPasswordField.Text = newPassword;
        }

        public void SetConfirmPassword(string confirmPassword)
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            this.editPasswordForm.ConfirmPasswordField.Text = confirmPassword;
        }

        public string GetNewPasswordFieldText()
        {
            return GetNewPasswordField().Text;
        }

        // Business Logic
        public void ClickChangeName()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            this.editNameForm.ChangeName.Click();           
        }

        public void ClickChangePassword()
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            this.editPasswordForm.ChangePassword.Click();
        }

        //Change user name
        public YourProfilePage ChangeName(User user)
        {
            ClickChangeName();
            var appearedMessage = manager.ActiveBrowser.Find.ById("editProfileLabel");
            var yourProfilePage = new YourProfilePage(manager, appearedMessage);
            if (GetNameValue() != user.GetName())
            {
                user.SetName(GetNameValue());
            }           
            return yourProfilePage;
        }

        public YourProfilePage ClickCancel()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            this.editNameForm.Cancel.Click();
            return this;
        }

        public YourProfilePage ClickCancelPassword()
        {
            if (this.editPasswordForm == null)
            {
                ClickEditPassword();
            }
            this.editPasswordForm.Cancel.Click();
            return this;
        }
    }
}
