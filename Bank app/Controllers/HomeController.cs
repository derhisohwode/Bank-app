using Bank_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_app.Controllers
{
    public class HomeController : Controller
    {
        //question 1
        [Route("/")]
        public IActionResult Index()
        {
            return Content("<h3>Welcome to the Best Bank</h3>", "text/html");
        }

        //question 2
        [Route("account-details")]

        public IActionResult AccoutDetails()
        {
                Account account = new Account()
                {
                    accountNumber = 1001,
                    accountHolderName = "David Adekunle",
                    currentBalance = 5000
                };


                return Json(account);
        }

        //question 3 
        [Route("account-statement")]
        public IActionResult Statement()
        {
            return File("/2022 Memo.docx", "application/msword");
        }
        //question 4 & 5& 6
        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult Balance(int? accountNumber)
        {
            Account account = new Account()
            {
                accountNumber = 1001,
                accountHolderName = "David Adekunle",
                currentBalance = 5000
            };

            if (accountNumber == null)
                return NotFound("Account Number should be supplied");


            int? Number = Convert.ToInt32(account.accountNumber);
            string? balance = Convert.ToString(account.currentBalance);
            int? routeValue = Convert.ToInt32(Request.RouteValues["accountNumber"]);

            if (routeValue != Number)
            {
                return BadRequest("Account Number should be 1001");
            }

                return Content(balance);

        }

        ////question 5
        //[Route("/get-current-balance/{accountNumber}")]
        //public IActionResult Response()
        //{
        //    Account account = new Account()
        //    {
        //        accountNumber = 1001,
        //        accountHolderName = "David Adekunle",
        //        currentBalance = 5000
        //    };

        //    int? Number = Convert.ToInt32(account.accountNumber);
        //    string? balance = Convert.ToString(account.currentBalance);
        //    int? routeValue = Convert.ToInt32(Request.RouteValues["accountNumber"]);

        //    if (routeValue != Number)
        //    {
        //        return NotFound($"Account number {routeValue} does not exists");
        //    }

        //    return Content(balance);
        //}
    }
}
