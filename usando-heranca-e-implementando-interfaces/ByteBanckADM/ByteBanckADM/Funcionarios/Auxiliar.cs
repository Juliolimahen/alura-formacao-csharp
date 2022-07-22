using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    internal class Auxiliar : Funcionario
    {
        public Auxiliar(string cpf) : base(cpf,2000)
        {
        }
        public override void AumentarSalario()
        {
            base.AumentarSalario();
        }
        public override double getBonificacao()
        {
            return base.getBonificacao();
        }
    }
}
