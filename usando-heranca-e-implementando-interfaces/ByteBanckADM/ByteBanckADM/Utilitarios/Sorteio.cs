using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBanckADM.Funcionarios.Utilitarios
{
    public class Sorteio
    {
        public int getRandomNumber()
        {
            var random = new Random();
            int randomNumber = random.Next(0, 9);
            return randomNumber;
        }
    }
}
