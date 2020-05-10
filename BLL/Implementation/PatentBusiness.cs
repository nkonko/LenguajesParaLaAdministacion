namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL.Interfaces;
    using System.Collections.Generic;

    public class PatentBusiness : IPatentBusiness
    {
        private readonly IPatentDao patentDao;

        public PatentBusiness(IPatentDao patentDao)
        {
            this.patentDao = patentDao;
        }

        public bool Add(Patent obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Patent obj)
        {
            throw new System.NotImplementedException();
        }

        public List<Patent> Get()
        {
            throw new System.NotImplementedException();
        }

        public List<Patent> GetPatentsByFamily(int familyId)
        {
            return patentDao.GetFamilyPatents(familyId);
        }

        public List<Patent> GetPatentsByUser(int userId)
        {
            return patentDao.GetUserPatents(userId);
        }

        public bool Update(Patent obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
