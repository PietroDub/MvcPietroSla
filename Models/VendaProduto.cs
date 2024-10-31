using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPietro.Models
{
    public class VendaProduto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Quantidade { get; set; }

        // Navigation properties
        [ForeignKey("FornecedorProdutos")]
        public Produto Produto { get; set; }
        public Guid ProdutoId { get; set; }

        [ForeignKey("FornecedorVenda")]
        public Guid VendaId { get; set; } 
        public Venda Venda { get; set; }
    }
}
