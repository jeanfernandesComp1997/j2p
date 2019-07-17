using FluentNHibernate.Mapping;
using j2p.Domain.Entities;

namespace j2p.Infra.Data.NHibernate.Mapping
{
    public class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Id(x => x.Id);

            Map(x => x.FirstName).Length(50).Not.Nullable();
            Map(x => x.LastName).Length(50).Not.Nullable();
            Map(x => x.Email).Length(200).Not.Nullable();
            Map(x => x.Password).Length(200).Not.Nullable();
            Map(x => x.Phone).Length(35).Not.Nullable();
            Map(x => x.Picture).Nullable();

            //HasManyToMany(x => x.Events).Table("event_player").Cascade.All().Inverse();
            HasManyToMany(x => x.Events).Table("event_player").ParentKeyColumn("EventId").ChildKeyColumn("PlayerId").Inverse();
        }
    }
}
