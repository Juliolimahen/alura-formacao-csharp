using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    public class Diretor : Funcionario
    {
        public Diretor(string cpf) : base(cpf, 5000) { }
        public string Senha { get; set; }
        public override double getBonificacao()
        {
            //bonificação de 110% reaproveitando os 10% do funcionário + os 100 do diretor
            //return Salario + base.getBonificacao();
            return Salario *= 0.50;
        }
        public override void AumentarSalario()
        {
            this.Salario *= 1.15;
        }
        public bool Autenticar(string senha)
        {
            return this.Senha == senha;
        }
    }
}
