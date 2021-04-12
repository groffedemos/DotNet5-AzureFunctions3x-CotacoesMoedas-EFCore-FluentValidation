using System.Linq;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FunctionAppMoedas.Data;

namespace FunctionAppMoedas
{
    public class Cotacoes
    {
        private readonly MoedasContext _context;

        public Cotacoes(MoedasContext context)
        {
            _context = context;
        }

        [Function("Cotacoes")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Cotacoes");
            logger.LogInformation("Cotacoes - Processando requisição HTTP...");

            var dados = _context.Cotacoes.ToList();
            logger.LogInformation($"Qtde. registros = {dados.Count}");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(dados).AsTask().Wait();
            return response;
        }
    }
}