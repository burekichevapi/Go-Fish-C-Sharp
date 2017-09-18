using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Fish
{
    class UserInputException : Exception
    {
        public UserInputException() : base("You must enter one a card rank between Ace - King."){}
    }
}
