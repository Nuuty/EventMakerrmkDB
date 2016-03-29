namespace ViewModelTest.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Place { get; set; }

        public DateTime DateTime { get; set; }
        private static int _idcounter;

        public Event(string name, string description,string place, DateTime dateTime)
        {
            Id = ++_idcounter;
            Name = name;
            Description = description;
            Place = place;
            DateTime = dateTime;
        }

        protected bool Equals(Event other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Event) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, Place: {Place}, DateTime: {DateTime}";
        }
    }
}
