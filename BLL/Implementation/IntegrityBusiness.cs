namespace BLL.Implementation
{
    using BLL.Interfaces;
    using DAL.Interfaces;

    public class IntegrityBusiness : IIntegrityBusiness
    {
        private readonly IDigitVerifier digitVerifier;

        public IntegrityBusiness(IDigitVerifier digitVerifier)
        {
            this.digitVerifier = digitVerifier;
        }

        public bool CheckIntegrity(string entity)
        {
            return digitVerifier.CheckIntegrity(entity);
        }

        public void UpdateIntegrity(string entity)
        {
            digitVerifier.UpdateDVV(entity);
        }
    }
}
