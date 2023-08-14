using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumController : ControllerBase
    {
        [HttpPost("sum-odd")]
        public ActionResult<int> SumSecondOddNumbers([FromBody] JArray numbersArray)
        {
            if (numbersArray == null)
            {
                return BadRequest("Input data is missing.");
            }

            int sum = 0;
            int oddCount = 0;

            foreach (int num in numbersArray.Values<int>())
            {
                if (num % 2 != 0)
                {
                    oddCount++;

                    if (oddCount % 2 == 0)
                    {
                        sum += num;
                    }
                }
            }

            return Math.Abs(sum);
        }
    }
}