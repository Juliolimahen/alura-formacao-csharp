using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    public class Funcionario : Pessoa
    {
        //private int _tipo;
        public virtual double getBonificacao()
        {
            return salario * 0.10;
        }
    }
}
