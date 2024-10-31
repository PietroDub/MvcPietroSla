using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPietro.Models
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public Guid FornecedorId { get; set; }

        // Navigation properties
        [ForeignKey("FornecedorProdutos11111111")]
        public Fornecedor Fornecedor { get; set; }
        public ICollection<VendaProduto> VendaProdutos { get; set; }
    }
}
