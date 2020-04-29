using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    #region Variáveis

    [SerializeField] private GameObject painelJogar, painelClasse, painelNome, painelVitoria, inputField, displayNomeJogador, displayClasseJogador, displayVidaJogador,
     displayVidaNPC, displayIndiceNPC, gameManager, botaoTentarNovamente;

    public GameObject painelDerrota;

    [SerializeField] private Button botaoAtacar, botaoDefender, botaoHab1, botaoHab2;

    public string nomeJogador, classeJogador;
    private int vidaJogador, vidaNPC, indiceNPC;

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
            AtualizarInfoUI();
        }

        // Muda as cores dos botões para mostrar que eles não podem ser clicados
        if (gameManager.GetComponent<GameManager>().turno == false)
        {
            botaoAtacar.GetComponent<Image>().color = Color.gray;
            botaoDefender.GetComponent<Image>().color = Color.gray;
            botaoHab1.GetComponent<Image>().color = Color.gray;
            botaoHab2.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            botaoAtacar.GetComponent<Image>().color = Color.white;
            botaoDefender.GetComponent<Image>().color = Color.white;
            botaoHab1.GetComponent<Image>().color = Color.white;
            botaoHab2.GetComponent<Image>().color = Color.white;
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

    // Função para resetar a vida do jogador e desativar o painel de derrota por um botão
    public void BotaoTentarNovamente()
    {
        GameManager.jogador.Vida = GameManager.jogador.VidaInicial;
        painelDerrota.SetActive(false);
    }

    // Função que atualiza a UI com as informações de vida e nome do NPC
    public void AtualizarInfoUI()
    {
        // Variável recebe a quantidade de vida do jogador
        vidaJogador = GameManager.jogador.Vida;
        // Associada a variável de vida do jogador com a interface
        displayVidaJogador.GetComponent<Text>().text = vidaJogador.ToString();
        // Variável recebe a quantidade de vida do NPC
        vidaNPC = GameManager.npc.Vida;
        // Associada a variável de vida do NPC com a interface
        displayVidaNPC.GetComponent<Text>().text = vidaNPC.ToString();
        // Variável recebe índice do NPC
        indiceNPC = GameManager.npc.IndiceNPC;
        // Associada o índice do NPC com a interface
        displayIndiceNPC.GetComponent<Text>().text = indiceNPC.ToString();
    }

    // Função que ativa a tela de vitória
    public void AtivarTelaVitoria()
    {
        painelVitoria.SetActive(true);
    }

    // Função que ativa a tela de derrota
    public void AtivarTelaDerrota()
    {
        // Se o jogador ainda tiver tentativas restando
        if (GameManager.jogador.TentativasJogador > 0)
        {
            painelDerrota.SetActive(true);
        }

        // Se o jogador não tiver mais tentativas
        if(GameManager.jogador.TentativasJogador == 0)
        {
            painelDerrota.SetActive(true);
            botaoTentarNovamente.SetActive(false);
        }
    }

    private void OnEnable()
    {
        GameManager.NaVitoria += AtivarTelaVitoria;
        GameManager.NaDerrota += AtivarTelaDerrota;
    }

    private void OnDisable()
    {
        GameManager.NaVitoria -= AtivarTelaVitoria;
        GameManager.NaDerrota -= AtivarTelaDerrota;
    }
}
