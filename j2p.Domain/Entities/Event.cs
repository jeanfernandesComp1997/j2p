using j2p.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace j2p.Domain.Entities
{
    public class Event : EntityBase
    {
        public string Title { get; protected set; }

        public DateTime Date { get; protected set; }

        public double Value { get; protected set; }

        public int Limit { get; protected set; }

        public string Status { get; protected set; }

        public Player Organizer { get; protected set; }

        public ICollection<Player> Players { get; protected set; }

        public Local Local { get; protected set; }

        protected Event()
        {

        }

        public Event(string title, DateTime date, double value, int limit, string status, Player organizer, ICollection<Player> players, Local local)
        {
            Title = title;
            Date = date;
            Value = value;
            Limit = limit;
            Status = status;
            Organizer = organizer;
            Players = players;
            Local = local;
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(this.Title))
                _errors.AppendLine("Título inválido.");

            if (this.Date < DateTime.Now)
                _errors.AppendLine("Data do evento inválida.");

            if (string.IsNullOrEmpty(this.Status))
                _errors.AppendLine("Status do evento inválido.");
        }
    }
}
