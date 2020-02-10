using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using ParkingPermitHangfire.Model;
using Newtonsoft.Json;

namespace ParkingPermitHangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallParkingPermitController : ControllerBase
    {
        [HttpPost]
        [ActionName("ProcessCustomerTags")]
        [JobDisplayName("This job will schedule parking permit.")]
        [Description("This job will insert Parking Permit details")]
        [AutomaticRetry(Attempts = 3)]
        [DisableConcurrentExecution(1000)]
        public void CallParkingPermit()
        {
            try
            {
                CallService("http://localhost:44306/SmartParkingPermit/", "ParkingPermit/SaveParkingPermit", "Post");
            }
            catch (Exception ex)
            {
                //HandleException(ex);
                //return ServiceResponseMessage(HttpStatusCode.InternalServerError, null, new List<string> { CoreResource.ProcessCustomerTagError });
            }
        }

        private static HttpResponseMessage CallService(string baseAddress, string requestUri, string action)
        {
            HttpResponseMessage httpResponseMessage;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(baseAddress);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Add jtw token 
                //var jwtEncodedString = token.Trim();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtEncodedString);
                ParkingPermitResquestVM parkingPermitResquestVM = new ParkingPermitResquestVM();

                var parkingPermitResquestModel = new ParkingPermitResquestModel()
                {
                    ApprovedBy = "CodingTest@smartercity.com.au",
                    CarParkingId = "1",
                    Description = "Test Parking",
                    EntityName = "Test Parking",
                    LicensePlate = "L000009",
                    Reason = "Coding Test",
                    ValidFrom = "09/02/2020",
                    ValidUntil = "09/02/2020"
                };
                parkingPermitResquestVM.ParkingPermitResquest = parkingPermitResquestModel;
                var jsonRequestVM = "";
                jsonRequestVM = JsonConvert.SerializeObject(parkingPermitResquestVM);

                if (action == "Post")
                {
                    var requestVM = new StringContent(jsonRequestVM, Encoding.UTF8, "application/json");
                    httpResponseMessage = client.PostAsync(requestUri, requestVM).Result;
                }
                else
                {
                    httpResponseMessage = client.GetAsync(requestUri).Result;
                }

            }
            return httpResponseMessage;
        }


    }
}
