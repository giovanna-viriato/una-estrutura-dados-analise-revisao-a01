using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Informe o seu nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Informe a sua idade:");
        int idade = int.Parse(Console.ReadLine());

        bool cartaoVacinalEmDia = PerguntaSimNao("Seu cartão de vacina está em dia?");
        bool teveSintomasRecentemente = PerguntaSimNao("Teve algum dos sintomas recentemente? (dor de cabeça, febre, náusea, dor articular, gripe)");
        bool teveContatoComPessoasInfectadas = PerguntaSimNao("Teve contato com pessoas com sintomas gripais nos últimos dias?");
        bool retornandoDeViagem = PerguntaSimNao("Está retornando de viagem realizada no exterior?");

        int porcentagemRisco = CalcularRisco(cartaoVacinalEmDia, teveSintomasRecentemente, teveContatoComPessoasInfectadas, retornandoDeViagem);

        Console.Write("\n ---------------------- Relatório Final ----------------------- \n");
        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Idade: " + idade);
        Console.WriteLine("Cartão Vacinal em Dia: " + (cartaoVacinalEmDia ? "SIM" : "NAO"));
        Console.WriteLine("Teve Sintomas Recentemente: " + (teveSintomasRecentemente ? "SIM" : "NAO"));
        Console.WriteLine("Teve contato com pessoas infectadas: " + (teveContatoComPessoasInfectadas ? "SIM" : "NAO"));
        Console.WriteLine("Retornando de viagem: " + (retornandoDeViagem ? "SIM" : "NAO"));
        Console.WriteLine("Probabilidade de estar infectado: " + porcentagemRisco + "%");

        string orientacao = ObterOrientacao(porcentagemRisco);
        Console.WriteLine(orientacao);
    }

    static bool PerguntaSimNao(string pergunta)
    {
        int tentativas = 0;
        while (tentativas < 3)
        {
            Console.WriteLine(pergunta + " (Responda SIM ou NAO):");
            string resposta = Console.ReadLine().Trim().ToUpper();

            if (resposta == "SIM")
                return true;
            else if (resposta == "NAO")
                return false;

            Console.WriteLine("Resposta inválida. Tente novamente.");
            tentativas++;
        }

        Console.WriteLine("Não foi possível realizar o diagnóstico. Gentileza procurar ajuda médica caso apareça algum sintoma.");
        Environment.Exit(0);
        return false;
    }

    static int CalcularRisco(bool cartaoVacinalEmDia, bool teveSintomasRecentemente, bool teveContatoComPessoasInfectadas, bool retornandoDeViagem)
    {
        int risco = 0;
        if (!cartaoVacinalEmDia)
            risco += 10;
        if (teveSintomasRecentemente)
            risco += 30;
        if (teveContatoComPessoasInfectadas)
            risco += 30;
        if (retornandoDeViagem)
        {
            risco += 30;
            Console.WriteLine("\nVocê ficará sob observação por 05 dias.");
        }
        return risco;
    }

    static string ObterOrientacao(int porcentagemRisco)
    {
        if (porcentagemRisco <= 30)
            return "Paciente sob observação. Caso apareça algum sintoma, gentileza buscar assistência médica.";
        else if (porcentagemRisco <= 60)
            return "Paciente com risco de estar infectado. Gentileza aguardar em lockdown por 02 dias para ser acompanhado.";
        else if (porcentagemRisco <= 89)
            return "Paciente com alto risco de estar infectado. Gentileza aguardar em lockdown por 05 dias para ser acompanhado.";
        else
            return "Paciente crítico! Gentileza aguardar em lockdown por 10 dias para ser acompanhado.";
    }
}
