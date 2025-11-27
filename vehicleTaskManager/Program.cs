


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


        /// This method controls the introduction message for users.
        static void introMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }


        /// This method controls the users question and runs a validity check before allowing changes into the task manager.
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

        /// This method is the main method that allows user control over the vehicle task manager.
        static void editVehicle(ref List<string> vehicles, string request)
        {
            switch (request)
            {
                case "add": 
                addRequest(ref vehicles, "add");
                break;

                case "update":
                updateRequest(ref vehicles, "update");
                break;

                case "view":
                viewRequest(ref vehicles, "view");
                break;

                case "delete":
                deleteRequest(ref vehicles, "delete");
                break;
            }
        }
        
        /// This method represents the add request the vehicle task manager
        static void addRequest(ref List<string> vehicles, string request)
        {
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
        }

        /// This method represents the update request the vehicle task manager
        static void updateRequest(ref List<string> vehicles, string request)
        {
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
        }


        /// This method represents the view request the vehicle task manager
        static void viewRequest(ref List<string> vehicles, string request)
        {
            Console.WriteLine("--- Your Vehicles ---");
            foreach (var car in vehicles)
                {
                    Console.Write($"*{car} ");
                }
        }


        /// This method represents the delete request the vehicle task manager
        static void deleteRequest(ref List<string> vehicles, string request)
        {
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
        }

    }
}