using BE;
using DAL.Interfaces;
using DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class AltaSolicitudDao : BaseDao, IAltaSolicitudDao
    {
        public bool Add(AltaSolicitud obj)
        {
            var query = "INSERT INTO Solicitud VALUES (@producto, @marca, @modelo, @color, @fecha, @detalle)";
            //convert(datetime, '" + obj.fecha_compra.ToString("yyyy-MM-dd HH:mm:ss") + "',101),'" 
            return CatchException(() =>
            {
                return Exec(
                    query,
                    new
                    {
                        @producto = obj.producto,
                        @marca = obj.marca,
                        @modelo = obj.modelo,
                        @color = obj.color,
                        @fecha = obj.fecha_compra.ToString(),
                        @detalle = obj.detalle
                    });
            });
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
