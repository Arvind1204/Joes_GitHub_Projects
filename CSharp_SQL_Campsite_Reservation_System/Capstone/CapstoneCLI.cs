using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAL;
using System.Configuration;

namespace Capstone
{
    public class CapstoneCLI
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CapstoneDatabase"].ConnectionString;
        public void InitialMenu()
        {
            //Displays the list of parks
            ParksSqlDAL parksSqlDal = new ParksSqlDAL(connectionString);
            List<Park> parks = parksSqlDal.GetParks();
            Console.WriteLine("Select a Park for Further Details");
            foreach (Park park in parks)
            {
                Console.WriteLine("     " + park.Park_id + ") " + park.Name);
            }
            Console.WriteLine("     Q) quit");
            //Prompts the user to select a park
            string initialInput = Console.ReadLine().Trim();
            int userInput;
            bool isInitialInputAnInt = int.TryParse(initialInput, out userInput);
            //Validates the input from the user
            bool isUserInputValid = (userInput > 0 && userInput <= parks.Count) || (initialInput.ToLower() == "q");
            while (!isUserInputValid)
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid command. Please:\n");
                Console.WriteLine("Select a Park for Further Details");
                foreach (Park park in parks)
                {
                    Console.WriteLine("     " + park.Park_id + ") " + park.Name);
                }
                Console.WriteLine("     Q) quit");
                initialInput = Console.ReadLine().Trim();
                isInitialInputAnInt = int.TryParse(initialInput, out userInput);
                isUserInputValid = (userInput > 0 && userInput < 4) || (initialInput.ToLower() == "q");
            }
            //Directs the user to the next step. Seeing the information for a park or quitting the program.
            foreach (Park park in parks)
            {
                if (initialInput.ToLower() == "q")
                {
                    Console.Clear();
                    Console.WriteLine("Your session has ended. Thanks for using the National Park Campsite Reservation program.");
                    Environment.Exit(0);
                }
                else if (park.Park_id == userInput)
                {
                    Console.Clear();
                    ParkMenu(userInput);
                    return;
                }
            }
        }
        public void ParkMenu(int park_id)
        {
            while (true)
            {
                //Displays the park information
                ParksSqlDAL parksSqlDal = new ParksSqlDAL(connectionString);
                Park currentPark = parksSqlDal.GetPark(park_id);
                currentPark.DisplayPark();
                //Requests user to select a command
                Console.WriteLine("Select a Command\n     1) View Campgrounds\n     2) Search for Reservation\n     3) Return to Previous Screen");
                string initialInput = Console.ReadLine().Trim();
                int userInput;
                //Validates the user input
                bool inputIsAnInt = int.TryParse(initialInput, out userInput);
                while (!inputIsAnInt || (userInput != 1 && userInput != 2 && userInput != 3))
                {
                    Console.WriteLine("Invalid Entry. Please enter a number:\n1) View Campgrounds\n2) Search for Reservation\n3) Return to Previous Screen");
                    initialInput = Console.ReadLine().Trim();
                    inputIsAnInt = int.TryParse(initialInput, out userInput);
                }
                //Directs the user to the view campgrounds menu or the previous search menu based on input
                if (userInput == 1)
                {
                    Console.Clear();
                    ViewCampgrounds(park_id);
                    break;
                }
                else if (userInput == 2)
                {
                    Console.Clear();
                    SearchMenu(park_id);
                    break;
                }
                else
                {
                    Console.Clear();
                    InitialMenu();
                    break;
                }
            }
        }
        public void ViewCampgrounds(int park_id)
        {
            while (true)
            {
                //Displays the campgrounds in the selected park
                DisplayCampgrounds(park_id);
                //Prompts the user to search for a reservation or return to previous screen
                Console.WriteLine();
                Console.WriteLine("Select a Command\n     1) Search for Available Reservation\n     2) Return to Previous Screen");
                string initialInput = Console.ReadLine().Trim();
                int userInput;
                //Validates user input
                bool inputIsAnInt = int.TryParse(initialInput, out userInput);
                while (!inputIsAnInt || (userInput != 1 && userInput != 2))
                {
                    Console.WriteLine("Invalid Entry. Please enter a number:\n1) Search for Available Reservation\n2) Return to Previous Screen");
                    initialInput = Console.ReadLine().Trim();
                    inputIsAnInt = int.TryParse(initialInput, out userInput);
                }
                //Directs the user to selected destination
                if (userInput == 1)
                {
                    Console.Clear();
                    SearchMenu(park_id);
                    break;
                }
                else
                {
                    Console.Clear();
                    ParkMenu(park_id);
                    break;
                }
            }
        }
        public void SearchMenu(int park_id)
        {
            while (true)
            {
                //Shows campgrounds inside that park based on park_id
                DisplayCampgrounds(park_id);
                //Prompts user to select a campground, Arrival Date and departure date.
                Console.WriteLine();
                Console.Write("Which campground? (enter 0 to cancel)? ");
                string initialCampgroundInput = Console.ReadLine();
                int campgroundSelected;
                //Validates user input
                while ((!int.TryParse(initialCampgroundInput, out campgroundSelected)) || (campgroundSelected < 0 || campgroundSelected > 7))
                {
                    Console.Write("Invalid Entry. Which campground? (enter 0 to cancel)? ");
                    initialCampgroundInput = Console.ReadLine();
                }
                if (campgroundSelected == 0)
                {
                    Console.Clear();
                    InitialMenu();
                }
                //Get Arrival Date
                Console.Write("What is the arrival date? (enter MM/DD/YY): ");
                DateTime arrivalDate;
                bool isValidArrivalDate = DateTime.TryParse(Console.ReadLine(), out arrivalDate);
                while (!isValidArrivalDate)
                {
                    Console.Write("Invalid Date Entered. What is the arrival date? (enter YYYY/MM/DD): ");
                    isValidArrivalDate = DateTime.TryParse(Console.ReadLine(), out arrivalDate);
                }
                //Get Departure Date
                Console.Write("What is the departure date? (enter MM/DD/YY): ");
                DateTime departureDate;
                bool isValidDepartDate = DateTime.TryParse(Console.ReadLine(), out departureDate);
                while (!isValidDepartDate)
                {
                    Console.Write("Invalid Date Entered. What is the departure date? (enter YYYY/MM/DD): ");
                    isValidDepartDate = DateTime.TryParse(Console.ReadLine(), out departureDate);
                }
                //Call the reserve campsite method using the information collected in this method. Exit the method
                ReserveCampsite(park_id, campgroundSelected, arrivalDate, departureDate);
                break;
            }
        }
        public void ReserveCampsite(int park_id, int campground_id, DateTime arrivalDate, DateTime departureDate)
        {
            while (true)
            {
                //Gets a list of available campsites
                SiteSqlDAL siteSqlDal = new SiteSqlDAL(connectionString);
                List<Site> sites = siteSqlDal.GetAvailableSites(campground_id, arrivalDate, departureDate);
                //Lets user know if no sites are available based on their search terms
                while (sites.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("There are no available sites matching your search criteria.\nPress any Key to Continue.");
                    Console.ReadKey();
                    Console.Clear();
                    SearchMenu(park_id);
                }
                //Create a reservation to pass into DAL methods, assign to and from times
                Reservation currentReservation = new Reservation();
                currentReservation.From_Date = arrivalDate;
                currentReservation.To_Date = departureDate;
                //Get Number of days to multiply by daily cost of campground
                int numOfDays = (int)departureDate.Subtract(arrivalDate).TotalDays;
                //Displays all available sites based on search criteria
                Console.WriteLine();
                Console.WriteLine("Results Matching your Search Criteria:");
                Console.WriteLine();
                Console.Write("Site No.".PadRight(12));
                Console.Write("Max Occup.".PadRight(12));
                Console.Write("Accessible?".PadRight(15));
                Console.Write("Max RV Length".PadRight(18));
                Console.Write("Utility".PadRight(12));
                Console.WriteLine("Cost".PadRight(12));
                foreach (Site site in sites)
                {
                    site.DisplaySite(numOfDays);
                }
                //Prompts user to enter their name and preferred site id
                Console.WriteLine();
                Console.Write("Which site should be reserved (enter 0 to cancel)? ");
                string siteReserved = Console.ReadLine().Trim();
                int siteNumber;
                bool isSiteEnteredAnInteger = int.TryParse(siteReserved, out siteNumber);
                currentReservation.Site_id = siteNumber;
                Console.Write("What name should the reservation be made under? ");
                currentReservation.Name = Console.ReadLine().Trim() + " Reservation";
                //Create a reservation for the selected site_id and reservation dates
                bool isReservationSuccessful = siteSqlDal.ReserveSite(currentReservation);
                if (isReservationSuccessful)
                {
                    int reservation_id = siteSqlDal.GetReservationId(currentReservation);
                    Console.WriteLine("\nThe reservation has been made and the confirmation ID is " + reservation_id);
                    Console.ReadKey();
                    Console.Clear();
                    InitialMenu();
                }
                else
                {
                    Console.WriteLine("Error: Your reservation was not made. Returning to home");
                    Console.Clear();
                    InitialMenu();
                }
            }
        }
        public void DisplayCampgrounds(int park_id)
        {
            //This method was created because we needed to do the same code in 2 separate methods. 
            CampgroundsSqlDAL campgroundSqlDal = new CampgroundsSqlDAL(connectionString);
            List<Campground> campgrounds = campgroundSqlDal.GetCampgrounds(park_id);
            ParksSqlDAL parksSqlDal = new ParksSqlDAL(connectionString);
            Park currentPark = parksSqlDal.GetPark(park_id);
            Console.WriteLine(currentPark.Name + " National Park Campgrounds");
            Console.WriteLine();
            Console.Write("Name".PadLeft(9).PadRight(39));
            Console.Write("Open".PadRight(15));
            Console.Write("Close".PadRight(14));
            Console.WriteLine("Daily Fee");
            foreach (Campground campground in campgrounds)
            {
                campground.DisplayCampground();
            }
        }
    }
}

