using DbUp;
using Microsoft.Extensions.Configuration;

namespace Authentication.Infrastrucutre.Migrations
{
    public class AuthDbMigrator
    {
        public static void Migrate(ConfigurationManager config)
        {

            string connectionString = config.GetConnectionString("DefaultConnection");

            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsFromFileSystem("Infrastrucutre\\Migrations\\Scripts")
                .WithExecutionTimeout(TimeSpan.FromMinutes(10))
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
            }
        }
    }
}
