
/// Samuil's - TASK MANAGER ///
/// The task manager is able to:
    /// Add
    /// Delete
    /// Update
    /// Display
namespace FullProject
{

    class Program
    {
        public static List<string> Requests()
        {
            return new List<string>
            {
                "add", "delete", "update", "view", "exit"
            };
        }



        static void Main(string[] args)
        {
            List<string> vehicles = new List<string>();

            introMessage("Welcome To The Vehicle Task Manager");

            bool machineRunning = true;

            while (machineRunning)
            {
            string request = userQuestion();

            if(request == "exit")
                {
                    Console.WriteLine("Goodybye!....");
                    break;
                }

            editVehicle(ref vehicles, request);

            Console.WriteLine();
            Console.Write("Would you like to carry on? (yes/no): ");
            string? carryOn = Console.ReadLine();

            if(carryOn?.ToLower() == "no")
                {
                    Console.WriteLine("Goodybye!....");
                    machineRunning = false;
                }
            }
        }



        static void introMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }



        static string userQuestion()
        {
            Console.Write("Would you like to View, Add, Update, Delete a vehicle or Exit: ");
            string? result = Console.ReadLine();
            result = result.ToLower();
            if(string.IsNullOrEmpty(result))
            {
                bool userQuestionCheckerEmpNull = false;
                while(userQuestionCheckerEmpNull != true)
                {  
                    Console.WriteLine("Your Answer CANNOT be EMPTY or NULL!");
                    Console.Write("Would you like to View, Add, Update, Delete a vehicle or Exit: ");
                    result = Console.ReadLine();
                    if (Requests().Contains(result))
                    {
                        userQuestionCheckerEmpNull = true;
                    }
                }
            }
            else if(!Requests().Contains(result)){
                bool userQuestionCheckerContains = false;

                while (userQuestionCheckerContains != true)
                {
                    Console.WriteLine("Please Enter A Correct Request('Add', 'Update', 'View', 'Delete', 'Exit')");
                    Console.Write("Would you like to View, Add, Update or Delete a vehicle?: "); 
                    result = Console.ReadLine();
                    if (Requests().Contains(result))
                    {
                        userQuestionCheckerContains = true;
                    }
                }

            }
            return result;
        }




        static void editVehicle(ref List<string> vehicles, string request)
        {
            switch (request)
            {
                case "add": 
                Console.WriteLine("(Format: 'carBrand brandModel' e.g., 'Mazda Arata')");
                Console.Write("Enter vehicle to add: ");
                string? vehicleAdd = Console.ReadLine();
                    while (string.IsNullOrEmpty(vehicleAdd))
                    {
                        Console.WriteLine("Please enter a value that is NOT NULL or EMPTY!");
                        Console.WriteLine("(Format: 'carBrand brandModel' e.g., 'Mazda Arata')");
                        Console.Write("Enter vehicle to add: ");
                        vehicleAdd = Console.ReadLine();
                    }
                vehicles.Add(vehicleAdd);
                Console.WriteLine($"Added {vehicleAdd}"); 
                break;

                case "update":
                if (vehicles.Count == 0)
                    {
                        Console.WriteLine("No existing vehicles. Please add one first.");
                        editVehicle(ref vehicles, "add");
                        return;
                    }

                Console.Write("Enter vehicle to update: ");
                string update = Console.ReadLine() ?? "";

                int updateIndex = vehicles.IndexOf(update);
                if (updateIndex == -1)
                    {
                        Console.WriteLine($"{update} is not found");
                        return;
                    }

                Console.WriteLine("Enter vehicle to replace");
                string replacement = Console.ReadLine() ?? "";

                vehicles[updateIndex] = replacement;
                Console.WriteLine($"{update} replaced to {replacement}");
                break;

                case "view":
                Console.WriteLine("---Your Vehicles---");
                foreach (var car in vehicles)
                    {
                        Console.Write($"*{car} ");
                    }

                break;

                case "delete":
                Console.Write("Enter vehicle to delete: ");
                string vehicleRemove = Console.ReadLine() ?? "";

                if (vehicles.Count == 0)
                    {
                        Console.WriteLine("No existing vehicles. Please add one first.");
                        editVehicle(ref vehicles, "add");
                        return;
                    }
                bool remove = vehicles.Remove(vehicleRemove);
                if(remove)
                    {
                        Console.WriteLine($"{vehicleRemove} is removed");
                    }
                    else
                    {
                        Console.WriteLine($"{vehicleRemove} is not found");
                    }
                break;
            }
        }



    }
}