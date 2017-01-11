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

            public HtmlControl NewNameLabel { get; private set; }
            public HtmlInputText NewNameField { get; private set; }
            public HtmlInputSubmit ChangeName { get; private set; }
            public HtmlInputSubmit Cancel { get; private set; }

            public EditNameForm(Manager manager)
            {
                this.manager = manager;
                this.NewNameLabel = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:New Name");
                this.NewNameField = manager.ActiveBrowser.Find.ById<HtmlInputText>("userNewName");
                this.ChangeName = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Change Name");
                this.Cancel = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Cancel");
            }
        }

        private EditNameForm editNameForm;

        public HtmlControl YourProfileLabel { get; private set; }
        public HtmlSpan Name { get; private set; }
        public HtmlAnchor EditName { get; private set; }
        public HtmlControl Message { get; private set; }

        public YourProfilePage(Manager manager) : base(manager)
        {
            this.YourProfileLabel = manager.ActiveBrowser.Find.ByContent<HtmlControl>("Your Profile");
            this.Name = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>(new string[] { "ng-bind=userName", "class=ng-binding" });
            this.EditName = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editName");
            this.Message = null;
        }

        public YourProfilePage(Manager manager, HtmlControl message) : base(manager)
        {
            this.YourProfileLabel = manager.ActiveBrowser.Find.ByContent<HtmlControl>("Your Profile");
            this.Name = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>(new string[] { "ng-bind=userName", "class=ng-binding" });
            this.EditName = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editName");
            this.Message = message;
        }

        // Page Object
        // Get data
        public HtmlControl GetNewNameLabel()
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

        // Functional
        public string GetNameValue()
        {
            return this.Name.TextContent;
        }

        // Set Data
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
            return this.Message.BaseElement.InnerText;
        }

        public string GetNewNameFieldText()
        {
            return GetNewNameField().Text;
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


        // Change user name
        // TODO IUser
        public YourProfilePage ChangeName(User user)
        {
            ClickChangeName();
            var appearedMessage = manager.ActiveBrowser.Find.ById<HtmlControl>("editProfileLabel");
            var yourProfilePage = new YourProfilePage(manager, appearedMessage);
            if (user.GetName() != GetNameValue())
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
    }
}
