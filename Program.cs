using System.IO;

namespace TextEditor
{
  class Program
  {
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("1 - Abrir arquivo");
      Console.WriteLine("2 - Criar novo arquivo");
      Console.WriteLine("0 - Sair");
      short option = short.Parse(Console.ReadLine()); //ReadLine é uma string, não pode jogar uma string num tipo short, por isso a conversão short.Parse

      switch (option)
      {
        case 1: Abrir(); break;
        case 2: Editar(); break;
        case 0: System.Environment.Exit(0); break;
        default: Menu(); break;
      }
    }

    static void Abrir()
    {
      Console.Clear();
      Console.WriteLine("Qual caminho do arquivo?");
      string path = Console.ReadLine();

      using(var file = new StreamReader(path)) //StreamReader(Ler). StreamWrite(Escrever)
      {
        string text = file.ReadToEnd(); // "ReadToEnd" lê o texto até o final.
        Console.WriteLine(text);
      }
      Console.WriteLine("");
      Console.ReadLine();
      Menu();

    }

    static void Editar()
    {
      Console.Clear();
      Console.WriteLine("Digite seu texto abaixo. (ESC para sair)");
      Console.WriteLine("-----------------------");
      string text = "";

      // Se a tecla for diferente de "ConsoleKey.Escape". Enquanto o usuario nao apertar a tecla ESC, ele nao vai sair do laço de repetição
      do 
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
        
      while (Console.ReadKey().Key != ConsoleKey.Escape); // o código só é executado se essa condição é verdadeira

      Salvar(text);
      {
        
      }
    }

    static void Salvar(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual caminho parSIalvar o arquivo?");
      var path = Console.ReadLine(); // path = caminho

      using (var file = new StreamWriter(path)) // No "using" todo objeto que passar dentro do parenteses, ele cria, abre e fecha automaticamente o objeto
      {                                         // StreamWriter => Abre um arquivo para escrita
        file.Write(text);
      }

      Console.WriteLine($"Arquivo {path} foi salvo com sucesso!");
      Console.ReadLine();
      Menu();
    }
  }  
}

