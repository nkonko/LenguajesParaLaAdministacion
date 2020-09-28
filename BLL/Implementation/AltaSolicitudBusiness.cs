namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL.Interfaces;
    using System;
    using System.Collections.Generic;

    public class AltaSolicitudBusiness : IAltaSolicitudBusiness
    {
        private readonly IAltaSolicitudDao altaSolicitudDao;

        public AltaSolicitudBusiness(IAltaSolicitudDao solDao)
        {
            altaSolicitudDao = solDao;
        }
        public bool Add(AltaSolicitud obj)
        {
            return altaSolicitudDao.Add(obj);
        }

        public bool Delete(AltaSolicitud obj)
        {
            throw new NotImplementedException();
        }

        public List<AltaSolicitud> Get()
        {
            return altaSolicitudDao.Get();
        }

        public bool Update(AltaSolicitud obj)
        {
            throw new NotImplementedException();
        }
    }
}
