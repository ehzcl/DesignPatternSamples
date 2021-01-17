using System;

namespace DesignPatternSamples.WebAPI.Models.Detran
{
    public class PontoCarteiraModel
    {
        public string PlacaVeiculo { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public byte Pontuacao { get; set; }
    }
}