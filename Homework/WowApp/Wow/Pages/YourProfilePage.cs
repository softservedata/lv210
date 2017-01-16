using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Data;

namespace Wow.Pages
{
    public class YourProfilePage : HeadPage
    {
        public const string ErrorMessageForNameWithDigits = "Name can't contain digits";
        public const string ErrorMessageForNameWithSymbols = "Name can't contain reserved characters";

        private class EditNameForm
        {
            private Manager manager;

            protected internal EditNameForm(Manager manager)
            {
                this.manager = manager;
                this.NewNameLabel = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:New Name");
                this.NewNameField = manager.ActiveBrowser.Find.ById<HtmlInputText>("userNewName");
                this.ChangeName = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Change Name");
                this.Cancel = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Cancel");
            }

            public HtmlControl NewNameLabel { get; private set; }
            public HtmlInputText NewNameField { get; private set; }
            public HtmlInputSubmit ChangeName { get; private set; }
            public HtmlInputSubmit Cancel { get; private set; }           
        }

        private EditNameForm editNameForm;

        public YourProfilePage(Manager manager) : base(manager)
        {
            this.YourProfileLabel = manager.ActiveBrowser.Find.ByContent<HtmlControl>("Your Profile");
            this.Name = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>(new string[] { "ng-bind=userName", "class=ng-binding" });
            this.EditName = manager.ActiveBrowser.Find.ById<HtmlAnchor>("editName");
            this.Message = null;
        }

        public HtmlControl YourProfileLabel { get; private set; }
        public HtmlSpan Name { get; private set; }
        public HtmlAnchor EditName { get; private set; }
        public HtmlControl Message { get; private set; }

        // Get data
        private HtmlControl GetNewNameLabel()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            return this.editNameForm.NewNameLabel;
        }

        private HtmlInputSubmit GetChangeName()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            return this.editNameForm.ChangeName;
        }

        private HtmlInputSubmit GetCancel()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            return this.editNameForm.Cancel;
        }

        public HtmlInputText GetNewNameField()
        {
            if (this.editNameForm == null)
            {
                ClickEditName();
            }
            return this.editNameForm.NewNameField;
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
            this.editNameForm.ChangeName.Click();           
        }

        public void ChangeName(User user)
        {
            ClickChangeName();
            this.Message = manager.ActiveBrowser.Find.ById<HtmlControl>("editProfileLabel");
            this.Name.Refresh();
            if (user.GetName() != GetNameValue())
            {
                user.SetName(GetNameValue());
            }
        }

        public YourProfilePage ClickCancel()
        {
            this.editNameForm.Cancel.Click();
            return this;
        }
    }
}
