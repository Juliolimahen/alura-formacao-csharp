using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Cadastro : BaseModel
    {
        public Cadastro() { }

        public virtual Pedido Pedido { get; set; }
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; } = "";
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Telefone obrigatório")]
        public string Telefone { get; set; } = "";
        [Required(ErrorMessage = "Endereco obrigatório")]
        public string Endereco { get; set; } = "";
        [Required(ErrorMessage = "Complemento obrigatório")]
        public string Complemento { get; set; } = "";
        [Required(ErrorMessage = "Bairro obrigatório")]
        public string Bairro { get; set; } = "";
        [Required(ErrorMessage = "Municipio obrigatório")]
        public string Municipio { get; set; } = "";
        [Required(ErrorMessage = "UF obrigatório")]
        public string UF { get; set; } = "";
        [Required(ErrorMessage = "CEP obrigatório")]
        public string CEP { get; set; } = "";

        public void Update(Cadastro novoCadastro)
        {
            this.Bairro = novoCadastro.Bairro;
            this.CEP = novoCadastro.CEP;
            this.Complemento = novoCadastro.Complemento;
            this.Email = novoCadastro.Email;
            this.Endereco = novoCadastro.Endereco;
            this.Municipio = novoCadastro.Municipio;
            this.Nome = novoCadastro.Nome;
            this.Telefone = novoCadastro.Telefone;
            this.UF = novoCadastro.UF;
        }
    }
}
