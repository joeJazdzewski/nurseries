using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nurseries;
using Moq;
namespace Nurseries.Test
{
    [TestClass]
    public class NurseryTest
    {
        Mock<IHospital> hospital = new Mock<IHospital>();

        [TestMethod]
        public void Nursery_Success()
        {
            hospital.Setup(x => x.OpenNursery())
                .Returns(new Nursery());
            
            using(Nursery nursery = hospital.Object.OpenNursery())
            {
                DateTime firstStamp = DateTime.MinValue;
                DateTime secondStamp = DateTime.MinValue;
                Task first = nursery.StartSoon(() => {
                    firstStamp = DateTime.Now;
                    Thread.Sleep(3000);
                });

                Task second = nursery.StartSoon(() => {
                    secondStamp = DateTime.Now;
                });

                Task.WaitAll(first, second);
                Console.WriteLine(firstStamp);
                Console.WriteLine(secondStamp);

                Assert.IsTrue(firstStamp.AddSeconds(3) < secondStamp);
            } 
        }
    }
}
