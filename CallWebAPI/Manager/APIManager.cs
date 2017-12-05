using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CallWebAPI
{
   public static class  APIManager
    {
        public static async Task<T> CallApi<T>(string apiUrl, object value)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                var w = client.PostAsJsonAsync(apiUrl, value);
                w.Wait();
                HttpResponseMessage response = w.Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<T>();
                    result.Wait();
                    return result.Result;
                }
                return default(T);
            }
        }
        public static long GetNewID()
        {
            DateTime datetime = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            long ID = long.Parse(pc.GetYear(datetime).ToString() + pc.GetMonth(datetime).ToString() + pc.GetDayOfMonth(datetime).ToString() + datetime.TimeOfDay.ToString().Replace(":", "").Replace(".", "").Substring(0, 10));
            return ID;
        }
    }
}
