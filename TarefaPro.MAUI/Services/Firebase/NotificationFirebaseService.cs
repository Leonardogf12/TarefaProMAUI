using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TarefaPro.MAUI.Controls;
using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.Services.Firebase
{
    public class NotificationFirebaseService : INotificationFirebaseService
    {
        public async Task<bool> PostNotificationAsync(NotificationDto model, string token)
        {
            try
            {                               
                model.Token = token;

                string json = JsonConvert.SerializeObject(model);

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{StringConstants.UrlApi}api/Notification/Send/";

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();

                        NotificationDto responseDto = JsonConvert.DeserializeObject<NotificationDto>(responseJson);
                        
                        return true;
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Erro no POST da API: {errorContent}");
                        return false;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro na solicitação HTTP: {ex.Message}");
                return false;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro de JSON: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro genérico: {ex.Message}");
                return false;
            }
        }
    }
}
