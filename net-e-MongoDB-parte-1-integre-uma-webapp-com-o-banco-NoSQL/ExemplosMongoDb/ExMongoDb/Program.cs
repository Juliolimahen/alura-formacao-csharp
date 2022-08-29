using ExemplosMongoDb;

#region operação síncrona 
void MainSync(string[] args)
{
    Console.WriteLine("Esperando  10 segundos ....");
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine("Esperei 10 segundos ....");
    Console.WriteLine("Pressione Enter");
    Console.ReadLine();
}
#endregion

#region operação assíncrona 
void async()
{
    ProgramAssincrono p = new ProgramAssincrono();

    Task T = p.MainASync(args);
    Console.WriteLine("Pressione Enter");
    Console.ReadLine();
}
#endregion

#region criando json assíncrona 
void SalvarObjetoAsync()
{
    ManipulandoDocumentos m = new ManipulandoDocumentos();
    _ = m.MainASync(args);
}
#endregion

#region Acessando mongoDb
void AcessandoMongoDbAsync()
{

    AcessandoMongoDb a = new AcessandoMongoDb();
    Task t = a.MainASync(args);
}
#endregion

Console.WriteLine("press enter");
Console.ReadLine();
AcessandoMongoDbAsync();