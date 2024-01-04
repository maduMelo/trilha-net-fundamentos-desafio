using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesafioFundamentos.Models
{
    public class FichaEstacionamento
    {
        private string _placa, _cpf;
        private DateTime _horaEntrada;

        public string Placa { get => _placa; set => _placa = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public DateTime HoraEntrada { get => _horaEntrada; set => _horaEntrada = value; }

        public FichaEstacionamento(string placa, string cpf, DateTime horaEntrada)
        {
            _placa = placa;
            _cpf = cpf;
            _horaEntrada = horaEntrada;
        }
    }
}