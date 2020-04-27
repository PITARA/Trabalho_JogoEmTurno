using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    #region Variáveis

    [SerializeField] private GameObject painelJogar, painelClasse, painelNome, inputField, displayNomeJogador;
    private Classe classe1 = new Classe1();
    private Classe classe2 = new Classe2();
    private Classe classe3 = new Classe3();

    public string nomeJogador;

    #endregion Variáveis

    // Função para ativar ou desativar o painelJogar
    public void PainelJogar()
    {
        // Se o painelJogar não estiver ativo na hierarquia
        if (!painelJogar.activeInHierarchy)
        {
            // O painelJogar será ativado
            painelJogar.SetActive(true);
        }
        else // Se o painelJogar estiver ativo na hierarquia
        {
            // O painelJogar será desativado
            painelJogar.SetActive(false);
        }
    }

    // Função para ativar ou desativar o painelClasse e definir a classe do jogador como Classe1
    public void PainelClasse1()
    {
        // Se o painelClasse não estiver ativo na hierarquia
        if (!painelClasse.activeInHierarchy)
        {
            // O painelClasse será ativado
            painelClasse.SetActive(true);
        }
        else // Se o painelClasse estiver ativo na hierarquia
        {
            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe1
            classe1.DefinirClasse();

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            classe1.PegarInfo();
        }
    }

    // Função para ativar ou desativar o painelClasse e definir a classe do jogador como Classe2
    public void PainelClasse2()
    {
        // Se o painelClasse não estiver ativo na hierarquia
        if (!painelClasse.activeInHierarchy)
        {
            // O painelClasse será ativado
            painelClasse.SetActive(true);
        }
        else // Se o painelClasse estiver ativo na hierarquia
        {
            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe2
            classe2.DefinirClasse();

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            classe2.PegarInfo();
        }
    }

    // Função para ativar ou desativar o painelClasse e definir a classe do jogador como Classe3
    public void PainelClasse3()
    {
        // Se o painelClasse não estiver ativo na hierarquia
        if (!painelClasse.activeInHierarchy)
        {
            // O painelClasse será ativado
            painelClasse.SetActive(true);
        }
        else // Se o painelClasse estiver ativo na hierarquia
        {
            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe3
            classe3.DefinirClasse();

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            classe3.PegarInfo();
        }
    }

    public void PainelNome()
    {
        // Se o painelNome não estiver ativo na hierarquia
        if (!painelNome.activeInHierarchy)
        {
            // O painelNome será ativado
            painelNome.SetActive(true);
        }
        else // Se o painelNome estiver ativo na hierarquia
        {
            // Ativa a função BotaoConfirmar
            BotaoConfirmar();
            // O painelNome será desativado
            painelNome.SetActive(false);
        }
    }

    // Função que aloca o que foi escrito no inputField na variável nomeJogador, e passa esse nome para a interface do jogo
    public void BotaoConfirmar()
    {
        // Variável recebe texto escrito no inputField
        nomeJogador = inputField.GetComponent<Text>().text;
        // Esse mesmo texto é definido na interface do jogador como seu nome
        displayNomeJogador.GetComponent<Text>().text = nomeJogador;
    }
}
