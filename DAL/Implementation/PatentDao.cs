namespace DAL.Implementation
{
    using BE;
    using DAL.Interfaces;
    using DAL.Utils;
    using System.Collections.Generic;

    public class PatentDao : BaseDao, IPatentDao
    {
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

        public List<Patent> GetUserPatents(int id)
        {
            var queryString = "SELECT UsuarioPatente.IdPatente, Descripcion FROM UsuarioPatente INNER JOIN Patente ON UsuarioPatente.IdPatente = Patente.IdPatente WHERE UsuarioId = @usuarioId";

            return CatchException(() =>
            {
                return Exec<Patent>(queryString, new { @usuarioId = id });
            });
        }

        public bool Update(Patent obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
