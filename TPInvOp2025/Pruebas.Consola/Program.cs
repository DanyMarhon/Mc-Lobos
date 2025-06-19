using TPInvOp.Ioc;
namespace pruebas.Consola
{
    internal class Program
    {
        static IServiceProvider _serviceProvider = null!;
        static void Main(string[] args)
        {
            _serviceProvider = DI
            
            using (var scope = Serv
            Console.Clear();
            Console.WriteLine("Adding a new Team");
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the budget");
            double budget;
            if (!double.TryParse(Console.ReadLine(), out budget))
            {
                Console.WriteLine("the budget is not correct!");
            }
            Console.WriteLine("Enter the Main Color");
            var mainColor = Console.ReadLine();
            Console.WriteLine("Enter the Secondary Color");
            var secondaryColor = Console.ReadLine();

            bool exist = teamService.ExistTeam(name);

            if (!exist)
            {
                var team = new Team
                {
                    Name = name,
                    Budget = budget,
                    MainColor = mainColor,
                    SecondaryColor = secondaryColor
                };

                //var validationContext = new ValidationContext(team);
                //var errorMessages = new List<ValidationResult>();

                //bool isValid = Validator.TryValidateObject(team, validationContext, errorMessages, true);

                //if (isValid)
                //{
                //    teamService.SaveTeam(team);
                //    Console.WriteLine("Team Successfully added");
                //}
                //else
                //{
                //    foreach (var message in errorMessages)
                //    {
                //        Console.WriteLine(message);
                //    }
                //}
            }
            else
            {
                Console.WriteLine("The team already exist!");
            }
            TeamCreateDto teamCreateDto = new TeamCreateDto
            {
                Name = name,
                Budget = budget,
                MainColor = mainColor ?? string.Empty,
                SecondaryColor = secondaryColor ?? string.Empty
            };
            if (teamService.CreateTeam(teamCreateDto, out var errors))
            {
                Console.WriteLine("Team Successfully Added");
            }
            else
            {
                Console.WriteLine("Errors while trying to add a new team");
                errors.ForEach(error => Console.WriteLine(error));
            }

            Console.ReadLine();
        }
    }
}

