using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios
{
    public abstract class Funcionario
    {
        public Funcionario(string cpf, double salario)
        {
            totalFuncionarios++;
            this.Cpf = cpf;
            this.Salario = salario;
        }
        public string? Nome { get; set; }
        public string? Cpf { get; private set; }
        public double Salario { get; protected set; }
        public static int totalFuncionarios { get; private set; }
        public abstract double getBonificacao();
        public abstract void AumentarSalario();
    }
}
