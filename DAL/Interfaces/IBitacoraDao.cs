using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBitacoraDao
    {


       // void guardarRegistro(BE.Bitacora registro);

        void Error(int id_usu, string funcionalidad, string descripcion, DateTime fecha);
        void Warning(int id_usu, string funcionalidad, string descripcion, DateTime fecha);
        void Info(int id_usu, string funcionalidad, string descripcion, DateTime fecha);


        List<BE.Bitacora> ObtenerTodos();

        List<BE.Bitacora> ObtenerFiltro(DateTime desde, DateTime hasta, string idusu, string criticidad);
    }
}
