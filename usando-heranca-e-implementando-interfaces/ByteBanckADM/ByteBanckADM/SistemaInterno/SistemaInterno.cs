using ByteBanckADM.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.SistemaInterno
{
    public class SistemaInterno
    {
        public bool Logar(Diretor diretor, string senha)
        {
            bool usuarioAutenticado = diretor.Autenticar(senha);
            if (usuarioAutenticado)
            {
                Console.WriteLine("Bem-vindo ao sistema");
                return true;
            }
            else
            {
                Console.WriteLine("Senha incorreta");
                return false;
            }
        }
        public bool Logar(GerenteDeContas gerenteDeContas, string senha)
        {
            bool usuarioAutenticado = gerenteDeContas.Autenticar(senha);
            if (usuarioAutenticado)
            {
                Console.WriteLine("Bem-vindo ao sistema");
                return true;
            }
            else
            {
                Console.WriteLine("Senha incorreta");
                return false;
            }
        }
    }
}
