using System.ComponentModel;

namespace DataVirtualization
{
    public class DataWrapper<T> : INotifyPropertyChanged where T : class
    {
        private int index;
        private T data;

        public event PropertyChangedEventHandler PropertyChanged;

        public DataWrapper(int index)
        {
            this.index = index;
        }

        public int Index
        {
            get { return index; }
        }

        public int ItemNumber
        {
            get { return index + 1; }
        }

        public bool IsLoading
        {
            get { return Data == null; }
        }

        public T Data
        {
            get { return data; }
            internal set
            {
                data = value;
                OnPropertyChanged("Data");
                OnPropertyChanged("IsLoading");
            }
        }

        public bool IsInUse
        {
            get { return PropertyChanged != null; }
        }

        private void OnPropertyChanged(string propertyName)
        {
            System.Diagnostics.Debug.Assert(GetType().GetProperty(propertyName) != null);
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static implicit operator T(DataWrapper<T> i) { return i.Data; }
    }
}
