using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPietro.Models
{
    public class Fornecedor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Navigation properties

        [ForeignKey("FornecedorProdutos")]
        public ICollection<Produto> Produtos { get; set; }
    }
}
