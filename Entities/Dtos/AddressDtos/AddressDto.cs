using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.AddressDtos
{
    public record AddressDto
    {

        [Required(ErrorMessage = "Adres başlığı giriniz.")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Şehir giriniz.")]
        public string City { get; init; }
        [Required(ErrorMessage = "Semt giriniz.")]
        public string District { get; init; }

        [Required(ErrorMessage = "Adres bilgisini tam giriniz.")]
        public string Line { get; init; }

        [Required(ErrorMessage = "Bina numarasını giriniz.")]
        public int BuildingNumber { get; init; }

        [Required(ErrorMessage = "Daire numarasını giriniz.")]
        public int HomeNumber { get; init; }

        [Required(ErrorMessage = "Ülke adını giriniz.")]
        public string Country { get; init; }

        [Required(ErrorMessage = "Posta kodunu giriniz")]
        public string PostalCode { get; init; }
    }
}