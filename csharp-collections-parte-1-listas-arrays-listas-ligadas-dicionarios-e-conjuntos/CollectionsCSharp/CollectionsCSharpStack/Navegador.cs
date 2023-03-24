namespace CollectionsCSharpStack
{
    public class Navegador
    {
        private string atual = "vazia";
        private readonly Stack<string> historicoAnterior = new Stack<string>();
        private readonly Stack<string> historicoProximo = new Stack<string>();

        public Navegador()
        {
            Console.WriteLine("Página atual: " + atual);
        }

        public void NavegarPara(string url)
        {
            //Colocando url na pilha, salvar como histórico 
            historicoAnterior.Push(atual);
            atual = url;
            Console.WriteLine("Página atual: " + atual);
        }

        public void Anterior()
        {
            //Any(): verifica se tem algo
            if (historicoAnterior.Any())
            {
                //Alimentado historico proximo 
                historicoProximo.Push(atual);

                atual = historicoAnterior.Pop();
                Console.WriteLine("Página atual: " + atual);
            }
        }

        public void Proximo()
        {
            if (historicoProximo.Any())
            {
                //Alimentado historico anterior 
                historicoAnterior.Push(atual);

                atual = historicoProximo.Pop();
                Console.WriteLine("Página atual: " + atual);
            }
        }
    }
}