using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Threading;

namespace Wow.Pages
{
    public class UsersPage : HeadPage
    {
        private class Pagination
        {
            //Fields
            private Manager manager;

            // get Data
            public HtmlAnchor First { get; private set; }
            public HtmlAnchor StepBack { get; private set; }
            public HtmlAnchor StepForward { get; private set; }
            public HtmlAnchor Last { get; private set; }
            public HtmlAnchor Active { get; private set; }

            public Pagination(Manager manager)
            {
                this.manager = manager;
                this.First = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:First");
                this.StepBack = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:‹");
                this.StepForward = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:›");
                this.Last = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:Last");
                this.Active = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(text(), '1')]");
            }
        }


        // Components
        private class UserRoleManagement
        {
            private Manager manager;

            //Role checkboxes
            public HtmlInputCheckBox AdminRole { get; private set; }
            public HtmlInputCheckBox TeacherRole { get; private set; }
            public HtmlInputCheckBox StudentRole { get; private set; }

            //Edit button
            public HtmlSpan EditPencil { get; set; }

            public HtmlSpan CheckMark { get; set; }

            public UserRoleManagement(Manager manager)
            {
                this.manager = manager;
                this.AdminRole = manager.ActiveBrowser.Find.ByAttributes<HtmlInputCheckBox>("ng-model=user.isAdmin");
                this.TeacherRole = manager.ActiveBrowser.Find.ByAttributes<HtmlInputCheckBox>("ng-model=user.isTeacher");
                this.StudentRole = manager.ActiveBrowser.Find.ByAttributes<HtmlInputCheckBox>("ng-model=user.isStudent");

                this.EditPencil = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=glyphicon glyphicon-pencil");
            }
        }

        private class UserTable //: BaseTable
        {
            // Fields
            private Manager manager;

            // get Data
            //public HtmlAnchor EditProfile { get; private set; }
            //public HtmlAnchor LogOut { get; private set; }

            // Constructor
            public UserTable(Manager manager)
            {
                this.manager = manager;
                //this.EditProfile = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("l:Edit Profile");
                //this.LogOut = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("p:Log Out");
            }
        }

        // Fields

        // get Data
        public HtmlControl All { get; private set; }
        public HtmlControl Admins { get; private set; }
        public HtmlControl Teacher { get; private set; }
        public HtmlControl Students { get; private set; }
        public HtmlInputText Search { get; private set; }

       

        //
        private UserTable userTable;
        private Pagination pagination;
        private UserRoleManagement userRoles;

        // Constructor
        public UsersPage(Manager manager) : base(manager)
        {
            this.All = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:All");
            this.Admins = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Admins");
            this.Teacher = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Teachers");
            this.Students = manager.ActiveBrowser.Find.ByContent<HtmlControl>("l:Students");
            this.Search = manager.ActiveBrowser.Find.ByAttributes<HtmlInputText>("ng-model=valueToSearch");
                   
            this.pagination = new Pagination(manager);
            this.userRoles = new UserRoleManagement(manager);
        }

        // Page Object
        // get Data
    
        public HtmlAnchor GetFirst()
        {
            return this.pagination.First;
        }

        public HtmlAnchor GetStepBack()
        {
            return this.pagination.StepBack;
        }

        public HtmlAnchor GetStepForward()
        {
            return this.pagination.StepForward;
        }

        public HtmlAnchor GetLast()
        {
            return this.pagination.Last;
        }

        public HtmlAnchor GetActive()
        {
            return this.pagination.Active;
        }

        private HtmlListItem GetFirstParent()
        {
            return this.pagination.First.Parent<HtmlListItem>();
        }

        private HtmlListItem GetStepBackParent()
        {
            return this.pagination.StepBack.Parent<HtmlListItem>();
        }

        private HtmlListItem GetStepForwardParent()
        {
            return this.pagination.StepForward.Parent<HtmlListItem>();
        }

        private HtmlListItem GetLastParent()
        {
            return this.pagination.Last.Parent<HtmlListItem>();
        }

        private HtmlListItem GetActiveParent()
        {
            return this.pagination.Active.Parent<HtmlListItem>();
        }


        // Functional
        private string GetExpressionUsed(HtmlControl element)
        {
            var expression = GetActive().BaseElement.FindExpressionUsed.StringRepresentation;
            return expression.Substring(expression.IndexOf('/'));
        }

        private bool IsActiveTheLastPage()
        {
            var xpath = $"{GetExpressionUsed(this.pagination.Active)}/ancestor::li/following-sibling::li[1]/descendant::a";
            return manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(xpath) == GetStepForward();
        }

        public bool IsLastEnabled()
        {
            var arrayOfAppropriateAttributes = GetLastParent().Attributes.Where(attribure => (attribure.Name == "class") &&
            (attribure.Value == "ng-scope disabled")).ToArray();

            return arrayOfAppropriateAttributes.Length == 0;
        }

        public bool IsStepBackEnabled()
        {
            var arrayOfAppropriateAttributes = GetStepBackParent().Attributes.Where(attribure => (attribure.Name == "class") &&
            (attribure.Value == "ng-scope disabled")).ToArray();

            return arrayOfAppropriateAttributes.Length == 0;
        }

        public bool IsStepForwardEnabled()
        {
            var arrayOfAppropriateAttributes = GetStepForwardParent().Attributes.Where(attribure => (attribure.Name == "class") &&
            (attribure.Value == "ng-scope disabled")).ToArray();

            return arrayOfAppropriateAttributes.Length == 0;
        }

        public bool IsFirstEnabled()
        {
            var arrayOfAppropriateAttributes = GetFirstParent().Attributes.Where(attribure => (attribure.Name == "class") &&
            (attribure.Value == "ng-scope disabled")).ToArray();

            return arrayOfAppropriateAttributes.Length == 0;
        }
        
        public bool IsAdminRoleEnabled()
        {
            return userRoles.AdminRole.IsEnabled;
        }

        public bool IsTeacherRoleEnabled()
        {
            return userRoles.TeacherRole.IsEnabled;
        }

        public bool IsStudentRoleEnabled()
        {
            return userRoles.StudentRole.IsEnabled;
        }

        public bool IsAdminRoleChecked()
        {
            return userRoles.AdminRole.Checked;
        }

        public bool IsTeacherRoleChecked()
        {
            return userRoles.TeacherRole.Checked;
        }

        public bool IsStudentRoleChecked()
        {
            return userRoles.StudentRole.Checked;
        }


        public bool IsDisplayedEditPencil()
        {
            return userRoles.EditPencil.IsVisible();
        }

        public bool IsDisplayedCheckMark()
        {
            return userRoles.CheckMark.IsVisible();
        }

   
        // set Data
        public UsersPage ClickFirst()
        {
            GetFirst().Click();
            return new UsersPage(manager);
        }

        public UsersPage ClickStepBack()
        {
            GetStepBack().Click();
            return new UsersPage(manager);
        }

        public UsersPage ClickStepForward()
        {
            GetStepForward().Click();
            return new UsersPage(manager);
        }

        public UsersPage ClickLast()
        {
            GetLast().Click();
            return new UsersPage(manager);
        }

        //
        public void SetValueToSearch(string userName)
        {
            Search.Text = userName;
        }

        public void SetAdminRole()
        {
            this.userRoles.AdminRole.Click();
        }

        public void SetTeacherRole()
        {
            this.userRoles.TeacherRole.Click();
                     
        }
              
        public void SetStudentRole()
        {
            this.userRoles.StudentRole.Click();
        }

        public void EditRole()
        {
            this.userRoles.EditPencil.Click();
            this.userRoles.CheckMark = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=glyphicon glyphicon-ok");
        }

        public void FinishEditing()
        {
            userRoles.CheckMark.Click();
        }
        // Business Logic

    }
}
