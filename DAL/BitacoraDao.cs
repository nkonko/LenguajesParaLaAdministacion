using DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BitacoraDao : BaseDao, IBitacoraDao
    {

        #region Singleton

        public static BitacoraDao instancia;

        public static BitacoraDao GetInstance()
        {
            if (instancia == null)
            {
                return new BitacoraDao();
            }
            return instancia;
        }
        #endregion

        BE.Bitacora bebit = new BE.Bitacora();

        public void Error( int id_usu, string funcionalidad, string descripcion, DateTime fecha)
        {
           
            bebit.id_usuario = id_usu;
            bebit.funcionalidad = funcionalidad;
            bebit.criticidad = "ALTA";
            bebit.descripcion = descripcion;
            bebit.fecha = fecha;
            
            guardarRegistro(bebit);
            //Calculo DVH?

        }

        public void Warning(int id_usu, string funcionalidad, string descripcion, DateTime fecha)
        {

            bebit.id_usuario = id_usu;
            bebit.funcionalidad = funcionalidad;
            bebit.criticidad = "MEDIA";
            bebit.descripcion = descripcion;
            bebit.fecha = fecha;

            guardarRegistro(bebit);
            //Calculo DVH?

        }

        public void Info(int id_usu, string funcionalidad, string descripcion, DateTime fecha)
        {

            bebit.id_usuario = id_usu;
            bebit.funcionalidad = funcionalidad;
            bebit.criticidad = "BAJA";
            bebit.descripcion = descripcion;
            bebit.fecha = fecha;

            guardarRegistro(bebit);
            //Calculo DVH?

        }

        private void guardarRegistro(BE.Bitacora registro)
        {

            string query = string.Format("INSERT INTO Bitacora VALUES ('{0}' , '{1}', '{2}', '{3}' , '{4}' )", registro.id_usuario, registro.funcionalidad, registro.criticidad, registro.descripcion, registro.fecha.ToString("yyyy-MM-dd"));

            try
            {
                //ExecuteQuery.

                Exec(query);

                //Calcular DVV.

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Bitacora> ObtenerTodos()
        {

            var query = "select id_log, id_usuario, funcionalidad, criticidad, descripcion, fecha from Bitacora";


            return CatchException(() =>
            {
                return Exec<BE.Bitacora>(query);
            });
        }

        public List<BE.Bitacora> ObtenerFiltro(DateTime desde, DateTime hasta, string idusu, string criticidad)
        {

            string query = string.Format("select * from Bitacora where fecha BETWEEN '{0}' AND '{1}'  AND criticidad like '{2}' AND id_usuario like '{3}'", desde.ToString("yyyy-MM-dd"), hasta.ToString("yyyy-MM-dd"), criticidad, idusu);

            return CatchException(() =>
            {
                return Exec<BE.Bitacora>(query);
            });



        }




    }
}


