using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZipPortel.Models;

namespace ZipPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public ZipController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetZipDetails")]
        public List<Zip> GetZipDetails()
        {
            List<Zip> lstZip = new List<Zip>();
            try
            {
                lstZip = trainingDBContext.Zip.ToList();
                return lstZip;
            }
            catch (Exception ex)
            {
                lstZip = new List<Zip>();
                return lstZip;
            }
        }
        [HttpPost("AddZip")]
        public string AddZip(Zip zip)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(zip.ZipCode))
                {
                    trainingDBContext.Add(zip);
                    trainingDBContext.SaveChanges();
                    message = "Zip code added successfully";
                }
                else
                    message = "Zip code required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
