namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL.Interfaces;
    using System;
    using System.Collections.Generic;

    public class AltaSolicitudBusiness : IAltaSolicitudBusiness
    {
        //DAL.Implementation.AltaSolicitudDao sol_DAL = new DAL.Implementation.AltaSolicitudDao();

        private readonly IAltaSolicitudDao altaSolicitudDao;

        public AltaSolicitudBusiness(IAltaSolicitudDao solDao)
        {
            this.altaSolicitudDao = solDao;
        }
        public bool Add(AltaSolicitud obj)
        {
            return this.altaSolicitudDao.Add(obj);
        }

        public bool Delete(AltaSolicitud obj)
        {
            throw new NotImplementedException();
        }

        public List<AltaSolicitud> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(AltaSolicitud obj)
        {
            throw new NotImplementedException();
        }
    }
}
