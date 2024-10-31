using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPietro.Models
{
   
        public class Cliente
        {

        [Key]
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Nome { get; set; }
            public string CpfCnpj { get; set; }
            public string Endereco { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public bool StatusCliente { get; set; }

        // Navigation properties
        [ForeignKey("ClienteVendas")]
            public ICollection<Venda> Vendas { get; set; }
        }
    
}
