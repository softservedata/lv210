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

            // TODO Develop Builder
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
        // TODO Develop Builder
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

        // TODO If using pagination Must be return string
        public IList<IList<HtmlTableCell>> GetAllCells()
        {
            bool hasNextPage = true;
            IList<IList<HtmlTableCell>> result = new List<IList<HtmlTableCell>>();
            ClickFirstItem();
            while (hasNextPage)
            {
                hasNextPage = IsLastItemEnable();
                // Code
                foreach (var row in this.Table.Rows)
                {
                    result.Add(row.Cells);
                }
                ClickStepForwardItem();
            }
            return result;
        }

        public int GetRowCount()
        {
            return this.Table.Rows.Count;
        }

        public int GetColumnCount()
        {
            return this.Table.ColumnCount;
        }

        public IList<HtmlTableCell> GetRowByIndex(int rowIndex)
        {
            return this.Table.Rows.ElementAt(rowIndex).Cells;
        }

        public IList<IList<HtmlTableCell>> GetRowByValue(String value)
        {
            IList<IList<HtmlTableCell>> result = new List<IList<HtmlTableCell>>();
            foreach (var row in this.Table.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    if (cell.InnerText.ToLower().Contains(value.ToLower()))
                    {
                        result.Add(row.Cells);
                        break;
                    }
                }
            }

            return result;
        }

        public IList<HtmlTableCell> GetRowByValueInColumn(String value, int columnIndex)
        {
            IList<HtmlTableCell> result = null;
            foreach (var row in this.Table.Rows)
            {
                if (row.Cells[columnIndex].InnerText.ToLower().Contains(value.ToLower())) // do not use TextContent
                {
                    result = row.Cells;
                    break;
                }
            }
            return result;
        }

        public int GetRowIndexByValueInColumn(String value, int columnIndex)
        {
            int result = -1;
            //for (int i = 0; i < this.Table.Rows.Count; i++)
            for (int i = 0; i < GetRowCount(); i++)
            {
                if (this.Table.Rows.ElementAt(i).Cells[columnIndex].InnerText.ToLower().Contains(value.ToLower())) // do not use TextContent
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public IList<HtmlTableCell> GetColumnByIndex(int columnIndex)
        {
            IList<HtmlTableCell> result = new List<HtmlTableCell>();
            foreach (var row in this.Table.Rows)
            {
                result.Add(row.Cells[columnIndex]);
            }
            return result;
        }

        public IList<HtmlTableCell> GetAllColumnByIndex(int columnIndex)
        {
            bool hasNextPage = true;
            IList<HtmlTableCell> result = new List<HtmlTableCell>();
            ClickFirstItem();
            while (hasNextPage)
            {
                hasNextPage = IsLastItemEnable();
                // Code
                foreach (var row in this.Table.Rows)
                {
                    result.Add(row.Cells[columnIndex]);
                }
                ClickStepForwardItem();
            }
            return result;
        }

        public IList<HtmlTableCell> GetColumnByValueInRow(String value, int rowIndex)
        {
            IList<HtmlTableCell> result = null;
            int columnIndex = -1;
            foreach (var cell in GetRowByIndex(rowIndex))
            {
                columnIndex++;
                if (cell.InnerText.ToLower().Contains(value.ToLower()))
                {
                    break;
                }
            }
            if (columnIndex > -1)
            {
                result = GetColumnByIndex(columnIndex);
            }
            return result;
        }

        //public List<Element> GetColumnByValueOfHeader(String value) { return null; }

        //public int GetColumnIndexByValueOfHeader(String value) { return null; }

        public HtmlTableCell GetCell(int rowIndex, int columnIndex)
        {
            return this.Table.Rows.ElementAt(rowIndex).Cells[columnIndex];
        }

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

        // TODO
        public bool IsItemPresent(string text)
        {
            return true;
        }

        // TODO
        public bool IsItemPresent(int columnNumber, string text)
        {
            // Searching
            return true;
        }

        // TODO
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
