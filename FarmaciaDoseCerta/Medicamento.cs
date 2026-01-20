using System;

namespace FarmaciaDoseCerta
{
    public class Medicamento
    {
        public string Nome { get; set; }
        public int Dose { get; set; }
        public int EstoqueAtual { get; set; }
        public int EstoqueMinimo { get; set; }
        public int IntervaloHoras { get; set; }
        public DateTime HoraUltimaDose { get; set; }

        public Medicamento() { }

        public Medicamento(string nome, int dose, int estoqueAtual, int estoqueMinimo, int intervaloHoras, DateTime horaUltimaDose)
        {
            Nome = nome;
            Dose = dose;
            EstoqueAtual = estoqueAtual;
            EstoqueMinimo = estoqueMinimo;
            IntervaloHoras = intervaloHoras;
            HoraUltimaDose = horaUltimaDose;
        }

        public DateTime ProximaDose() => HoraUltimaDose.AddHours(IntervaloHoras);

        public void RegistrarDose()
        {
            HoraUltimaDose = DateTime.Now;
            EstoqueAtual -= Dose;
        }

        public bool PrecisaRepor() => EstoqueAtual <= EstoqueMinimo;

        public void ReporEstoque(int quantidade)
        {
            EstoqueAtual += quantidade;
        }
    }
}