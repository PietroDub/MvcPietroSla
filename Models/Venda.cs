using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPietro.Models
{
    public class Venda
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataEmissao { get; set; }
        public decimal ValorTotal { get; set; }

        // Navigation properties

        [ForeignKey("ClienteVenda")]
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public ICollection<VendaProduto> VendaProdutos { get; set; }
    }
}
