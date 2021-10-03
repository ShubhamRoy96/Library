using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.classes
{
    public sealed class Variables
    {
        private static Variables instance = null;

        public List<Book> booksList;
        private Variables()
        {
            
        }

        public static Variables Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Variables();
                }
                return instance;
            }
        }
    }    
}
