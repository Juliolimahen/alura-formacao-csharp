using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    internal class GerenteDeContas : Funcionario
    {
        public GerenteDeContas(string cpf, double salario) : base(cpf, salario)
        {
        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.05;
        }

        public override double getBonificacao()
        {
            return this.Salario *= 0.25;
        }
    }
}
