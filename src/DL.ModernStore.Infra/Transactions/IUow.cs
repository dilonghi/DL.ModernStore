namespace DL.ModernStore.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
