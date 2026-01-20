using System;
using System.IO;
using FarmaciaDoseCerta;

namespace FarmaciaDoseCerta
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instância inicial do medicamento
            Medicamento med = new Medicamento("Dipirona", 1, 10, 3, 8, DateTime.Now);

            int opcao = 0;

            while (opcao != 3)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("=== SISTEMA DOSE CERTA - SEU AUXILIAR DE SAÚDE ===");

                    // Lógica de impacto: Alerta de estoque
                    if (med.PrecisaRepor())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" >>> AVISO: O estoque está baixo! Compre mais em breve. <<<");
                        Console.ResetColor();
                    }

                    Console.WriteLine($"\nRemédio: {med.Nome}");
                    Console.WriteLine($"Próxima Dose: {med.ProximaDose():dd/MM HH:mm}");
                    Console.WriteLine($"Estoque Atual: {med.EstoqueAtual} unidades");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("1. Registrar que tomei uma dose");
                    Console.WriteLine("2. Repor estoque (comprar mais)");
                    Console.WriteLine("3. Sair");
                    Console.Write("\nO que deseja fazer? ");

                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            if (med.EstoqueAtual >= med.Dose)
                            {
                                med.RegistrarDose();
                                Console.WriteLine("\nSucesso! Dose registrada. Não esqueça de se hidratar!");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nERRO: Você não tem estoque suficiente para esta dose!");
                                Console.ResetColor();
                            }
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.Write("\nQuantas unidades deseja adicionar? ");
                            int quantidadeReposta = int.Parse(Console.ReadLine());
                            med.ReporEstoque(quantidadeReposta);

                            Console.WriteLine($"\nEstoque atualizado! Agora você tem {med.EstoqueAtual} unidades.");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.WriteLine("\nSaindo... Use o medicamento com responsabilidade!");
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
    }
}