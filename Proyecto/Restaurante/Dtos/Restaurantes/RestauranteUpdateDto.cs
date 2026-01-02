namespace Restaurante.Dtos.Restaurantes
{
    public class RestauranteUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int CapacidadTotal { get; set; }
    }
}
