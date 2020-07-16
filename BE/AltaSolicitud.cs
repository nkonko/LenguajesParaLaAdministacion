using System;

namespace BE
{
    public class AltaSolicitud
    {
        public int id { get; set; }

        public string producto { get; set; }

        public string marca { get; set; }

        public string modelo { get; set; }

        public string color { get; set; }

        public DateTime fecha_compra { get; set; }

        public string detalle { get; set; }

        public string estado { get; set; }
    }
}
