using System;

namespace j2p.Presentation.Api.ViewModels
{
    public class EventViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public int Limit { get; set; }

        public string Status { get; set; }
    }
}
