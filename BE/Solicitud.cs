namespace BE
{
    public class Solicitud
    {
        public int id { get; set; }
        public string producto { get; set; }
        public string fecha { get; set; }
        public string estado { get; set; }

        public Solicitud(int id, string producto, string fecha, string estado)
        {
            this.id = id;
            this.producto = producto;
            this.fecha = fecha;
            this.estado = estado;
        }
    }
}
