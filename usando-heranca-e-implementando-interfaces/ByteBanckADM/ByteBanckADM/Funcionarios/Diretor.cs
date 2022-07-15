using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    public class Diretor : Funcionario
    {

        public override double getBonificacao()
        {
            return salario;
        }
    }
}
