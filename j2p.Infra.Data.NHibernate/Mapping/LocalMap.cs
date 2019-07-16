using FluentNHibernate.Mapping;
using j2p.Domain.Entities;

namespace j2p.Infra.Data.NHibernate.Mapping
{
    public class LocalMap : ClassMap<Local>
    {
        public LocalMap()
        {
            Id(x => x.Id);

            Map(x => x.Country).Length(2).Not.Nullable();
            Map(x => x.State).Length(2).Not.Nullable();
            Map(x => x.City).Length(50).Not.Nullable();
            Map(x => x.Cep).Length(15).Not.Nullable();
            Map(x => x.Street).Length(50).Not.Nullable();
            Map(x => x.Number).Length(10).Not.Nullable();
            Map(x => x.Complement).Length(100).Nullable();
            Map(x => x.Phone).Length(35).Not.Nullable();
            Map(x => x.Type).Length(10).Not.Nullable();

            References(x => x.Owner).Column("OwnerId").ForeignKey("FK_Owner_Local");
            HasManyToMany(x => x.Events).Table("local_event").Cascade.All();
        }
    }
}
