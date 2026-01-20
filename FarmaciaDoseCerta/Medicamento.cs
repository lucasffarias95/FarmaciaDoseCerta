using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaDoseCerta
{
    public class Medicamento
    {
        public string Nome;
        public int Dose;
        public int EstoqueAtual;
        public int EstoqueMinimo;
        int IntervaloHoras;
        public DateTime HoraUltimaDose {  get; private set; }

        public Medicamento(string nome, int dose, int estoqueAtual, int estoqueMinimo, int intervaloHoras, DateTime horaUltimaDose)
        {
            this.Nome = nome;
            this.Dose = dose;
            EstoqueAtual = estoqueAtual;
            EstoqueMinimo = estoqueMinimo;
            IntervaloHoras = intervaloHoras;
            HoraUltimaDose = horaUltimaDose;
        }

        public DateTime ProximaDose() { return HoraUltimaDose.AddHours(IntervaloHoras); }

        public void RegistrarDose()
        {
            HoraUltimaDose = DateTime.Now;
            EstoqueAtual -= Dose;
        }

        public bool PrecisaRepor() { return EstoqueAtual <= EstoqueMinimo; }

        public void ReporEstoque(int quantidade)
        {
            EstoqueAtual += quantidade;
        }
    }
}


