namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using System;
    using System.Collections.Generic;

    public class AltaSolicitudBusiness : IAltaSolicitudBusiness
    {
        DAL.Implementation.AltaSolicitudDao sol_DAL = new DAL.Implementation.AltaSolicitudDao();

        public bool Add(AltaSolicitud obj)
        {
            return sol_DAL.Add(obj);
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
