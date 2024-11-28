using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System.Net.Http.Json;


namespace ClientLibrary.Services.Implementations
{
    public class GenericServiceImplementation<T>(GetHttpClient getHttpClient) : IGenericServiceInterface<T>
    {
        // Aqui fazemos a criacao. 
        // Only authenticat/Admin or anybody whos admin has given the power too,
        // second person(manager) can handle this
        // that is why is private
        public async Task<GeneralResponse> Insert(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}/add", item);

            // Log da resposta
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Insert Response Content: {responseContent}"); // Log da resposta

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
                return result!;
            }
            else
            {
                // Aqui você pode retornar um GeneralResponse com uma mensagem de erro personalizada
                return new GeneralResponse(false, "Error!");
            }
        }


        //Read All or GetAll
        //
        public async Task<List<T>> GetAll(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<T>>($"{baseUrl}/all");
            return results!;
        }

        //Read Single {id} Get by iD
        public async Task<T> GetById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<T>($"{baseUrl}/single/{id}");
            return result!;
        }

        //Update {model}
        public async Task<GeneralResponse> Update(T item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PutAsJsonAsync($"{baseUrl}/update", item);

            // Log da resposta
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Update Response Content: {responseContent}"); // Log da resposta

            // Tente desserializar a resposta
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        //Delete {id}
        public async Task<GeneralResponse> DeleteById(int id, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.DeleteAsync($"{baseUrl}/delete/{id}");
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
    }
}
