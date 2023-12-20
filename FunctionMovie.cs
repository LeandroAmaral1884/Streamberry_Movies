using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        Console.WriteLine("");
        Console.WriteLine("Lista de Filmes:");
        Console.WriteLine("");
        foreach (var f in acervo)
        {
            Console.WriteLine($"Filme : {f.Titulo} - Gênero: {f.Genero} - Ano: {f.Ano} - Avaliação: {f.Avaliacao}");
            Console.WriteLine("");
        }
    }
    public static void Cadastrar()
    {
        Movie novoFilme = new Movie();

        do
        {
            Console.WriteLine("");
            Console.Write("Título: ");
            string filme = Console.ReadLine();
            if (!string.IsNullOrEmpty(filme))
            {
                novoFilme.Titulo = filme;
                break;

            }

            Console.WriteLine("Digite título válido.");

        } while (true);

        do
        {
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            if (!string.IsNullOrEmpty(genero) && !genero.Any(char.IsDigit))
            {
                novoFilme.Genero = genero;
                break;
            }
            Console.WriteLine("Digite gênero válido.");
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
        Console.WriteLine($"Filme : {novoFilme.Titulo} - Gênero: {novoFilme.Genero} - Ano: {novoFilme.Ano} - Avaliação: {novoFilme.Avaliacao}");
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

        Console.WriteLine("");

        Console.Write($"Título atual ({filme.Titulo}) (ou Enter para manter o mesmo): ");
        string novoTitulo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoTitulo))
        {
            filme.Titulo = novoTitulo;
        }

        Console.WriteLine("");

        do
        {
            Console.Write($"Gênero atual ({filme.Genero}) (ou Enter para manter o mesmo): ");
            string novoGenero = Console.ReadLine();

            if ( !novoGenero.Any(char.IsDigit))
            {
                filme.Genero = novoGenero;
                break;
            }
            Console.WriteLine("Digite gênero válido.");
        } while (true);

        Console.WriteLine("");

        Console.Write($"Ano atual ({filme.Ano}) (ou Enter para manter a mesma): ");
        do
        {
            Console.Write("Ano: ");

            if (int.TryParse(Console.ReadLine()?.Trim(), out int ano) && ano >= 1930 && ano < 2024)
            {
                filme.Ano = ano;
                break;
            }

            Console.WriteLine("Digite um ano válido entre 1930 e 2023.");

        } while (true);

        Console.WriteLine("");

        Console.Write($"Nova avaliação (ou Enter para manter a mesma): ");
        string novaAvaliacaoI = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novaAvaliacaoI))
        {
            if (double.TryParse(novaAvaliacaoI, out double novaAvaliacao) && novaAvaliacao >= 0 && novaAvaliacao <= 10)
            {
                filme.Avaliacao = novaAvaliacao;
            }
            else
            {
                Console.WriteLine("Avaliação inválida. Mantendo a avaliação atual.");
            }
        }

        Console.WriteLine("");
        Console.WriteLine($"Filme: {filme.Titulo} - Gênero {filme.Genero} - Ano: {filme.Ano} - Avaliação: {filme.Avaliacao}");
        Console.WriteLine();
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

        Console.WriteLine($"Filme encontrado: {movie.Titulo} - Gênero: {movie.Genero} - Ano: {movie.Ano} - Avaliação: {movie.Avaliacao}");
    }
}


