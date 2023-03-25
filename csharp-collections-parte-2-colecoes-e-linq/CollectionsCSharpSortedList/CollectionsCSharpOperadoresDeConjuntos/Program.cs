namespace CollectionsCSharpOperadoresDeConjuntos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] seq1 = { "janeiro", "fevereiro", "março" };
            string[] seq2 = { "fevereiro", "MARÇO", "abril" };

            Console.WriteLine("Concatenando duas sequencias");

            //Concatenação das sequências 
            var consulta = seq1.Concat(seq2);
            Imprimir(consulta);

            //Unir duas sequências
            var consulta2 = seq1.Union(seq2);
            Imprimir(consulta2);

            //Unir duas sequências, descosiderrando maiusculo e minusculo
            var consulta3 = seq1.Union(seq2, StringComparer.CurrentCultureIgnoreCase);
            Imprimir(consulta3);

            //Intersecção 
            var consulta4 = seq1.Intersect(seq2);
            Imprimir(consulta4);

            //Intersecção 
            var consulta5 = seq1.Intersect(seq2, StringComparer.CurrentCultureIgnoreCase);
            Imprimir(consulta5);

            //Elementos da sequência 1 que não estão na sequência 2
            var consulta6 = seq1.Except(seq2);
            Imprimir(consulta6);


        }
        /// <summary>
        /// Percorre uma lista/consulta e imprime seus itens utilizando o laço foreach
        /// </summary>
        /// <param name="consulta"></param>
        private static void Imprimir(IEnumerable<string> consulta)
        {
            Console.WriteLine();
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }
    }
}
