using EnsekWebApi.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnsekWebApi.Controllers
{
    [Route("api/meter-reading-uploads")]
    [ApiController]
    public class MeterReadingUploadsController : ControllerBase
    {
        private readonly DBContext dbc;

        public MeterReadingUploadsController(DBContext context)
        {
            dbc = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeterReading>>> GetAccounts()
        {
            return await dbc.MeterReadings.ToListAsync(); ;
        }

        [EnableCors("Policy1")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(
         IFormFile file, CancellationToken tkn)
        {
            if (CheckIfCSVFile(file))
            {
                string filepath = "";
                if(WriteFile(file, out filepath))
                {
                    int totalrows = 0, successrows = 0, failedrows = 0;
                    using (StreamReader csvFile = new StreamReader(filepath))
                    {
                        string header = csvFile.ReadLine(); // perform check if required

                        string data = "";
                        
                        while ((data = csvFile.ReadLine()) != null)
                        {
                            totalrows++;
                            try
                            {
                                bool success = false;
                                if (data.Split(",").Length >= 3)
                                {
                                    string[] values = data.Split(",");
                                    int accountId = toInt(values[0]);
                                    DateTime dt = toDateTime(values[1]);
                                    int reading = toInt(values[2]);
                                    if (values[2].Length == 5 && reading >= 0 && dt > DateTime.MinValue)
                                    {
                                        //perform data validation
                                        Account account = dbc.Accounts.FirstOrDefault((a => a.AccountId == accountId));
                                        if (account != null)
                                        {
                                            dbc.MeterReadings.Add(new MeterReading { Account = account, MeterReadingDate = dt, MeterReadingValue = reading });
                                            dbc.SaveChanges();
                                            success = true;
                                        }
                                    }


                                }

                                if (success)
                                {
                                    System.Console.Out.WriteLine("Success Record: [" + totalrows + "] ");
                                    successrows++;
                                }
                                    
                                else
                                {
                                    System.Console.Out.WriteLine("Failure Record: [" + totalrows + "] ");
                                    failedrows++;
                                }
                                    
                            }
                            catch (Exception ex)
                            {
                                System.Console.Out.WriteLine( "Record[" + totalrows + "]: " + ex.Message);
                                failedrows++;
                            }
                            
                        }
                    }
                    return Ok(new { message = String.Format("Total Rows Processed: {0} \r\n Rows Saved: {1} \r\n Rows Failed: {2}", totalrows, successrows, failedrows ) });
                }
                else
                {
                    return BadRequest(new { message = "Unable to save file" });
                }
            }
            else
            {
                return BadRequest(new { message = "Invalid file extension" });
            }

        }
        private int toInt(string strInt)
        {
            int result = -1;
            return int.TryParse(strInt, NumberStyles.Integer, CultureInfo.InvariantCulture, out result) ? result : -1;
        }
        private DateTime toDateTime(string strDateTime)
        {
            DateTime dt = DateTime.MinValue;
            return DateTime.TryParseExact(strDateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,DateTimeStyles.AssumeUniversal, out dt) ? dt : DateTime.MinValue;
            
        }
        private bool CheckIfCSVFile(IFormFile file)
        {
            
            var extension = Path.GetExtension(file.FileName);
            return extension == ".csv" ; 
        }

        private bool WriteFile(IFormFile file, out string filePath)
        {
            bool isSaveSuccess = false;
            string fileName = "";
            try
            {
                var extension = Path.GetExtension(file.FileName);
                fileName = DateTime.Now.Ticks + extension; //Create a new Name for the file due to security reasons.

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files",
                   fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                isSaveSuccess = true;
            }
            catch (Exception e)
            {
                //log error
                filePath = "";
            }

            return isSaveSuccess;
        }
    }
}
