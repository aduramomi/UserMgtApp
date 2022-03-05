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
    public class UserApiConsumptionClass
    {
        private readonly IConfiguration configuration;

        WebResponse webResponse = null;
        Stream responseStream = null;

        public UserApiConsumptionClass(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<ApiResponse<int>> AddUser(User user)
        {
            string msg = "";
           
            ApiResponse<int> response = new ApiResponse<int>();

            try
            { 
                using (var client = new HttpClient())
                {                   
                    client.Timeout = new TimeSpan(0, 10, 0); //10 minutes

                    client.DefaultRequestHeaders.Clear();

                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpRequestContentProperties content = new HttpRequestContentProperties
                    {
                        DateOfBirth = user.DateOfBirth,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        Gender = user.Gender,
                        LastName = user.LastName,
                        NationalityId = user.NationalityId,
                        PhoneNo = user.PhoneNo,
                        UserTypeId = user.UserTypeId
                    };

                    string serializedContent = JsonConvert.SerializeObject(content);

                    StringContent stringContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");                   
                    
                    HttpResponseMessage Res = await client.PostAsync(string.Concat(configuration.GetSection("AppSettings:ApiRootUrl").Value, "api/UserApi/AddUser"), stringContent);

                    //Storing the response details received from web api   
                    var responseInString = await Res.Content.ReadAsStringAsync();

                    response = JsonConvert.DeserializeObject<ApiResponse<int>>(responseInString); 
                   
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
                        msg += "UserApiConsumptionClass: " + sr.ReadToEnd();
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

                //log error
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

        public async Task<ApiResponse<int>> UpdateUser(User user)
        {
            string msg = "";

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                using (var client = new HttpClient())
                {                   
                    client.Timeout = new TimeSpan(0, 10, 0); //10 minutes

                    client.DefaultRequestHeaders.Clear();

                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("NoCache");

                    HttpRequestContentProperties content = new HttpRequestContentProperties
                    {
                        UserId = user.UserId,
                        DateOfBirth = user.DateOfBirth,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        Gender = user.Gender,
                        LastName = user.LastName,
                        NationalityId = user.NationalityId,
                        PhoneNo = user.PhoneNo,
                        UserTypeId = user.UserTypeId
                    };

                    string serializedContent = JsonConvert.SerializeObject(content);

                    StringContent stringContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");                   
                   
                    HttpResponseMessage Res = await client.PostAsync(string.Concat(configuration.GetSection("AppSettings:ApiRootUrl").Value, "api/UserApi/UpdateUser"), stringContent);

                    //Storing the response details received from web api   
                    var responseInString = await Res.Content.ReadAsStringAsync();

                    response = JsonConvert.DeserializeObject<ApiResponse<int>>(responseInString);  
                   
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
                        msg += "UserApiConsumptionClass: " + sr.ReadToEnd();
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

                //log error
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

        public async Task<ApiResponse<int>> DeleteUser(int userId)
        {
            string msg = "";
           
            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
              
                string queryString = "";
               
                queryString += "?userId=" + userId;
              
                //make a call to the api project               
                string apiControllerAndMethodName = "api/UserApi/DeleteUser" + queryString;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration.GetSection("AppSettings:ApiRootUrl").Value);
                    client.Timeout = new TimeSpan(0, 10, 0); //10 minutes

                    client.DefaultRequestHeaders.Clear();

                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var httpResponse = await client.PostAsync(apiControllerAndMethodName, null);
                    //postTask.Wait();

                    //Storing the response details received from web api   
                    var responseInString = await httpResponse.Content.ReadAsStringAsync();

                    response = JsonConvert.DeserializeObject<ApiResponse<int>>(responseInString);                   
                }
            }
            catch (WebException eX)
            {
                webResponse = eX.Response;

                using (Stream s = webResponse.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        msg += "UserApiConsumptionClass: " + sr.ReadToEnd();
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

                //log error
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

        public async Task<ApiResponse<int>> DeleteUsers(string userIds)
        {
            string msg = "";

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {

                string queryString = "";
              
                queryString += "?userIds=" + userIds;
                
                //make a call to the api project
              
                string apiControllerAndMethodName = "api/UserApi/DeleteUsers" + queryString;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration.GetSection("AppSettings:ApiRootUrl").Value);
                    client.Timeout = new TimeSpan(0, 10, 0); //10 minutes

                    client.DefaultRequestHeaders.Clear();

                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var httpResponse = await client.PostAsync(apiControllerAndMethodName, null);
                    //postTask.Wait();

                    //Storing the response details received from web api   
                    var responseInString = await httpResponse.Content.ReadAsStringAsync();

                    response = JsonConvert.DeserializeObject<ApiResponse<int>>(responseInString);                  
                }
            }
            catch (WebException eX)
            {
                webResponse = eX.Response;

                using (Stream s = webResponse.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        msg += "UserApiConsumptionClass: " + sr.ReadToEnd();
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

        public async Task<ApiResponse<List<User>>> GetAllUsers()
        {
            string msg = "";
           
            ApiResponse<List<User>> response = new ApiResponse<List<User>>();

            try
            {
                string apiControllerAndMethodName = "api/UserApi/GetAllUsers";

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

                    response = JsonConvert.DeserializeObject<ApiResponse<List<User>>>(responseInString);   
                   
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
                        msg += "UserApiConsumptionClass: " + sr.ReadToEnd();
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

        public async Task<ApiResponse<User>> GetUserById(int? userId)
        {
            string msg = "";
            
            ApiResponse<User> response = new ApiResponse<User>();

            try
            {
                string apiControllerAndMethodName = "api/UserApi/GetUserById?userId=" + userId;

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

                    response = JsonConvert.DeserializeObject<ApiResponse<User>>(responseInString);
                  
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
                        msg += "UserApiConsumptionClass: " + sr.ReadToEnd();
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
