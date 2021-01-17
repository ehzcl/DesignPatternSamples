using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranRJVerificadorPontosRepository : DetranVerificadorPontosRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;
        private Random random;

        public DetranRJVerificadorPontosRepository(ILogger<DetranRJVerificadorPontosRepository> logger)
        {
            _Logger = logger;
            random = new Random();
        }

        protected override Task<IEnumerable<PontoCarteira>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var csize = chars.Length;
            var numbers = "0123456789";
            return Task.FromResult<IEnumerable<PontoCarteira>>(new List<PontoCarteira>() { new PontoCarteira() { DataOcorrencia = DateTime.UtcNow , Pontuacao = (byte)random.Next(0, 255), PlacaVeiculo = $"{chars[random.Next(csize)]}{chars[random.Next(csize)]}{chars[random.Next(csize)]}-{numbers[random.Next(10)]}{numbers[random.Next(10)]}{numbers[random.Next(10)]}{numbers[random.Next(10)]}"}});
        }

        protected override Task<string> RealizarAcesso(Carteira carteira)
        {
            Task.Delay(5000).Wait(); //Deixando o serviço mais lento para evidenciar o uso do CACHE.
            _Logger.LogDebug($"Consultando a pontuacao da CNH {carteira.numeroCNH} para o estado de RJ.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/RJ");
        }
    }
}
