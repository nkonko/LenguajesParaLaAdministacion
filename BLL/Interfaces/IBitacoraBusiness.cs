namespace BLL.Interfaces
{
    using BE;
    using System;
    using System.Collections.Generic;

    public interface IBitacoraBusiness
    {
        List<Bitacora> GetBitacora();

        List<Bitacora> GetBitacora(List<string> usuarios, List<string> criticidades, DateTime desde, DateTime hasta);

        void UpdateBitacoraDvh();
    }
}