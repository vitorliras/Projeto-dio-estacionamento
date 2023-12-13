using System;
using System.Collections.Generic;

namespace Model
{
    public class Estacionamento
    {
        private List<Veiculo> veiculosEstacionados = new List<Veiculo>();

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo: ");
            string placa = Console.ReadLine();

            Veiculo novoVeiculo = new Veiculo
            {
                Placa = placa,
                Entrada = DateTime.Now
            };

            veiculosEstacionados.Add(novoVeiculo);

            Console.WriteLine($"Veículo da placa {placa} foi adicionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.Write("Informe a placa do veículo que vai ser removido: ");
            string placa = Console.ReadLine();

            Veiculo veiculo = veiculosEstacionados.Find(v => v.Placa == placa);

            if (veiculo != null)
            {
                TimeSpan tempoEstacionado = DateTime.Now - veiculo.Entrada;
                double valorCobrado = CalcularValorEstacionamento(tempoEstacionado.TotalHours);

                Console.WriteLine($"Veículo {placa} removido. Valor cobrado: R${valorCobrado:F2}");
                veiculosEstacionados.Remove(veiculo);
            }
            else
            {
                Console.WriteLine($"Veículo com placa {placa} não encontrado.");
            }
        }

        public void ListarVeiculos()
        {
            if(veiculosEstacionados.Count() > 0)
            {
                Console.WriteLine("Veículos estacionados:");
                foreach (var veiculo in veiculosEstacionados)
                {
                    Console.WriteLine($"Placa: {veiculo.Placa} - Entrada: {veiculo.Entrada}");
                }
            }else{
                Console.WriteLine("Nenhum Veículo estacionado");

            }
        }

        private double CalcularValorEstacionamento(double horasEstacionado)
        {
            return horasEstacionado * 5.0;
        }
    }
}