﻿using FluentNHibernate.Cfg;
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
        private IOwnerRepository ownerRepository;
        

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

        public IOwnerRepository OwnerRepository
        {
            get { return ownerRepository ?? (ownerRepository = new OwnerRepository(this.Session)); }
        }

        static UnitOfWork()
        {
            string conn = Environment.GetEnvironmentVariable("CONNECTION");

            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(conn))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Mapping.PlayerMap>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Mapping.EventMap>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Mapping.LocalMap>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Mapping.OwnerMap>())
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
