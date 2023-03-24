using System;

namespace CollectionsCSharpQueue
{
    class Program
    {
        static Queue<string> pedagio = new Queue<string>();

        //Pilha (queue): Primeiro que entra é o ultimo que sai 
        //Fila (stack): Primeiro que entra é o primeiro que sai

        static void Main(string[] args)
        {
            //Entrou: van 
            string veiculo = "van";
            Imfileirar(veiculo);

            Imfileirar("kombi");

            Imfileirar("guincho");

            Imfileirar("pickup");

            Desinfileirar();
            Desinfileirar();
            Desinfileirar();
            Desinfileirar();
            Desinfileirar();
        }

        private static void Desinfileirar()
        {
            if (pedagio.Any())
            {
                if (pedagio.Peek() == "guincho")
                {
                    Console.WriteLine("\nGuincho está fazendo o pagamento");
                }

                var veiculo = pedagio.Dequeue();

                Console.WriteLine($"\nSaiu da fila: {veiculo}");

                Imprimir();
            }
        }

        private static void Imfileirar(string veiculo)
        {
            Console.WriteLine($"\nEntrou na fila: {veiculo}");

            pedagio.Enqueue(veiculo);
            Imprimir();
        }

        private static void Imprimir()
        {
            Console.WriteLine("\nFILA: ");

            foreach (var item in pedagio)
            {
                Console.WriteLine(item);
            }
        }
    }
}