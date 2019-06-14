
namespace j2p.Domain.Interfaces.Repositories
{
    public interface IUoWRepository
    {
        IPlayerRepository PlayerRepository { get; }

        IOwnerRepository OwnerRepository { get; }

        void BeginTransaction();

        void Commit(object obj = null);
    }
}
