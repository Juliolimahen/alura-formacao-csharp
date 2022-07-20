using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    public class Funcionario
    {
        public string? Nome { get; set; }
        public string? Cpf { get; private set; }
        public double Salario { get; protected set; }

        public static int totalFuncionarios { get; private set; }

        public Funcionario(string cpf, double salario)
        {
            totalFuncionarios++;
            this.Cpf = cpf;
            this.Salario = salario;
        }
        public virtual double getBonificacao()
        {
            return Salario * 0.10;
        }

        public virtual void AumentarSalario()
        {
            this.Salario *= 1.1;
        }
    }
}
