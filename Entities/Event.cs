namespace DevEvents.API.Entities
{
    public class Event
    {
        public Event(string title, string description, string organization, DateTime initialDate, DateTime finalDate)
        {
            Title = title;
            Description = description;
            Organization = organization;
            InitialDate = initialDate;
            FinalDate = finalDate;

            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organization { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime CreationDate { get; set; }

        public void Update(string title, string description, DateTime initialDate, DateTime finalDate)
        {
            Title = title;
            Description = description;
            InitialDate = initialDate;
            FinalDate = finalDate;
        }
    }
}