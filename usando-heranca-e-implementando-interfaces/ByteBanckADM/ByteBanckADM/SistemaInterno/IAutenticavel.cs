using ByteBanckADM.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.SistemaInterno
{
    public interface IAutenticavel
    {
        public bool Autenticar(string senha);
    }
}
