using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AMSClients
{
    //TODO
    public class VideosData
    {


        public async Task<string> GetRecipeDataItemsAsync()
 {
     try
     {
         var client = new HttpClient();


         var jsonTypeFormatter = new JsonMediaTypeFormatter();

         jsonTypeFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));

         var response = await client.GetAsync("http://videourls.azurewebsites.net/api/videourls");

         //return await response.Content.ReadAsAsync<List<RecipeDataItemDto>>(new[] { jsonTypeFormatter }); ;
         return await response.Content.ReadAsStringAsync(); 
     }
     catch (HttpRequestException ex )
         {
         return null;
         }
        }
 
   }
            public class RecipeDataItemDto
           {
              
                public string Title
               { get; set; }
           }
}


