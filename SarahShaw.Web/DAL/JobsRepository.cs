using System;
using System.Linq;
using SarahShaw.DTO;
using SarahShaw.Data.Models;
using System.Collections.Generic;

namespace SarahShaw.DAL
{
    public class JobsRepository
    {
        public List<JobDTO> GetAllJobs()
        {
            using (DemoEntities db = new DemoEntities())
            {
                List<JobDTO> result = (from rj in db.RX_Job
                                       join rt in db.RX_RoomType
                                       on rj.RoomTypeId equals rt.Id
                                       orderby rj.Name
                                       select new JobDTO
                                       {
                                           JobId = rj.Id.ToString(),
                                           Name = rj.Name,
                                           Floor = rj.Floor,
                                           Status = rj.Status,
                                           RoomType = rt.Name
                                       }).ToList();
                return result;
            }
            //using (DemoEntities db = new DemoEntities())
            //{
            //    return db.RX_Job.ToList();
            //}
        }

        public List<JobSummaryDTO> GetJobSummary()
        {
            using (DemoEntities db = new DemoEntities())
            {
                List<JobSummaryDTO> result = (from bb in db.RX_RoomType
                                              join cc in db.RX_Job
                                              on bb.Id equals cc.RoomTypeId
                                              group new { bb, cc } by new { cc.Status, bb.Name, bb.Id, bb.Description } into newgroup
                                              orderby newgroup.Key.Name
                                              select new JobSummaryDTO
                                              {
                                                  JobStatus = newgroup.Key.Status,
                                                  RoomType = newgroup.Key.Name,
                                                  RoomName = newgroup.Key.Description,
                                                  Total = newgroup.Count().ToString()
                                              }).ToList();

                return result;
            }
        }

        public bool MarkJobAsComplete(string jobId)
        {
            try
            {
                using (DemoEntities db = new DemoEntities())
                {
                    RX_Job job = db.RX_Job.Where(x => x.Id.ToString() == jobId.ToString()).FirstOrDefault();
                    job.Status = "Complete";
                    job.DateCompleted = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}