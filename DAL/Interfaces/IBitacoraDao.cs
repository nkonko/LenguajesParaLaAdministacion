namespace DAL
{
    using BE;
    using System;
    using System.Collections.Generic;

    public interface IBitacoraDao
    {
        List<Bitacora> GetBitacora(List<string> users, List<string> criticalities, DateTime from, DateTime to);

        List<Bitacora> GetBitacora();
    }
}
