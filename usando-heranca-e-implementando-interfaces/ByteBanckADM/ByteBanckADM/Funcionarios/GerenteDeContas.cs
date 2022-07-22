using ByteBanckADM.SistemaInterno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    public class GerenteDeContas : FuncionarioAutenticavel
    {
        public GerenteDeContas(string cpf) : base(cpf, 5000)
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
