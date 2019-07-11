using FluentNHibernate.Mapping;
using j2p.Domain.Entities;

namespace j2p.Infra.Data.NHibernate.Mapping
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Id(x => x.Id);

            Map(x => x.Title).Length(50).Not.Nullable();
            Map(x => x.Date).Not.Nullable();
            Map(x => x.Value).Not.Nullable().Precision(9).Scale(2).Default("0,00");
            Map(x => x.Limit).Not.Nullable();
            Map(x => x.Status).Length(35).Not.Nullable();

            References(x => x.Owner).Column("OwnerId").ForeignKey("FK_Owner_Event");
            HasManyToMany(x => x.Players).Table("event_player").Cascade.All().Inverse();
        }
    }
}
