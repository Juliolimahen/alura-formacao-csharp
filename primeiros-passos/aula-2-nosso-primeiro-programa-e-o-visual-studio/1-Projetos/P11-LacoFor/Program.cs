
double investimeto = 1000;
double rendimento = 0;
var inicial = investimeto;

for (int mes = 1; mes < 12; mes++)
{
    investimeto += investimeto * 0.005;
    rendimento = investimeto - inicial;
    Console.WriteLine($"Rendimento no mês " + mes + 
        " foi de "
        + rendimento.ToString("F2") + ". Saldo "
        + investimeto.ToString("F2") + ".");
}
Console.WriteLine("Saldo atual: " + investimeto.ToString("F2"));