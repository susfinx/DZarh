using ClinicServiceNamespace;

namespace ClinicConsole
{

    partial class Program
    {

    }

    partial class Program
    {
        static void DoProcess()
        {

        }

    }

    partial class Program
    {

    }

    partial class Program
    {

    }

    internal partial class Program
    {
        static void Main(string[] args)
        {

            DoProcess();
            Console.WriteLine("Нажмите на любую клавишу для загрузки данных ...");
            Console.ReadKey();


            ClinicClient clinicClient = new ClinicClient("http://localhost:5115/", new HttpClient());

            List<Client> clients = clinicClient.ClientGetAllAsync().Result.ToList();
            foreach (Client client in clients)
            {
                Console.WriteLine("Фамилия: " + client.SurName);
                Console.WriteLine("Имя: " + client.FirstName);
                Console.WriteLine("Отчество: " + client.Patronymic);
                Console.WriteLine("Дата рождения: " + client.Birthday.DateTime);
                Console.WriteLine("Документ: " + client.Document);
                Console.WriteLine();
            }


            Console.WriteLine("Нажмите на любую клавишу для завершения работы приложения ...");
            Console.ReadKey();

        }
    }
}