using System;
using System.Collections.Generic;
using System.Threading;

class Program
{


   
    static Dictionary<string, List<double>> alunos_notas = new Dictionary<string, List<double>>();

    static void Main(string[] args)
    {
        ExibirMenu();
    }

    public static void ExibirMenu()
    {
        int opcao = 0;

        while (opcao != 4)
        {
            Console.Clear();

            Console.WriteLine("       CALCULADORA DE NOTAS");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar aluno");
            Console.WriteLine("2 - Lançar notas");
            Console.WriteLine("3 - Calcular média");
            Console.WriteLine("4 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida! Digite um número de 1 a 4.");
                Thread.Sleep(2000);
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarAluno();
                    break;

                case 2:
                    LancarNotas();
                    break;

                case 3:
                    CalcularMedia();
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Encerrando o sistema...");
                    Thread.Sleep(1500);
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida! Escolha um número entre 1 e 4.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    public static void CadastrarAluno()
    {
        Console.Clear();

        Console.WriteLine("CADASTRAMENTO DE ALUNO");
        Console.WriteLine();

        Console.Write("Digite o nome do aluno: ");
        string aluno = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(aluno))
        {
            Console.WriteLine();
            Console.WriteLine("O nome do aluno não pode ficar vazio.");
            Thread.Sleep(2000);
            return;
        }

        if (!alunos_notas.ContainsKey(aluno))
        {
            alunos_notas.Add(aluno, new List<double>());

            Console.WriteLine();
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("O aluno digitado já existe no sistema.");
        }

        Thread.Sleep(2000);
    }

    public static void LancarNotas()
    {
        Console.Clear();

        Console.WriteLine("LANÇAMENTO DE NOTAS");
        Console.WriteLine();

        Console.Write("Digite o nome do aluno: ");
        string aluno = Console.ReadLine();

        if (!alunos_notas.ContainsKey(aluno))
        {
            Console.WriteLine();
            Console.WriteLine("Aluno não encontrado.");
            Thread.Sleep(2000);
            return;
        }

        Console.WriteLine();
        Console.Write("Digite a nota: ");

        if (!double.TryParse(Console.ReadLine(), out double nota))
        {
            Console.WriteLine();
            Console.WriteLine("Nota inválida.");
            Thread.Sleep(2000);
            return;
        }

        if (nota < 0 || nota > 10)
        {
            Console.WriteLine();
            Console.WriteLine("A nota deve estar entre 0 e 10.");
            Thread.Sleep(2000);
            return;
        }

        alunos_notas[aluno].Add(nota);

        Console.WriteLine();
        Console.WriteLine("Nota lançada com sucesso!");

        Thread.Sleep(2000);
    }

    public static void CalcularMedia()
    {
        Console.Clear();

        Console.WriteLine("CALCULAR MÉDIA");
        Console.WriteLine();

        Console.Write("Digite o nome do aluno: ");
        string aluno = Console.ReadLine();

        if (!alunos_notas.ContainsKey(aluno))
        {
            Console.WriteLine();
            Console.WriteLine("Aluno não encontrado.");
            Thread.Sleep(2000);
            return;
        }

        List<double> notas = alunos_notas[aluno];

        if (notas.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Esse aluno ainda não possui notas.");
            Thread.Sleep(2000);
            return;
        }

        double soma = 0;

        foreach (double nota in notas)
        {
            soma += nota;
        }

        double media = soma / notas.Count;

        Console.WriteLine();
        Console.WriteLine("Aluno: " + aluno);
        Console.WriteLine("Quantidade de notas: " + notas.Count);
        Console.WriteLine("Média: " + media.ToString("F2"));

        if (media >= 7)
        {
            Console.WriteLine("Situação: Aprovado");
        }
        else
        {
            Console.WriteLine("Situação: Reprovado");
        }

        Console.WriteLine();
        Console.WriteLine("Notas:");

        foreach (double nota in notas)
        {
            Console.WriteLine(nota.ToString("F2"));
        }

        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para continuar.");
        Console.ReadLine();
    }
}
