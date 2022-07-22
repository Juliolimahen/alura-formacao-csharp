using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    internal class Auxiliar : Funcionario
    {
        public Auxiliar(string cpf) : base(cpf,2000){}
        public override void AumentarSalario() => this.Salario *= 0.15;
        public override double getBonificacao() => Salario *= 0.1;
    }
}
