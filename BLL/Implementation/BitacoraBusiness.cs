namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL;
    using System;
    using System.Collections.Generic;

    public class BitacoraBusiness : IBitacoraBusiness
    {
        private readonly IBitacoraDao bitacora;

        public BitacoraBusiness(IBitacoraDao bitacora)
        {
            this.bitacora = bitacora;
        }

        public List<Bitacora> GetBitacora(List<string> usuarios, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            return bitacora.GetBitacora(usuarios, criticidades, desde, hasta);
        }

        public List<Bitacora> GetBitacora()
        {
            return bitacora.GetBitacora();
        }
    }
}
