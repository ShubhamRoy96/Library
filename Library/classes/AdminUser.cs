using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.classes
{
    class AdminUser : IUserControls, ISearchable, IAddable, IUpdatable
    {
        public void Add()
        {
            Book book = new Book();
            try
            {
                Console.WriteLine("Enter Book Name : ");
                book.Name = Console.ReadLine();
                Console.WriteLine("Enter Book Author : ");
                book.Author = Console.ReadLine();
                Console.WriteLine("Enter Book Publish Date : ");
                book.PublishDate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Book Rating : ");
                book.Rating = Convert.ToDouble(Console.ReadLine());

                Variables.Instance.booksList.Add(book);

                Console.WriteLine("Book Added Successfully!");

                Search();
            }
            catch (Exception)
            {
                Console.WriteLine("Some error occured, add book failed");
            }
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            Constants.Instance.Functions.SearchBook();
        }

        public void ShowControls()
        {
            Console.WriteLine("Please enter password : ");
            var adminPassword = Console.ReadLine();
            if (adminPassword != "Admin123")
            {
                Console.WriteLine("Incorrect Password");
                return;
            }
            showAdminControls();

        }

        public void Update()
        {
            Constants.Instance.Functions.UpdateBook();
        }

        void showAdminControls()
        {
            Console.Clear();
            Console.WriteLine("Welcome Admin!");
            Console.WriteLine("Enter F to Find, A to Add, U to Update");
            var adminInput = Console.ReadLine();
            var isSuccess = Enum.TryParse(typeof(Constants.OperationType), adminInput.ToUpper(), out var operationType);
            if (!isSuccess)
            {
                Console.WriteLine("Invalid Operation");
            }
            else
            {
                switch (operationType)
                {
                    case Constants.OperationType.A:
                        Add();
                        break;
                    case Constants.OperationType.U:
                        Update();
                        break;
                    case Constants.OperationType.F:
                        Search();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
