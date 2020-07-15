namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL;
    using DAL.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BitacoraBusiness : IBitacoraBusiness
    {
        private const string bitacoraDb = "Bitacora";

        private readonly IBitacoraDao bitacoraDao;
        private readonly IDigitVerifier verifier;

        public BitacoraBusiness(IBitacoraDao bitacoraDao, IDigitVerifier verifier)
        {
            this.bitacoraDao = bitacoraDao;
            this.verifier = verifier;
        }

        public List<Bitacora> GetBitacora(List<string> usuarios, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            return bitacoraDao.GetBitacora(usuarios, criticidades, desde, hasta);
        }

        public List<Bitacora> GetBitacora()
        {
            return bitacoraDao.GetBitacora();
        }

        public void UpdateBitacoraDvh()
        {
            var bitacora = bitacoraDao.GetBitacora().LastOrDefault();

            var dvh = verifier.CalculateDVH(bitacora.GetFinalString());

            verifier.UpdateDvh(bitacoraDb, bitacora.IdLog, dvh);
        }
    }
}
