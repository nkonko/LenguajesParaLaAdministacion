namespace BLL.Implementation
{
    using BLL.Interfaces;
    using DAL.Interfaces;

    public class RestoreBusiness : IRestoreBusiness
    {
        private readonly IRestoreDao restoreDao;

        public RestoreBusiness(IRestoreDao restoreDao)
        {
            this.restoreDao = restoreDao;
        }

        public bool ExecuteRestore(string rute)
        {
            return restoreDao.ExecuteRestore(rute);
        }
    }
}
