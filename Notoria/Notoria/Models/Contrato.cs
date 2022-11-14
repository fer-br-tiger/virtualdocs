namespace Notoria.Models
{
    public class Contrato
    {
        public Contrato()
        {
            
        }

        public int IdContrato { get; set;}
        public string Categoria { get; set;}
        public string Codigo { get; set;}
        public string Nombre { get; set;}
        public double Precio_venta { get; set;}
        public string Descripcion { get; set;}
        public bool Estado { get; set;}
        public string Enlace_descarga { get; set;}
    }
}