namespace PagingControlProject
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Database;
    using GalaSoft.MvvmLight.Command;
    using Properties;

    public class MainViewModel : INotifyPropertyChanged
    {
        private object filter;

        public RelayCommand<SortData> SortCommand => new RelayCommand<SortData>(sort => Filter = sort);

        public MyService Service { get; set; } = new MyService();

        public object Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}