using System;
using System.Collections.ObjectModel;
using ViewModelTest.Persistency;

namespace ViewModelTest.Model
{
    class EventCatalogSingleton
    {
        public ObservableCollection<Event> Eventlist { get; set; }
        private static readonly EventCatalogSingleton _instance = new EventCatalogSingleton();
        public static EventCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public EventCatalogSingleton()
        {
            Eventlist = new ObservableCollection<Event>();
            LoadEventAsync();
            /*Eventlist.Add(new Event("test","test","test",new DateTime(2016,03,25,16,30,00)));
            Eventlist.Add(new Event("test2","test2","test2",new DateTime(2016,03,25,16,30,00)));*/
        }
        public async void LoadEventAsync()
        {
            var events = await PersistencyService.LoadEvents();
            if (events != null)
            {
                foreach (var myevent in events)
                {
                    Eventlist.Add(myevent);
                }
            }
        }
        public void AddToList(Event newevent)
        {
            Eventlist.Add(newevent);
            PersistencyService.SaveEvent(newevent);

        }

        public void RemoveEvent(Event deletevent)
        {
            Eventlist.Remove(deletevent);
            PersistencyService.DeleteEvent(deletevent);
        }
        public void UpdateHotelAsync(Event updateevent)
        {
            Eventlist.Add(updateevent);
            PersistencyService.UpdateEvent(updateevent);
        }
    }
}
