using System.ComponentModel.DataAnnotations;

namespace MedicineManagement.Api.Entities;

public class Medicine
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [StringLength(500)]
    public string Notes { get; set; } = string.Empty;

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Range(typeof(decimal), "0.01", "9999999.99")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(100)]
    public string Brand { get; set; } = string.Empty;
}