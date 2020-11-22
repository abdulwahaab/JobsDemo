using SarahShaw.DAL;
using SarahShaw.DTO;
using System.Web.Http;
using System.Collections.Generic;

namespace SarahShaw.Controllers.API
{
    public class JobsController : ApiController
    {
        [HttpGet]
        public List<JobSummaryDTO> All()
        {
            JobsRepository jobs = new JobsRepository();
            return jobs.GetJobSummary();
        }

        [HttpPost]
        public string MarkComplete(string jobId)
        {
            if (!string.IsNullOrEmpty(jobId))
            {
                JobsRepository jobs = new JobsRepository();
                if (jobs.MarkJobAsComplete(jobId))
                    return "success";
                else
                    return "error";
            }
            else
            {
                return "invalid";
            }
        }
    }
}
