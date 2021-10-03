using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.classes
{
    class StandardUser : IUserControls, ISearchable
    {
        public void Search()
        {
            Constants.Instance.Functions.SearchBook();
        }

        public void ShowControls()
        {
            Console.Clear();
            Console.WriteLine("Welcome User!");
            Search();
        }
    }
}
