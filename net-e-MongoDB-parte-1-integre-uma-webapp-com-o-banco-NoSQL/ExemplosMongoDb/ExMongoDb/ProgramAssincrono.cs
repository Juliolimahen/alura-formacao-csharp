using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosMongoDb
{
    class ProgramAssincrono
    {

        //static void Main(string[] args)
        //{

        //    Task T = MainASync(args);
        //    Console.WriteLine("Pressione Enter");
        //    Console.ReadLine();
        //}

        public async Task MainASync(string[] args)
        {
            Console.WriteLine("Esperando  10 segundos ....");
            await Task.Delay(1000);
            Console.WriteLine("Esperei 10 segundos ....");
        }
    }
}
