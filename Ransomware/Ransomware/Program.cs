using System;
using System.IO;

// Diogo Araujo RA: 082180013 
// Humberto Gonzaga RA: 082180036 
// João Vitor Rocha RA: 082180024 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite a chave de cifragem (um número inteiro): ");
        int chave = Convert.ToInt32(Console.ReadLine());

        string arquivoEntrada = "C:\\Users\\joaov\\OneDrive\\Área de Trabalho\\Ransomware\\Codigo.txt";
        string arquivoBackup = "C:\\Users\\joaov\\OneDrive\\Área de Trabalho\\Ransomware\\CodigoBackup.txt";
        string arquivoSaida = "C:\\Users\\joaov\\OneDrive\\Área de Trabalho\\Ransomware\\CodigoCripto.txt";

        File.Copy(arquivoEntrada, arquivoBackup, true);
        string conteudo = File.ReadAllText(arquivoEntrada);
        string conteudoCriptografado = Encrypt(conteudo, chave);
        File.WriteAllText(arquivoSaida, conteudoCriptografado);

        Console.WriteLine("Código criptografado salvo em " + arquivoSaida);

        // Leitura do Arquivo Criptografado 
        string textoCifrado = File.ReadAllText(arquivoSaida);
        string textoDescifrado = "";

        //Decriptografando o texto (Feito pelo ChatGPT) 
        foreach (char c in textoCifrado)
        {
            int letra = (int)c;
            if (letra >= 65 && letra <= 90)
            {
                letra = (letra - 65 - chave + 26) % 26 + 65;
            }
            else if (letra >= 97 && letra <= 122)
            {
                letra = (letra - 97 - chave + 26) % 26 + 97;
            }
            textoDescifrado += (char)letra;
        }
        File.WriteAllText("C:\\Users\\joaov\\OneDrive\\Área de Trabalho\\Ransomware\\CodigoDecripto.txt", textoDescifrado);
        Console.WriteLine("Texto decriptografado com sucesso!");
        Console.ReadLine();
    }

    // Função da Cifra de Julio Cesar feito pelo ChatGPT 
    static string Encrypt(string text, int key)
    {
        char[] output = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            if (letter >= 'a' && letter <= 'z')
            {
                letter = (char)('a' + (letter - 'a' + key) % 26);
            }
            else if (letter >= 'A' && letter <= 'Z')
            {
                letter = (char)('A' + (letter - 'A' + key) % 26);
            }
            output[i] = letter;
        }
        return new string(output);
    }
}