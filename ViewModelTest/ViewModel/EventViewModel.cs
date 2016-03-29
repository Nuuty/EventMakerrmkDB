using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Eventmaker.Common;
using ViewModelTest.Annotations;
using ViewModelTest.Model;
using ViewModelTest.Handler;

namespace ViewModelTest.ViewModel
{
    class EventViewModel : INotifyPropertyChanged
    {
        private DateTimeOffset _date;
        private TimeSpan _time;
        public EventCatalogSingleton Catalog { get; } = EventCatalogSingleton.Instance;

        public String Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        public String Place
        {
            get { return _place; }
            set { _place = value; OnPropertyChanged(); }
            
        }

        private Event _selecteditem;

        public Event Selecteditem
        {
            get { return _selecteditem; }
            set { _selecteditem = value;OnPropertyChanged(); }
        }

        public Handler.EventHandler EventHandler { get; set; }
        private ICommand _createEventCommand;
        private string _description;
        private string _name;
        private string _place;
        private ICommand _deleteEventCommand;
        public ICommand CreateEventCommand
        {
            get { return _createEventCommand ?? (_createEventCommand = new RelayCommand(EventHandler.CreateEvent)); }
        }
        public ICommand DeleteEventCommand
        {
            get { return _deleteEventCommand ?? (_deleteEventCommand = new RelayCommand(EventHandler.DeleteEvent)); }
        }

        private ICommand _updateEventCommand;

        public ICommand UpdateEventCommand
        {
            get { return _updateEventCommand ?? (_updateEventCommand = new RelayCommand(EventHandler.UpdateEvent)); }
            
        }

        public DateTimeOffset Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }

        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; OnPropertyChanged(); }
        }

        public EventViewModel()
        {
            EventHandler = new Handler.EventHandler(this);
            DateTime dt = System.DateTime.Now;

            _date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            _time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
