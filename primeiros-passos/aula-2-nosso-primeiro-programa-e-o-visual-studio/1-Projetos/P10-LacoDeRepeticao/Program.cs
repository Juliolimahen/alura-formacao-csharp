
double investimeto = 1000;
double rendimento = 0;
var inicial = investimeto;
int mes = 1;

while (mes <= 12 && mes>0)
{
    investimeto += investimeto * 0.005;
    rendimento = investimeto - inicial;
    Console.WriteLine($"Rendimento no mês " + mes + " foi de " 
        + rendimento.ToString("F2") + ". Saldo " 
        + investimeto.ToString("F2") + ".");
    mes++;
}
Console.WriteLine("Saldo atual: " + investimeto.ToString("F2"));