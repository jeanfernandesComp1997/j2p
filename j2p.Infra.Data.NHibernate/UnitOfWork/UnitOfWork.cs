using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using j2p.Domain.Interfaces.Repositories;
using j2p.Infra.Data.NHibernate.Repositories;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;


namespace j2p.Infra.Data.NHibernate.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUoWRepository
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        private IPlayerRepository playerRepository;
        private IEventRepository eventRepository;
        private ILocalRepository localRepository;

        public ISession Session { get; private set; }

        public IPlayerRepository PlayerRepository
        {
            get { return playerRepository ?? (playerRepository = new PlayerRepository(this.Session)); }
        }

        public IEventRepository EventRepository
        {
            get { return eventRepository ?? (eventRepository = new EventRepository(this.Session)); }
        }

        public ILocalRepository LocalRepository
        {
            get { return localRepository ?? (localRepository = new LocalRepository(this.Session)); }
        }

        public IOwnerRepository OwnerRepository => throw new NotImplementedException();

        static UnitOfWork()
        {
            string conn = "server=localhost;port=3306;database=j2p;uid=root;password=jcfm123987";

            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(conn))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Mapping.PlayerMap>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Mapping.EventMap>())
                .ExposeConfiguration(x => x.Properties.Add("hbm2ddl.keywords", "none"))
                .ExposeConfiguration(x => new SchemaUpdate(x).Execute(true, true))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            this.Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = this.Session.BeginTransaction();
        }

        public void Commit(object obj = null)
        {
            try
            {
                _transaction.Commit();

                if (obj != null)
                    this.Session.Refresh(obj);

                this.Session.Flush();

            }
            catch (Exception ex)
            {
                _transaction.Rollback();

                throw ex;
            }
        }

        public void Dispose()
        {
            if (this.Session.IsOpen)
                this.Session.Close();
        }
    }
}
