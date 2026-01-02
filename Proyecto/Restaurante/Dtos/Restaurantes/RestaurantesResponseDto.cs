namespace Restaurante.Dtos.Restaurantes
{
    public class RestaurantesResponseDto
    {
        public int IdRestaurante { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int CapacidadTotal { get; set; }



    }
}
