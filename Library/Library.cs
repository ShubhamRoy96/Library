using System;
using Library.classes;

namespace Library
{    
    class Library
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");
            Functions.AddBooks();
            UIControls uIControls = new UIControls();
            UIControls.ShowUserControl();

        }
    }

    class UIControls
    {
        public static void ShowUserControl()
        {            
            
            Console.WriteLine("Please select user type : \n Type U for User or A for Admin");
            var userInput = Console.ReadLine();
            var isSuccess = Enum.TryParse(typeof(Constants.UserType), userInput.ToUpper(), out var userType);
            if (!isSuccess)
            {
                Console.WriteLine("Invalid UserType");
            }
            else
            {
                IUserControls userControls;
                switch (userType)
                {
                    case Constants.UserType.A:
                        userControls = new AdminUser();
                        break;
                    case Constants.UserType.U:
                        userControls = new StandardUser();
                        break;
                    default:
                        userControls = new StandardUser();
                        break;
                }
                
                userControls.ShowControls();
                
            }
        }
    }
}
