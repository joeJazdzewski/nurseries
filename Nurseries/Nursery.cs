using System;
using System.Threading.Tasks;

namespace Nurseries
{
    public class Nursery : INursery
    {
        public void Dispose()
        {
            this.Dispose(true);
        }

        public Task StartSoon() 
        {
            return Task.FromException(new NotImplementedException());
        }

        protected void Dispose(bool disposing)
        {
            
        }


    }
}
