using FluentNHibernate.Mapping;
using j2p.Domain.Entities;

namespace j2p.Infra.Data.NHibernate.Mapping
{
    public class OwnerMap : ClassMap<Owner>
    {
        public OwnerMap()
        {
            Id(x => x.Id);

            Map(x => x.FirstName).Length(50).Not.Nullable();
            Map(x => x.LastName).Length(50).Not.Nullable();
            Map(x => x.Email).Length(200).Not.Nullable();
            Map(x => x.Password).Length(200).Not.Nullable();
            Map(x => x.Phone).Length(35).Not.Nullable();
            Map(x => x.Cnpj).Length(35).Nullable();
            Map(x => x.Cpf).Length(35).Not.Nullable();
        }
    }
}
