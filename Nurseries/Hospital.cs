using System;

namespace Nurseries {
    public class Hospital : IHospital
    {
        public Nursery OpenNursery()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool isDisposing)
        {

        }
    }
}