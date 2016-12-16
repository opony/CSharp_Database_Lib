using System.Data;

namespace DatabaseLib.Interface
{
    public interface IDatabase
    {
        IDbConnection GetConnection();

        void Close();

        void BeginTrans();

        void CommitTrans();

        void RollBackTrans();

        DataTable ExecuteResult(IDbCommand cmd);

        void ExecuteNonQuery(IDbCommand cmd);
    }
}