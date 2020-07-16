using BE;
using DAL.Interfaces;
using DAL.Utils;
using System;
using System.Collections.Generic;

namespace DAL.Implementation
{
    public class AltaSolicitudDao : BaseDao, IAltaSolicitudDao
    {
        public bool Add(AltaSolicitud obj)
        {
            var query = "INSERT INTO Solicitud VALUES (@producto, @marca, @modelo, @color, @fecha, @detalle, @estado)";
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
                        @fecha = obj.fecha_compra.ToString("yyyy/MM/dd"),
                        @detalle = obj.detalle,
                        @estado = obj.estado
                    });
            });
        }

        public bool Delete(AltaSolicitud obj)
        {
            throw new NotImplementedException();
        }

        public List<AltaSolicitud> Get()
        {
            var query = "SELECT * FROM Solicitud";

            return CatchException(() =>
            {
                return Exec<AltaSolicitud>(
                    query);
            });
        }

        public bool Update(AltaSolicitud obj)
        {
            throw new NotImplementedException();
        }
    }
}
