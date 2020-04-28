using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    #region Variáveis

    [SerializeField] private GameObject painelJogar, painelClasse, painelNome, inputField, displayNomeJogador, displayClasseJogador, displayVidaJogador, displayVidaNPC;

    public string nomeJogador, classeJogador;
    private int vidaJogador, vidaNPC;

    #endregion Variáveis

    private void Awake()
    {
        // Garante que os painéis estão ativos no início do programa
        painelJogar.SetActive(true);
        painelClasse.SetActive(true);
        painelNome.SetActive(true);
    }

    private void Update()
    {
        // Se o jogador tiver sido gerado
        if (GameManager.jogador != null)
        {
            // Atualizar a interface com as vidas atuais
            AtualizarVidasUI();
        }
    }

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
            GameManager.jogador = new Classe1();

            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe1
            GameManager.jogador.DefinirClasse();
            // Nome da classe do jogador é alocado em variável que será usada pela interface
            classeJogador = GameManager.jogador.NomeClasse;

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            GameManager.jogador.PegarInfo();
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
            GameManager.jogador = new Classe2();

            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe2
            GameManager.jogador.DefinirClasse();
            // Nome da classe do jogador é alocado em variável que será usada pela interface
            classeJogador = GameManager.jogador.NomeClasse;

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            GameManager.jogador.PegarInfo();
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
            GameManager.jogador = new Classe3();

            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe3
            GameManager.jogador.DefinirClasse();
            // Nome da classe do jogador é alocado em variável que será usada pela interface
            classeJogador = GameManager.jogador.NomeClasse;

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            GameManager.jogador.PegarInfo();
        }
    }

    // Função para ativar ou desativar o painelNome e chamar a função BotaoConfirmar
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
        }
    }

    // Função que aloca o que foi escrito no inputField na variável nomeJogador, e passa esse nome para a interface do jogo, junto com o nome da classe escolhida
    public void BotaoConfirmar()
    {
        // Variável recebe texto escrito no inputField
        nomeJogador = inputField.GetComponent<Text>().text;       
        // Esse mesmo texto é definido na interface do jogador como seu nome
        displayNomeJogador.GetComponent<Text>().text = nomeJogador;
        // Confirma se o valor de nomeJogador não é vazio
        if (nomeJogador.Length != 0)
        {
            // O painelNome será desativado
            painelNome.SetActive(false);
        }
        // Classe do jogador é definida na interface
        displayClasseJogador.GetComponent<Text>().text = classeJogador;
    }

    public void AtualizarVidasUI()
    {
        vidaJogador = GameManager.jogador.Vida;
        displayVidaJogador.GetComponent<Text>().text = vidaJogador.ToString();
        vidaNPC = GameManager.npc.Vida;
        displayVidaNPC.GetComponent<Text>().text = vidaNPC.ToString();
    }
}
