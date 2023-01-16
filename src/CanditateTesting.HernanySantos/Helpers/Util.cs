namespace CanditateTesting.HernanySantos.Helpers
{
    public class Util
    {
        public static void Header() 
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("AGILE CONTENT");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Executando .....");
        }

        public static void Footer() 
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Logger Finalizado ....");
            Console.WriteLine("------------------------------------------------------------");
        }

        public static void Error() 
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Erro Identificado ....");
            Console.WriteLine("------------------------------------------------------------");
        }

        public static bool ParameterIsValid(string[] args) 
        {
            var isValid = false;

            if(args.Length <=1)
            {
                Console.WriteLine("Quantidade de Argumentos Inválidos");
            }
            else
            {
                if(args.Length >= 2)
                {
                    if (args.Length > 2) 
                        Console.WriteLine("Argumentos Válidos Identificados com Quantidades de Argumentos acima do esperado");
                    else
                        Console.WriteLine("Argumentos Válidos Identificados");
                    isValid = true;
                }
                
            }

            return isValid;

        }
    }
}