using ConsumerViaCep;
using static System.Console;

WriteLine("Digite o CEP que deseja consultar:");

var cep = ReadLine();

var enderecoUrl = $"https://viacep.com.br/ws/{cep}/json/";

WriteLine($"Consultando o endereço na url: {enderecoUrl}");

var cliente = new HttpClient();

try
{
    HttpResponseMessage? response = await cliente.GetAsync(enderecoUrl);
    response.EnsureSuccessStatusCode();

    string respostaApi = await response.Content.ReadAsStringAsync();
    
    Endereco endereco = System.Text.Json.JsonSerializer.Deserialize<Endereco>(respostaApi);

    WriteLine($"\nCEP: {endereco.Cep}");
    WriteLine($"\nRua: {endereco.Logradouro}");
    WriteLine($"\nComplemento: {endereco.Complemento}");
    WriteLine($"\nBairro: {endereco.Bairro}");
    WriteLine($"\nLocalidade: {endereco.Localidade}");


    WriteLine($"\nResposta da API:\n{respostaApi}");
}

catch (Exception ex) 
{
WriteLine($"Ocorreu um erro ao consultar o endereço: {ex.Message}");
}