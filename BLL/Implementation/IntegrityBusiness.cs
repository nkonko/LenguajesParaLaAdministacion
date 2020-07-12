namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL.Interfaces;

    public class IntegrityBusiness : IIntegrityBusiness
    {
        private const string entity = "Userdb";

        private readonly IDigitVerifier digitVerifier;
        private readonly IUserDao userDao;

        public IntegrityBusiness(IDigitVerifier digitVerifier, IUserDao userDao)
        {
            this.digitVerifier = digitVerifier;
            this.userDao = userDao;
        }

        public bool CheckIntegrity()
        {
            var users = userDao.Get();
            return digitVerifier.CheckIntegrity(entity, users);
        }

        public void UpdateIntegrity()
        {
            digitVerifier.UpdateDVV(entity);
        }
    }
}
