using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiVat.Blazor.Server.Models
{
    public class ClientProcessor
    {
        public static async Task<ClientModel> LoadCustomer(string nipNumber)
        {

            var dateString = DateTime.Now.ToString("yyyy-MM-dd");
            string url = $"https://wl-test.mf.gov.pl/api/search/nip/{nipNumber}?date={dateString}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    ClientResult result = await response.Content.ReadAsAsync<ClientResult>();
                    ClientSubject subject = result.Result;
                    ClientModel client = subject.Subject;
                    return client;
                }
                else
                {
                    ErrorMessageModel message = await response.Content.ReadAsAsync<ErrorMessageModel>();
                    if (message!=null)
                    {
                        ClientModel client = new();
                        client.ErrorMessage = message.Message.ToString();
                        return client;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }                  
                }             
            }

        }
    }
}
