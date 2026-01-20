using System;
using System.IO;
using System.Text.Json;
using FarmaciaDoseCerta;
using System.Collections.Generic;

namespace FarmaciaDoseCerta
{
    public class Program
    {
        static string caminhoArquivo = "dados.json";
        static void Main(string[] args)
        {
            // Instância inicial do medicamento
            List<Medicamento> listaMedicamentos = CarregarDados();

            int opcao = 0;

            while (opcao != 3)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("=== SISTEMA DOSE CERTA - SEU AUXILIAR DE SAÚDE ===");

                    // Lógica de alerta de estoque
                    if (listaMedicamentos.Count == 0)
                    {
                        Console.WriteLine("\n[NENHUM REMÉDIO CADASTRADO]");
                    }
                    else
                    {
                        Console.WriteLine("\nSEUS MEDICAMENTOS:");
                        for (int i = 0; i < listaMedicamentos.Count; i++)
                        {
                            var m = listaMedicamentos[i];
                            string alerta = m.PrecisaRepor() ? "[ ESTOQUE BAIXO!] " : "";
                            Console.WriteLine($"{i}. {m.Nome} - Próxima dose: {m.ProximaDose():HH:mm} - Estoque: {m.EstoqueAtual}{alerta}");
                        }
                    }

                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("0. Cadastrar novo remédio");
                    Console.WriteLine("1. Registrar que tomei uma dose");
                    Console.WriteLine("2. Repor estoque (comprar mais)");
                    Console.WriteLine("3. Sair");
                    Console.WriteLine("4. Remover medicamento");
                    Console.Write("\nO que deseja fazer? ");

                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 0: 
                            Console.WriteLine("--- Cadastro de novo remédio ---");
                            Console.Write("Nome :");
                            string nome = Console.ReadLine();

                            Console.Write("Dose (Quantas unidades por vez): ");
                            int dose = int.Parse(Console.ReadLine());

                            Console.Write("Estoque Atual :");
                            int estoque = int.Parse(Console.ReadLine());

                            Console.Write("Estoque mínimo para alerta: ");
                            int min = int.Parse(Console.ReadLine());

                            Console.Write("Intervalo entre as doses: ");
                            int intervalo = int.Parse(Console.ReadLine());

                            Medicamento novoMed = new Medicamento(nome, dose, estoque, min, intervalo, DateTime.Now);
                            listaMedicamentos.Add(novoMed);

                            SalvarDados(listaMedicamentos);

                            Console.WriteLine("\nRemédio cadastrado com sucesso!");
                            Console.ReadKey();
                            break;

                        case 1:
                            if (listaMedicamentos.Count > 0)
                            {
                                Console.Write("Digite o número do remédio: ");
                                int idx = int.Parse(Console.ReadLine());
                                if (idx >= 0 && idx < listaMedicamentos.Count)
                                {
                                    var selecionado = listaMedicamentos[idx];
                                    if (selecionado.EstoqueAtual >= selecionado.Dose)
                                    {
                                        selecionado.RegistrarDose();
                                        SalvarDados(listaMedicamentos);
                                        Console.WriteLine("\nDose registrada!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nEstoque insuficiente!");
                                    }
                                }
                            }
                            else { Console.WriteLine("\nCadastre algo primeiro!"); }
                            Console.ReadKey();
                            break;

                        case 2:
                            if (listaMedicamentos.Count > 0)
                            {
                                Console.Write("Digite o número do remédio para repor: ");
                                int idxRepo = int.Parse(Console.ReadLine());
                                if (idxRepo >= 0 && idxRepo < listaMedicamentos.Count)
                                {
                                    Console.Write("Quantidade comprada: ");
                                    int qtd = int.Parse(Console.ReadLine());
                                    listaMedicamentos[idxRepo].ReporEstoque(qtd);
                                    SalvarDados(listaMedicamentos);
                                    Console.WriteLine("\nEstoque atualizado!");
                                }
                            }
                            else { Console.WriteLine("\nCadastre algo primeiro!"); }
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.WriteLine("\nSaindo... Use o medicamento com responsabilidade!");
                            break;

                        case 4:
                            if(listaMedicamentos.Count > 0)
                            {
                                Console.WriteLine("Digite o número do remédio que deseja remover :");
                                int idxRemover = int.Parse(Console.ReadLine());

                                if (idxRemover >= 0 && idxRemover < listaMedicamentos.Count)
                                {
                                    Console.WriteLine($"Removendo {listaMedicamentos[idxRemover].Nome}...");
                                    listaMedicamentos.RemoveAt(idxRemover);

                                    SalvarDados(listaMedicamentos);

                                    Console.WriteLine("\nRemovido com sucesso!");
                                }
                                else { Console.WriteLine("\nNúmero inválido!"); }
                            }
                        else { Console.WriteLine("\nNão há nada para remover!"); }
                            Console.ReadKey();
                        break;

                                default:
                            Console.WriteLine("\nOpção inválida! Tente novamente.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nERRO: Entrada inválida! Por favor, digite apenas números.");
                    Console.ResetColor();
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }
        static void SalvarDados(List<Medicamento> lista)
        {
            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoArquivo, json);
        }

        static List<Medicamento> CarregarDados()
        {
            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    string json = File.ReadAllText(caminhoArquivo);
                    return JsonSerializer.Deserialize<List<Medicamento>>(json) ?? new List<Medicamento>();
                }
            }
            catch { }

            return new List<Medicamento>();
        }
    }
}