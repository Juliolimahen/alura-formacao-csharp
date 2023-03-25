namespace CollectionsCSharpConvertendoEnumerando
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("string para object");
            string titulo = "meses";
            object obj = titulo;
            Console.WriteLine(obj);

            Console.WriteLine("List<string> para List<object>");

            IList<string> listaMeses = new List<string>
            {
                 "Janeiro", "Fevereiro", "Março",
                 "Abril", "Maio", "Junho",
                 "Julho", "Agosto", "Setembro",
                 "Outubro", "Novembro", "Dezembro"
            };


            //IList<object> listaObj = listaMeses;

            Console.WriteLine();

            Console.WriteLine("strin[] para object[]?");
            string[] arrayMeses = new string[]
            {
                "Janeiro", "Fevereiro", "Março",
                "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro",
                "Outubro", "Novembro", "Dezembro"
            };

            object[] arrayObj = arrayMeses; //COVARIÂNCIA!
            Console.WriteLine(arrayObj);

            Imprimir(arrayObj);

            arrayObj[0] = "PRIMEIRO MÊS";
            Console.WriteLine(arrayObj[0]);
            Console.WriteLine();

            IEnumerable<object> enumObj = listaMeses; //COVARIÂNCIA

            Imprimir(enumObj.ToArray());
        }

        private static void Imprimir(object[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}