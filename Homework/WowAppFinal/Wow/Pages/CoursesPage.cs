using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System.Linq;
using Wow.Dialogs;

namespace Wow.Pages
{
    public class CoursesPage : HeadPage
    {
        private const int PositionOfDeleteButtonInRow = 3;
        private const string Yes = "Yes";
        private const string No = "No";

        private ModalWindow confirmDeletingCourseDialog;

        public CoursesPage(Manager manager) : base(manager)
        {
            this.manager = manager;
            this.CreateCourse =
                manager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("class=btn btn-primary btn-lg margins-vertikal-sm");
            this.TableOfCourses = new BasicTable(manager, "class=table");
            this.confirmDeletingCourseDialog = null;
        }

        public HtmlAnchor CreateCourse { get; private set; }
        public BasicTable TableOfCourses { get; private set; }

        // Functional
        public CreateCoursePage ClickCreateCourse()
        {
            this.CreateCourse.Click();
            return new CreateCoursePage(this.manager);
        }

        public void DeleteCourse(string courseName)
        {
            this.TableOfCourses.GetRowByValue(courseName).First()[PositionOfDeleteButtonInRow].ChildNodes.Single()
                .As<HtmlButton>()
                .Click();
            this.confirmDeletingCourseDialog = new ModalWindow(this.manager);
        }

        public void ConfirmDeleting()
        {
            this.confirmDeletingCourseDialog.ClickButton(Yes);
            this.TableOfCourses.Table.Refresh();
        }
    }
}
