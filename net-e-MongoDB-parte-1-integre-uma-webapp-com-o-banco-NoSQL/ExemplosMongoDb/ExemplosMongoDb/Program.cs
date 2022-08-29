// See https://aka.ms/new-console-template for more information

using ExemplosMongoDb;


void MainSync(string[] args)
{
    Console.WriteLine("Esperando  10 segundos ....");
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine("Esperei 10 segundos ....");
}

////MainSync(args);

//Console.WriteLine("Pressione Enter");
//Console.ReadLine();

ProgramAssincrono p = new ProgramAssincrono();

Task T = p.MainASync(args);
Console.WriteLine("Pressione Enter");
Console.ReadLine();