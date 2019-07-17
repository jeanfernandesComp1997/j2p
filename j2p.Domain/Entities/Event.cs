using j2p.Domain.Entities.Base;
using j2p.Domain.Enum;
using System;
using System.Collections.Generic;

namespace j2p.Domain.Entities
{
    public class Event : EntityBase
    {
        public virtual string Title { get; protected set; }

        public virtual DateTime Date { get; protected set; }

        public virtual decimal Value { get; protected set; }

        public virtual int LimitPlayers { get; protected set; }

        public virtual EnumStatus Status { get; protected set; }

        public virtual Local Local { get; protected set; }

        public virtual Player Owner { get; protected set; }

        public virtual IList<Player> Players { get; protected set; }

        public Event()
        {

        }

        public Event(string title, DateTime date, decimal value, int limit, EnumStatus status, Local local, Player owner, IList<Player> players)
        {
            Title = title;
            Date = date;
            Value = value;
            LimitPlayers = limit;
            Status = EnumStatus.InAnalyze;
            Local = local;
            Owner = owner;
            Players = players;
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(this.Title))
                _errors.AppendLine("Título inválido.");

            if (this.Date < DateTime.Now)
                _errors.AppendLine("Data do evento inválida.");
        }

        public virtual void AddOwner(Player owner)
        {
            Owner = owner;
        }

        public virtual void AddLocal(Local local)
        {
            Local = local;
        }

        public virtual void SubscribePlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
