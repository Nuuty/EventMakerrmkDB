using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ViewModelTest.Converter;
using ViewModelTest.Model;
using ViewModelTest.ViewModel;

namespace ViewModelTest.Handler
{
    class EventHandler
    {
        public EventViewModel EventVM { get; set; }

        public EventHandler(EventViewModel eventVm)
        {
            EventVM = eventVm;
        }
        public void CreateEvent()
        {
            var date = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventVM.Date, EventVM.Time);
            EventVM.Catalog.AddToList(new Event(EventVM.Name, EventVM.Description, EventVM.Place, date));
            ((Frame)Window.Current.Content).Navigate(typeof(View.EventPage));

        }

        public void DeleteEvent()
        {
            EventVM.Catalog.RemoveEvent(EventVM.Selecteditem);
        }

        public void UpdateEvent()
        {
            EventVM.Catalog.UpdateHotelAsync(EventVM.Selecteditem);
            ((Frame)Window.Current.Content).Navigate(typeof(View.EventPage));
            EventVM.Catalog.Eventlist.Clear();
            EventVM.Catalog.LoadEventAsync();
        }
    }
}
