namespace DAL
{
    using BE;
    using DAL.Utils;
    using EasyEncryption;
    using System;
    using System.Collections.Generic;

    public class BitacoraDao : BaseDao, IBitacoraDao
    {
        public const string Key = "bZr2URKx";
        public const string Code = "HNtgQw0w";

        public List<Bitacora> GetBitacora(List<string> users, List<string> criticalities, DateTime from, DateTime to)
        {
            var queryImpl = "SELECT * from Bitacora WHERE ";
            var idsUsuParameters = string.Empty;
            var param = string.Empty;
            var coma = string.Empty;
            var query = string.Empty;
            var bitacoras = new List<Bitacora>();

            if (users.Count != 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (i != 0)
                    {
                        coma = ",";
                    }

                    idsUsuParameters += coma + "'" + users[i] + "'";
                }

                queryImpl += string.Format("Usuario IN ({0}) AND  ", idsUsuParameters);
            }

            coma = string.Empty;
            if (criticalities.Count != 0)
            {
                for (int i = 0; i < criticalities.Count; i++)
                {
                    if (i != 0)
                    {
                        coma = ",";
                    }

                    param += coma + "'" + criticalities[i] + "'";
                }

                queryImpl += string.Format("Criticidad IN ({0}) AND  ", param);
            }

            query = string.Format(queryImpl + " Fecha BETWEEN '{0}' AND '{1}'", from.ToShortDateString(), to);

            CatchException(() =>
            {
                bitacoras = Exec<Bitacora>(query);
            });

            bitacoras.ForEach(x => x.InformacionAsociada = DES.Decrypt(x.InformacionAsociada, Key, Code));

            return bitacoras;
        }

        public List<Bitacora> GetBitacora()
        {

            var query = "SELECT * FROM Bitacora order by fecha ASC";


            return CatchException(() =>
            {
                return Exec<Bitacora>(query);
            });
        }
    }
}


