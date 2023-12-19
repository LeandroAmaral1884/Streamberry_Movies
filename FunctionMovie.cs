using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

class FunctionMovie
{
    public static List<Movie> acervo = new List<Movie>();
    public static void Listar()
    {
        if (acervo.Count == 0)
        {
            Console.WriteLine("Nenhum filme encontrado.");
            return;
        }

        Console.WriteLine("Lista de Filmes:");
        foreach (var f in acervo)
        {
            Console.WriteLine($"{f.Titulo} - {f.Genero} - {f.Ano} - Avaliação: {f.Avaliacao}");
        }
    }
    public static void Cadastrar()
    {
        Movie novoFilme = new Movie();

        Console.Write("Título: ");
        novoFilme.Titulo = Console.ReadLine().Trim();

        do
        {
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(genero) && !genero.Any(char.IsDigit))
            {
                novoFilme.Genero = genero;
                break;
            }
            Console.WriteLine("Digite nome válido.");
        } while (true);


        do
        {
            Console.Write("Ano: ");

            if (int.TryParse(Console.ReadLine()?.Trim(), out int ano) && ano >= 1930 && ano < 2024)
            {
                novoFilme.Ano = ano;
                break;
            }

            Console.WriteLine("Digite um ano válido entre 1930 e 2023.");

        } while (true);

        do
        {
            Console.Write("Avaliação: ");

            if (double.TryParse(Console.ReadLine()?.Trim(), out double avaliacao) && avaliacao >= 0 && avaliacao <= 10)
            {
                novoFilme.Avaliacao = avaliacao;
                break;
            }
            Console.WriteLine("Digite uma avaliação válida entre 0 e 10");
        } while (true);

        acervo.Add(novoFilme);
        Console.WriteLine("");
        Console.WriteLine("Filme adicionado com sucesso!");
        Console.WriteLine("");
    }
    public static void Atualizar()
    {
        Console.Write("Digite o título do filme que deseja atualizar: ");
        string titulo = Console.ReadLine();

        Movie filme = acervo.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (filme == null)
        {
            Console.WriteLine("Filme não encontrado.");
            return;
        }

        Console.Write("Novo título (ou Enter para manter o mesmo): ");
        string novoTitulo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoTitulo))
        {
            filme.Titulo = novoTitulo;
        }

        Console.Write("Novo gênero (ou Enter para manter o mesmo): ");
        string novoGenero = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoGenero))
        {
            filme.Genero = novoGenero;
        }

        Console.Write("Novo ano (ou Enter para manter o mesmo): ");
        string novoAnoStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoAnoStr))
        {
            int novoAno;
            if (int.TryParse(novoAnoStr, out novoAno))
            {
                filme.Ano = novoAno;
            }
            else
            {
                Console.WriteLine("Ano inválido. Mantendo o ano atual.");
            }
        }

        Console.Write("Nova avaliação (ou Enter para manter a mesma): ");
        string novaAvaliacaoStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novaAvaliacaoStr))
        {
            double novaAvaliacao;
            if (double.TryParse(novaAvaliacaoStr, out novaAvaliacao))
            {
                filme.Avaliacao = novaAvaliacao;
            }
            else
            {
                Console.WriteLine("Avaliação inválida. Mantendo a avaliação atual.");
            }
        }

        Console.WriteLine("Filme atualizado com sucesso!");
    }
    public static void Deletar()
    {
        Console.Write("Digite o título do filme que deseja deletar: ");
        string titulo = Console.ReadLine();

        Movie filme = acervo.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (filme == null)
        {
            Console.WriteLine("Filme não encontrado.");
            return;
        }

        acervo.Remove(filme);
        Console.WriteLine("Filme deletado com sucesso!");
    }
    public static void Pesquisar()
    {
        Console.Write("Digite o título do filme que deseja pesquisar: ");
        string titulo = Console.ReadLine();

        Movie movie = acervo.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (movie == null)
        {
            Console.WriteLine("Filme não encontrado.");
            return;
        }

        Console.WriteLine($"Filme encontrado: {movie.Titulo} - {movie.Genero} - {movie.Ano} - Avaliação: {movie.Avaliacao}");
    }
}


