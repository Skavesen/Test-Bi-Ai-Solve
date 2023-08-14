using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalindromeController : ControllerBase
    {
        [HttpPost("check-palindrome")]
        public ActionResult<bool> CheckPalindrome([FromBody] string inputString)
        {
            string cleanedString = inputString.ToLower().Replace(" ", "").Replace("-", "");
            string reversedString = new string(cleanedString.Reverse().ToArray());

            return cleanedString == reversedString;
        }
    }
}