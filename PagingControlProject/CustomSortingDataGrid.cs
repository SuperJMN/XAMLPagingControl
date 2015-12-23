namespace PagingControlProject
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class CustomSortingDataGrid : DataGrid
    {
        public CustomSortingDataGrid()
        {
            Sorting += OnSorting;
        }

        private void OnSorting(object sender, DataGridSortingEventArgs eventArgs)
        {
            eventArgs.Handled = true;
            if (SortCommand != null)
            {
                var column = eventArgs.Column;
                var sortDirection = GetNextSortDirection(column.SortDirection);
                column.SortDirection = sortDirection;
                SortCommand.Execute(new SortData(column.Header.ToString(), sortDirection));
            }
        }

        public static readonly DependencyProperty SortCommandProperty = DependencyProperty.Register(
            "SortCommand",
            typeof(ICommand),
            typeof(CustomSortingDataGrid),
            new PropertyMetadata(default(ICommand)));

        public ICommand SortCommand
        {
            get { return (ICommand)GetValue(SortCommandProperty); }
            set { SetValue(SortCommandProperty, value); }
        }

        private ListSortDirection? GetNextSortDirection(ListSortDirection? sortDirection)
        {
            if (!sortDirection.HasValue)
            {
                return ListSortDirection.Ascending;
            }
            else
            {
                if (sortDirection == ListSortDirection.Ascending)
                {
                    return ListSortDirection.Descending;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}