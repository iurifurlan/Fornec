using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fornec.Models;

public class Fornecedor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string RazaoSocial { get; set; }

    [Required]
    [MaxLength(100)]
    public string NomeFantasia { get; set; }

    [Required]
    [Display(Name = "CNPJ")]
    [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "O CNPJ inserido não é válido. Utilize o formato 00.000.000/0000-00.")]
    public string CNPJ { get; set; }


    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [Phone(ErrorMessage = "Este telefone não é válido")]
    [Display(Name = "Telefone")]
    public string Telefone { get; set; }


    [Required]
    [EmailAddress]
    [Column("email_do_cliente")]
    public string Email { get; set; }

    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    [Required]
    [Display(Name = "CEP")]
    [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP inserido não é válido. Utilize o formato 00000-000.")]
    public string CEP { get; set; }
}
