using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    public class Diretor : Funcionario
    {
        public Diretor(string cpf, double salario) : base(cpf, salario){}

        public override double getBonificacao()
        {
            //bonificação de 110% reaproveitando os 10% do funcionário + os 100 do diretor
            return Salario + base.getBonificacao();
        }
        public override void AumentarSalario()
        {
            this.Salario *= 1.15;
        }
    }
}
