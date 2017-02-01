using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using Wow.Dialogs;

namespace Wow.Pages
{
    public class CreateCoursePage : HeadPage
    {
        private const string Ok = "Ok";

        private ModalWindow successAddingCourseDialog;

        public CreateCoursePage(Manager manager) : base(manager)
        {
            this.manager = manager;
            this.CourseName = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=course.Name");
            this.CourseLanguage = manager.ActiveBrowser.Find.ById<HtmlSelect>("select");
            this.WordSuitesForCourseContainer =
                manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=bin text-center ng-binding");
            this.CreateCourse = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-primary btn-lg");
            this.successAddingCourseDialog = null;
        }

        public HtmlInputText CourseName { get; private set; }
        public HtmlSelect CourseLanguage { get; private set; }
        public HtmlDiv WordSuitesForCourseContainer { get; set; }
        public HtmlButton CreateCourse { get; private set; }

        // Getters
        public string GetDialogTitle()
        {
            return this.successAddingCourseDialog.GetTitle();
        }

        public string GetDialogBodyMessage()
        {
            return this.successAddingCourseDialog.GetBodyMessage();
        }

        // Functional
        private HtmlControl GetWordSuite(string title)
        {
            string xpath = $"//div[contains(text(),'{title}')]";
            return this.manager.ActiveBrowser.Find.ByXPath<HtmlDiv>(xpath);
        }

        public void DropItem(string wordSuiteName)
        {
            HtmlControl wordSuiteItem = this.GetWordSuite(wordSuiteName);
            wordSuiteItem.DragTo(this.WordSuitesForCourseContainer);
        }

        // Setters
        public void SetCourseName(string courseName)
        {
            this.CourseName.Text = courseName;
        }

        public void SetCourseLanguage(string language)
        {
            this.CourseLanguage.SelectByText(language, true);
        }

        public void ClickOkButton()
        {
            this.successAddingCourseDialog.ClickButton(Ok);
        }

        public CoursesPage CloseDialogWindow()
        {
            this.ClickOkButton();
            return new CoursesPage(this.manager);
        }

        public void CreateCourseClick()
        {
            this.CreateCourse.Click();
            this.successAddingCourseDialog = new ModalWindow(this.manager);
        }
    }
}
