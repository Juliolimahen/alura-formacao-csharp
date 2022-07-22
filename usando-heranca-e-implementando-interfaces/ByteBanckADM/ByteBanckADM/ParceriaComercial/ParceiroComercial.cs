using ByteBanckADM.Funcionarios;
using ByteBanckADM.SistemaInterno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.ParceriaComercial
{
    public class ParceiroComercial: IAutenticavel
    {
        public string? Senha { get; set; }
        bool IAutenticavel.Autenticar(string senha) => this.Senha.Equals(senha);
    }
}
