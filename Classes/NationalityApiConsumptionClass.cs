using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UserMgtApp.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace UserMgtApp.Classes
{
    public class NationalityApiConsumptionClass
    {
        private readonly IConfiguration configuration;

        WebResponse webResponse = null;
        Stream responseStream = null;

        public NationalityApiConsumptionClass(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<ApiResponse<List<Nationalities>>> GetAllNationalities()
        {
            string msg = "";

            //WHAT TO CHANGE FOR OTHERS: RESPONSE
            ApiResponse<List<Nationalities>> response = new ApiResponse<List<Nationalities>>();

            try
            {

                string apiControllerAndMethodName = "api/NationalityApi/GetAllNationalities";

                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(configuration.GetSection("AppSettings:ApiRootUrl").Value);

                    client.DefaultRequestHeaders.Clear();

                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync(apiControllerAndMethodName);

                    //Storing the response details recieved from web api   
                    var responseInString = await Res.Content.ReadAsStringAsync();

                    response = JsonConvert.DeserializeObject<ApiResponse<List<Nationalities>>>(responseInString);                   

                    //returning the employee list to view  
                    return response;
                }
            }
            catch (WebException eX)
            {
                webResponse = eX.Response;

                using (Stream s = webResponse.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        msg += "NationalityApiConsumptionClass: " + sr.ReadToEnd();
                    }
                }

                //log error
            }
            catch (Exception eX)
            {
                msg = eX.Message;

                if (eX.InnerException != null)
                {
                    msg += "; " + eX.InnerException.Message; if (eX.InnerException.InnerException != null) { msg += ";" + eX.InnerException.InnerException.Message; }
                }             
            }
            finally
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                    webResponse.Dispose();
                }

                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                }
            }

            return response;
        }
    }
}
