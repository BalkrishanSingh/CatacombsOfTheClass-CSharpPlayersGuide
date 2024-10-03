
    Console.Write("Welcome, Please enter a password for your new door :");
    Door door = new Door(Console.ReadLine() ?? "");
    for (;;)
    {
        Console.Write($"Door is currently {door.State}. ");
        Console.WriteLine("""
                      Would you like to
                          1 - Open the door
                          2 - Close the door?
                          3 - Lock the door?
                          4 - Unlock the door?
                          5 - Change the door password?
                      """);
        
        int choice = Convert.ToInt32(Console.ReadLine());
        
        switch (choice)
        {
            case 1:
                door.OpenDoor();
                break;
            case 2 :
                door.CloseDoor();
                break;
            case 3:
                door.LockDoor();
                break;
            case 4:
                door.UnlockDoor();
                break;
            case 5:
                door.ChangePassword();
                break;
            default:
                Console.WriteLine("Invalid Choice.");
                break;
        }
    }



    class Door
    {
        public DoorState State { get; private set; } = DoorState.Open;

        private string Password { get; set; }

        public Door( string? password)
        {
            Password = password ?? string.Empty;
        }

        public void OpenDoor()
        {
            ChangeState(DoorState.Closed,DoorState.Open,"Door opened","Door is  not closed so it can't be unlocked." );

        }

        public void CloseDoor()
        {
            ChangeState(DoorState.Open,DoorState.Closed,"Door Closed","Door is  not Open so it can't be unlocked." );

        }
        public void LockDoor()
        {
            ChangeState(DoorState.Closed,DoorState.Locked,"Door locked","Door is  not closed so it can't be unlocked." );

        }

        public void UnlockDoor()
        {

            if (State == DoorState.Locked)
            {
                if (VerifyPassword())
                {
                    SetState(DoorState.Closed, "Door unlocked");
                }
            }
            else
            {
                Console.WriteLine("Door is  not locked so it can't be unlocked.");
            }
        }

        public void ChangeState(DoorState requiredState, DoorState newState, string successMessage,
            string failureMessage)
        {
            if (requiredState == State)
            {
                SetState(newState,successMessage);
            }
            else
            {
                Console.WriteLine(failureMessage);
            }
        }

        public void SetState( DoorState newState,string message)
        {
            State = newState;
            Console.WriteLine(message);
        }
        public void ChangePassword()
        {
            if (VerifyPassword())
            {
                Console.Write("Enter new password:");
                string? newPassword = Console.ReadLine();
                Password = newPassword ?? string.Empty;
                Console.WriteLine("Password Changed.");
            }
        }
        
        private bool VerifyPassword()
        {
            Console.Write("Enter current password: ");
            string? password = Console.ReadLine();
            if (Password == password) return true;
            Console.WriteLine("Wrong Password.");
            return false;
        }
        
    }

    enum DoorState
    {
        Open,
        Closed,
        Locked
    }