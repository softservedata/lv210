using System.Collections.Generic;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System.Linq;

namespace Wow.Pages
{
    public class BasicTable
    {
        private const string ClassAttribute = "class";
        private const string DisableValue = "disabled";
        private Manager manager;
        private readonly Pagination pagination;

        private class Pagination
        {
            public HtmlAnchor FirstItem { get; private set; }
            public HtmlAnchor StepBackItem { get; private set; }
            public HtmlAnchor StepForwardItem { get; private set; }
            public HtmlAnchor LastItem { get; private set; }
            public HtmlAnchor ActiveItem { get; private set; }

            // TODO Develop Builder
            protected internal Pagination(Manager manager, string firstXPath, string stepBackXPath, string stepForwardXPath,
                string lastXPath, string activeXPath)
            {
                this.FirstItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(firstXPath);
                this.StepBackItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(stepBackXPath);
                this.StepForwardItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(stepForwardXPath);
                this.LastItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(lastXPath);
                this.ActiveItem = manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>(activeXPath);
            }
        }

        public HtmlTable Table { get; private set; }

        // TODO Develop Builder
        public BasicTable(Manager manager, string tableAttribute)
        {
            this.manager = manager;
            this.Table = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>(tableAttribute);
        }

        public BasicTable(Manager manager, string tableAttribute, string firstXPath, string stepBackXPath,
            string stepForwardXPath, string lastXPath, string activeXPath)
        {
            this.manager = manager;
            this.Table = manager.ActiveBrowser.Find.ByAttributes<HtmlTable>(tableAttribute);
            this.pagination = new Pagination(manager, firstXPath, stepBackXPath, stepForwardXPath,
                lastXPath, activeXPath);
        }

        public HtmlAnchor GetFirstItem()
        {
            return this.pagination.FirstItem;
        }

        public HtmlAnchor GetStepBackItem()
        {
            return this.pagination.StepBackItem;
        }

        public HtmlAnchor GetStepForwardItem()
        {
            return this.pagination.StepForwardItem;
        }

        public HtmlAnchor GetLastItem()
        {
            return this.pagination.LastItem;
        }

        public HtmlAnchor GetActiveItem()
        {
            return this.pagination.ActiveItem;
        }

        public IList<IList<HtmlTableCell>> GetAllCells()
        {
            bool hasNextPage = true;
            IList<IList<HtmlTableCell>> result = new List<IList<HtmlTableCell>>();
            ClickFirstItem();

            while (hasNextPage)
            {
                hasNextPage = IsLastItemEnabled();

                foreach (var row in this.Table.Rows)
                {
                    result.Add(row.Cells);
                }

                ClickStepForwardItem();
            }

            return result;
        }

        public IList<IList<HtmlTableCell>> GetAllCellsFromCurrentPage()
        {
            return this.Table.Rows.Select(row => row.Cells).Cast<IList<HtmlTableCell>>().ToList();
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

        public IList<IList<HtmlTableCell>> GetRowByValue(string value)
        {
            IList<IList<HtmlTableCell>> result = new List<IList<HtmlTableCell>>();

            foreach (var row in this.Table.Rows)
            {
                if (row.Cells.Any(cell => cell.InnerText.Contains(value)))
                {
                    result.Add(row.Cells);
                }
            }

            return result;
        }

        public IList<HtmlTableCell> GetRowByValueInColumn(string value, int columnIndex)
        {
            IList<HtmlTableCell> result = null;

            foreach (var row in this.Table.Rows)
            {
                if (row.Cells[columnIndex].InnerText.Contains(value))
                {
                    result = row.Cells;
                    break;
                }
            }

            return result;
        }

        public int GetRowIndexByValueInColumn(string value, int columnIndex)
        {
            int result = -1;

            for (int i = 0; i < this.Table.Rows.Count; i++)
            {
                if (this.Table.Rows.ElementAt(i).Cells[columnIndex].InnerText.Contains(value))
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

        public IList<HtmlTableCell> GetColumnByValueInRow(string value, int rowIndex)
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

        public IList<HtmlTableCell> GetAllColumnByIndex(int columnIndex)
        {
            bool hasNextPage = true;
            IList<HtmlTableCell> result = new List<HtmlTableCell>();
            ClickFirstItem();

            while (hasNextPage)
            {
                hasNextPage = IsLastItemEnabled();

                foreach (var row in this.Table.Rows)
                {
                    result.Add(row.Cells[columnIndex]);
                }

                ClickStepForwardItem();
            }

            return result;
        }

        public HtmlTableCell GetCell(int rowIndex, int columnIndex)
        {
            return this.Table.Rows[rowIndex].Cells[columnIndex];
        }

        public bool IsFirstItemEnabled()
        {
            return this.HasPagination()
                   && !this.GetItemParent(this.pagination.FirstItem)
                       .BaseElement.GetAttributeValueOrEmpty(ClassAttribute)
                       .ToLower()
                       .Contains(DisableValue);
        }

        public bool IsStepBackItemEnabled()
        {
            return this.HasPagination()
                   && !this.GetItemParent(this.pagination.StepBackItem)
                       .BaseElement.GetAttributeValueOrEmpty(ClassAttribute)
                       .ToLower()
                       .Contains(DisableValue);
        }

        public bool IsStepForwardItemEnabled()
        {
            return this.HasPagination()
                   && !this.GetItemParent(this.pagination.StepForwardItem)
                       .BaseElement.GetAttributeValueOrEmpty(ClassAttribute)
                       .ToLower()
                       .Contains(DisableValue);
        }

        public bool IsLastItemEnabled()
        {
            return this.HasPagination()
                   && !this.GetItemParent(this.pagination.LastItem)
                       .BaseElement.GetAttributeValueOrEmpty(ClassAttribute)
                       .ToLower()
                       .Contains(DisableValue);
        }

        public bool AreAllPaginationElementsEnabled()
        {
            return IsFirstItemEnabled() && IsStepBackItemEnabled() &&
                IsLastItemEnabled() && IsStepForwardItemEnabled();
        }

        // Functional
        private void RefreshTable()
        {
            this.Table.Refresh();
        }

        private void RefreshPagination()
        {
            this.RefreshTable();

            if (this.HasPagination())
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
            return this.pagination != null;
        }

        private HtmlListItem GetItemParent(HtmlAnchor htmlAnchor)
        {
            return htmlAnchor.Parent<HtmlListItem>();
        }

        // Set Data
        public void ClickFirstItem()
        {
            if (this.IsFirstItemEnabled())
            {
                this.pagination.FirstItem.Click();
                this.RefreshPagination();
            }
        }

        public void ClickStepBackItem()
        {
            if (this.IsStepBackItemEnabled())
            {
                this.pagination.StepBackItem.Click();
                this.RefreshPagination();
            }
        }

        public void ClickStepForwardItem()
        {
            if (this.IsStepForwardItemEnabled())
            {
                this.pagination.StepForwardItem.Click();
                this.RefreshPagination();
            }
        }

        public void ClickLastItem()
        {
            if (this.IsLastItemEnabled())
            {
                this.pagination.LastItem.Click();
                this.RefreshPagination();
            }
        }
    }
}