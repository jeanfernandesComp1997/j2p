
namespace j2p.Domain.Interfaces.Repositories
{
    public interface IUoWRepository
    {
        IPlayerRepository PlayerRepository { get; }

        IEventRepository EventRepository { get; }

        IOwnerRepository OwnerRepository { get; }

        void BeginTransaction();

        void Commit(object obj = null);
    }
}
