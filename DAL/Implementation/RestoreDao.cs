namespace DAL.Implementation
{
    using DAL.Interfaces;
    using DAL.Utils;

    public class RestoreDao : BaseDao, IRestoreDao
    {
        public bool ExecuteRestore(string _BackupName)
        {
            var query = "use [Master] ALTER DATABASE [Tatooine] SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [Tatooine] FROM DISK= @_BackupName With REPLACE";

            return CatchException(() =>
            {
                return Exec(
                    query,
                    new
                    {
                        @_BackupName = _BackupName

                    });
            });
        }

       
    }
}
