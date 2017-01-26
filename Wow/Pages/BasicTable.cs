using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public class BasicTable
    {
        private class Pagination
        {
            // Fields
            private Manager manager;

            public HtmlAnchor FirstItem { get; private set; }
            public HtmlAnchor StepBackItem { get; private set; }
            public HtmlAnchor StepForwardItem { get; private set; }
            public HtmlAnchor LastItem { get; private set; }
            public HtmlAnchor ActiveItem { get; private set; }

            protected internal Pagination(Manager manager,
                string FirstXPath, string StepBackXPath, string StepForwardXPath, string LastXPath, string ActiveXPath)
            {
                this.manager = manager;
                this.FirstItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(FirstXPath);
                this.StepBackItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(StepBackXPath);
                this.StepForwardItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(StepForwardXPath);
                this.LastItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(LastXPath);
                this.ActiveItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(ActiveXPath);
            }
        }

        private const string CLASS_ATTRIBUTE = "class";
        private const string DISABLE_VALUE = "disabled";
        //
        // Fields
        private Manager manager;

        // get Data
        public HtmlTable Table { get; private set; }
        private Pagination pagination;

        // Constructor
        public BasicTable(Manager manager, string TableAttribute)
        {
            this.manager = manager;
            this.Table = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>(TableAttribute);
        }

        public BasicTable(Manager manager, string TableAttribute,
            string FirstXPath, string StepBackXPath, string StepForwardXPath, string LastXPath, string ActiveXPath)
        {
            this.manager = manager;
            this.Table = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>(TableAttribute);
            this.pagination = new Pagination(manager, FirstXPath, StepBackXPath, StepForwardXPath, LastXPath, ActiveXPath);
        }

        // Page Object
        // get Data
        //public List<Element> getHeader() { return null; }

        public IList<IList<Element>> GetAllCells() { return null; }

        public IList<Element> getRowByIndex(int rowIndex) { return null; }

        public IList<Element> getRowByValueInColumn(String value, int columnIndex) { return null; }

        public int getRowIndexByValueInColumn(String value, int columnIndex) { return null; }

        public IList<Element> getColumnByIndex(int columnIndex) { return null; }

        public IList<Element> getColumnByValueInRow(String value, int rowIndex) { return null; }

        //public List<Element> getColumnByValueOfHeader(String value) { return null; }

        //public int getColumnIndexByValueOfHeader(String value) { return null; }

        public Element getCell(int rowIndex, int columnIndex) { return null; }

        public bool IsFirstItemEnable()
        {
            return HasPagination()
                && !GetItemParent(pagination.FirstItem).BaseElement.GetAttributeValueOrEmpty(CLASS_ATTRIBUTE).ToLower().Contains(DISABLE_VALUE);
        }

        public bool IsStepBackItemEnable()
        {
            return HasPagination()
                && !GetItemParent(pagination.StepBackItem).BaseElement.GetAttributeValueOrEmpty(CLASS_ATTRIBUTE).ToLower().Contains(DISABLE_VALUE);
        }

        public bool IsStepForwardItemEnable()
        {
            return HasPagination()
                && !GetItemParent(pagination.StepForwardItem).BaseElement.GetAttributeValueOrEmpty(CLASS_ATTRIBUTE).ToLower().Contains(DISABLE_VALUE);
        }

        public bool IsLastItemEnable()
        {
            return HasPagination()
                && !GetItemParent(pagination.LastItem).BaseElement.GetAttributeValueOrEmpty(CLASS_ATTRIBUTE).ToLower().Contains(DISABLE_VALUE);
        }

        // Functional
        private void RefreshTable()
        {
            this.Table.Refresh();
        }

        private void RefreshPagination()
        {
            RefreshTable();
            if (HasPagination())
            {
                this.pagination.FirstItem.Refresh();
                this.pagination.StepBackItem.Refresh();
                this.pagination.StepForwardItem.Refresh();
                this.pagination.LastItem.Refresh();
                this.pagination.ActiveItem.Refresh();
            }
        }

        private bool HasPagination()
        {
            return pagination != null;
        }

        private HtmlListItem GetItemParent(HtmlAnchor htmlAnchor)
        {
            return htmlAnchor.Parent<HtmlListItem>();
        }

        public bool IsItemPresent(string text)
        {
            return true;
        }

        public bool IsItemPresent(int columnNumber, string text)
        {
            // Searching
            return true;
        }

        public bool IsItemPresent(string columnName, string text)
        {
            return true;
        }

        // set Data
        public void ClickFirstItem()
        {
            if (IsFirstItemEnable())
            {
                this.pagination.FirstItem.Click();
                RefreshPagination();
            }
        }

        public void ClickStepBackItem()
        {
            if (IsStepBackItemEnable())
            {
                this.pagination.StepBackItem.Click();
                RefreshPagination();
            }
        }

        public void ClickStepForwardItem()
        {
            if (IsStepForwardItemEnable())
            {
                this.pagination.StepForwardItem.Click();
                RefreshPagination();
            }
        }

        public void ClickLastItem()
        {
            if (IsLastItemEnable())
            {
                this.pagination.LastItem.Click();
                RefreshPagination();
            }
        }

        // Business Logic

    }
}
