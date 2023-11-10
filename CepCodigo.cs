using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsultaCEP
{
    public class CepCodigo
    {
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }


        public static async Task CEPConsult()
        {
            Console.WriteLine("Informe o CEP: (Não se esqueça do - )");
            string vCepConsult = Console.ReadLine();

            string vCep = vCepConsult;
            string vUrl = $"https://api.postmon.com.br/v1/cep/{vCep}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(vUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        //  Console.WriteLine(responseBody);
                        ConsultaCEP.CepCodigo vResult = JsonConvert.DeserializeObject<ConsultaCEP.CepCodigo>(responseBody);
                        Console.WriteLine($"\nBairro: {vResult.Bairro}");
                        Console.WriteLine($"\nCidade: {vResult.Cidade}");
                        Console.WriteLine($"\nLogradouro:  {vResult.Logradouro}");
                        Console.WriteLine($"\nEstado: {vResult.Estado}");
                        Console.WriteLine($"\nCEP: {vResult.Cep}");

                    }
                    else
                    {
                        Console.WriteLine("Erro na solicitação: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro na solicitação: " + ex.Message);
                }
            }
            Console.ReadKey();
        }
    }
}

