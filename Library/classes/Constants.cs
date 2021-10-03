using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.classes
{
    public sealed class Constants
    {
        private static Constants instance = null;
        public enum UserType
        {
            A,
            U
        }

        public enum OperationType
        {
            A,
            U,
            F
        }

        public enum UpdateType
        {
            A,
            N,
            P,
            R
        }
        public Functions Functions;
        private Constants()
        {
            Functions = new Functions();
        }

        public static Constants Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Constants();
                }
                return instance;
            }
        }
    }    
}
