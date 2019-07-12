using j2p.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace j2p.Domain.Entities
{
    public class Event : EntityBase
    {
        public virtual string Title { get; protected set; }

        public virtual DateTime Date { get; protected set; }

        public virtual double Value { get; protected set; }

        public virtual int Limit { get; protected set; }

        public virtual string Status { get; protected set; }

        public virtual Player Owner { get; protected set; }

        public virtual List<Player> Players { get; protected set; }

        public Event()
        {

        }

        public Event(string title, DateTime date, double value, int limit, string status, Player owner, List<Player> players)
        {
            Title = title;
            Date = date;
            Value = value;
            Limit = limit;
            Status = status;
            Owner = owner;
            Players = players;
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

        public virtual void AddOwner(Player owner)
        {
            Owner = owner;
        }
    }
}
