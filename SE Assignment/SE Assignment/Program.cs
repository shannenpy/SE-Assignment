using SE_Assignment;

// Software Engineering
// T02
// Team 5
// UC-001 Renew (Dynoh)
// UC-002 Transfer (Chloe)
// UC-003 Terminate (Shannen)
// UC-004 Apply (Elizabeth)

// Lacking validation for user inputs.

// Required for test case

// registered user
User user = new User("s12345678", "Dr Oon", 0, "s12345678", "password123", "91234567");

// unregistered user
// User user = new User();

PaymentMode p = new PaymentMode("card",987654321);
Vehicle v = new Vehicle("S235487L", 123, 1);
SeasonParkingPass s = new Monthly(v, 10242384, "valid", "m", "NIL");
user.addSPPList(s);
user.changePaymentMode(p);

// Create user SPPList
Vehicle myvehicle = new Vehicle("lpn", 2, 0);
List<SeasonParkingPass> SPPList = new List<SeasonParkingPass>();
Daily spp1 = new Daily(myvehicle, 1, "valid", "d", null);
SPPList.Add(spp1);
Monthly spp2 = new Monthly(myvehicle, 2, "expired", "m", null);
SPPList.Add(spp2);
Monthly spp3 = new Monthly(myvehicle, 3, "valid", "m", null);
SPPList.Add(spp3);
Daily spp4 = new Daily(myvehicle, 4, "expired", "d", null);
SPPList.Add(spp4);

MonthlyCollection waitingList = MonthlyCollection.getInstance();

bool running = true;
while (running)
{
    running = !menu();
}

// returns true if exiting, false if repeating
bool menu()
{
    Console.WriteLine("----- Welcome to the ICTP Parking Management System -----");
    Console.WriteLine("Menu options:");
    Console.WriteLine("1. Apply for season pass");
    Console.WriteLine("2. Renew season pass");
    Console.WriteLine("3. Transfer season pass");
    Console.WriteLine("4. Terminate season pass");
    Console.WriteLine("5. Exit");
    int opt;
    while (true)
    {
        try
        {
            Console.Write("Select your option: ");
            opt = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine($"Wrong format: Please enter a digit");
            continue;
        }
        catch
        {
            Console.WriteLine("Unknown error occured. Please try again.");
            continue;

        }
        if (opt is >=1 and <=5)
        {
            break;
        }
        else
        {
            Console.WriteLine("Option is not in range. Please try again.");
            continue;
        }
    }
    bool exit = false;
    switch (opt)
    {
        case 1: // apply
            // UC-004 Step 1
            user.applySeasonPass();
            break;
        case 2: // renew
            user.renewSeasonPass();
            break;
        case 3: // transfer
            user.transferSeasonPass();
            break;
        case 4: // terminate
            user.terminateSeasonPass();
            break;
        case 5:
            Console.WriteLine("Hit any key to exit program...");
            Console.ReadKey();
            Console.WriteLine();
            exit = true;
            break;
    }
    Console.WriteLine();
    return exit;
}