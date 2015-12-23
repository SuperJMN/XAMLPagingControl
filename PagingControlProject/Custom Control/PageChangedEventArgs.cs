namespace PagingControlProject.Custom_Control
{
    using System.Windows;

    public class PageChangedEventArgs : RoutedEventArgs
    {
        #region PRIVATE VARIABLES

        private int _OldPage, _NewPage, _TotalPages;

        #endregion

        #region PROPERTIES

        public int OldPage
        {
            get
            {
                return _OldPage;
            }
        }

        public int NewPage
        {
            get
            {
                return _NewPage;
            }
        }

        public int TotalPages
        {
            get
            {
                return _TotalPages;
            }
        }

        #endregion

        #region CONSTRUCTOR

        public PageChangedEventArgs(RoutedEvent EventToRaise, int OldPage, int NewPage, int TotalPages)
            : base(EventToRaise)
        {
            _OldPage = OldPage;
            _NewPage = NewPage;
            _TotalPages = TotalPages;
        }

        #endregion
    }
}