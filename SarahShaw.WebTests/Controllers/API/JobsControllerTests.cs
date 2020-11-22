using Microsoft.VisualStudio.TestTools.UnitTesting;
using SarahShaw.Controllers.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarahShaw.Controllers.API.Tests
{
    [TestClass()]
    public class JobsControllerTests
    {
        [TestMethod()]
        public void GetJobSummaryTest()
        {
            
        }

        [TestMethod()]
        public void MarkCompleteTest()
        {
            JobsController job = new JobsController();
            string result =  job.MarkComplete("456789");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void MarkCompleteTest2()
        {
            JobsController job = new JobsController();
            string result2 = job.MarkComplete(null);
            Assert.IsNotNull(result2);
        }
    }
}