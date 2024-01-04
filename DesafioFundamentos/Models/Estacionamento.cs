using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial, _precoPorHora;
        private int _capacidadeEstacionamento;
        private FichaEstacionamento[] _vagas;

        private const string PadraoPlaca = @"^[A-Z]{3}\d{1}[A-Z0-9]{2}\d{2}$"; // AAA0AA(00)00
        private const string PadraoCpf = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"; // 000.000.000-00
        Regex regexPlaca = new Regex(PadraoPlaca);
        Regex regexCpf = new Regex(PadraoCpf);
        
        public Estacionamento(decimal precoInicial, decimal precoPorHora, int capacidadeEstacionamento)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
            _capacidadeEstacionamento = capacidadeEstacionamento;
            _vagas = new FichaEstacionamento[capacidadeEstacionamento];
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            while (!regexPlaca.IsMatch(placa)) // Valida se a entrada segue o padrão de strings de placas
            {
                Console.WriteLine("Digite uma placa válida:");
                placa = Console.ReadLine().ToUpper();
            };

            Console.WriteLine("Digite o CPF do proprietário:");
            string cpf = Console.ReadLine();
            while (!regexCpf.IsMatch(cpf)) // Valida se a entrada segue o padrão de strings de cpfs
            {
                Console.WriteLine("Digite um cpf válido:");
                cpf = Console.ReadLine();
            };

            DateTime horaEntrada = DateTime.Now; // Registra o momento do cadastro do veículo

            FichaEstacionamento ficha = new FichaEstacionamento(placa, cpf, horaEntrada);
            bool isFull = true;
            for (int i = 0; i < _capacidadeEstacionamento; i++)
            {
                if (_vagas[i] == null)
                {
                    _vagas[i] = ficha;
                    Console.WriteLine($"O veículo {placa} foi estacionado na vaga de número {i} às {horaEntrada} com sucesso sob a responsabilidade do cpf: {cpf}.");
                    isFull = false;
                    break;
                }
            }

            if (isFull)
            {
                Console.WriteLine("O estacionamento está lotado!");
            };
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();
            Console.WriteLine("Digite o CPF do responsável:");
            string cpfCadastrado = Console.ReadLine();

            bool isFound = false;
            string[] horas = {"04/01/2024 22:59:24", "04/01/2024 23:59:24", "05/01/2024 06:59:24"};
            for (int i = 0; i < _capacidadeEstacionamento; i++)
            {
                if (placa == _vagas[i].Placa)
                {
                    isFound = true;
                    if (cpfCadastrado == _vagas[i].Cpf)
                    {
                        //DateTime horaSaida = DateTime.Now;
                        DateTime horaSaida = DateTime.Parse(horas[i]);
                        TimeSpan tempoEstacionado = horaSaida - _vagas[i].HoraEntrada;
                        decimal valorTotal = _precoInicial + _precoPorHora * Convert.ToDecimal(tempoEstacionado.TotalHours);
                        Console.WriteLine($"O veículo {placa} ficou estacionado de {_vagas[i].HoraEntrada} até {horaSaida} e foi removido pelo preço total de: R$ {valorTotal:C}");
                        _vagas[i] = null;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("O CPF digitado não corresponde ao responsável pelo veículo.");
                        break;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (_vagas.Any(elemento => elemento != null)) // Verifica se há veículos no estacionamento
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in _vagas)
                {
                    if (veiculo != null)
                    {
                        Console.WriteLine($"Placa: {veiculo.Placa} | CPF: {veiculo.Cpf} | Data de entrada: {veiculo.HoraEntrada}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}