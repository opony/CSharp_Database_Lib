using DatabaseLib.Interface;
using System;
using System.Data;

namespace DatabaseLib.DataBase
{
    public abstract class ADatabase : IDatabase
    {
        protected IDbConnection conn = null;
        protected IDbTransaction trans = null;
        
        public abstract IDbConnection GetConnection();

        public void Close()
        {
            if (trans != null)
            {
                return;
            }

            try
            {
                
                this.conn.Close();
            }
            catch (Exception)
            {
            }
            
            this.conn = null;
        }

        public abstract DataTable ExecuteResult(IDbCommand cmd);

        public abstract void ExecuteNonQuery(IDbCommand cmd);
        public void BeginTrans()
        {
            GetConnection();

            trans = this.conn.BeginTransaction();
        }
        public void CommitTrans()
        {
            trans.Commit();
            trans = null;
            Close();
        }
        public void RollBackTrans()
        {
            trans.Rollback();
            trans = null;
            Close();
        }
    }
}