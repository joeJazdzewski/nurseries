using System;

namespace Nurseries.Exceptions 
{
    public class Cancelled : Exception 
    {
        public Cancelled(string message)
            : base(message)
        {

        }
    }
}