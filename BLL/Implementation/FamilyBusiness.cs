namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL.Interfaces;
    using System.Collections.Generic;

    public class FamilyBusiness : IFamilyBusiness
    {
        private readonly IFamilyDao familyDao;

        public FamilyBusiness(IFamilyDao familyDao)
        {
            this.familyDao = familyDao;
        }

        public bool Add(Family obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Family obj)
        {
            throw new System.NotImplementedException();
        }

        public List<Family> Get()
        {
            throw new System.NotImplementedException();
        }

        public List<Family> GetFamilies(int userId)
        {
            return familyDao.GetUserFamily(userId);
        }

        public bool Update(Family obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
