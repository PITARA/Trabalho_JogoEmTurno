using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    #region Variáveis

    [SerializeField]
    private GameObject painelJogar, painelClasse, painelNome, painelVitoria, inputField, displayNomeJogador, displayClasseJogador, displayVidaJogador,
     displayVidaNPC, displayIndiceNPC, batalha, botaoTentarNovamente;

    public GameObject painelDerrota;

    [SerializeField] private Button botaoAtacar, botaoDefender, botaoHab1, botaoHab2;

    [SerializeField] private RawImage imagemClasseEscolhida, imagemClasseAlcooGel, imagemClasseSabao, imagemClasseMascara;

    public Material materialNPC, materialDetalhesNPC;

    public string nomeJogador, classeJogador;
    private int vidaJogador, vidaNPC, indiceNPC;

    private Color corPadraoBotoes = new Color(66, 214, 255);
    
    #endregion

    private void Awake()
    {
        // Garante que os painéis estão ativos no início do programa
        painelJogar.SetActive(true);
        painelClasse.SetActive(true);
        painelNome.SetActive(true);
        painelDerrota.SetActive(false);
        painelVitoria.SetActive(false);
    }

    private void Update()
    {
        // Se o jogador tiver sido gerado
        if (Batalha.jogador != null)
        {
            // Atualizar a interface com as vidas atuais
            AtualizarInfoUI();
        }

        // Muda as cores dos botões para mostrar que eles não podem ser clicados
        if (batalha.GetComponent<Batalha>().turno == false)
        {
            botaoAtacar.GetComponent<Image>().color = Color.gray;
            botaoDefender.GetComponent<Image>().color = Color.gray;
            botaoHab1.GetComponent<Image>().color = Color.gray;
            botaoHab2.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            botaoAtacar.GetComponent<Image>().color = corPadraoBotoes;
            botaoDefender.GetComponent<Image>().color = corPadraoBotoes;
            botaoHab1.GetComponent<Image>().color = corPadraoBotoes;
            botaoHab2.GetComponent<Image>().color = corPadraoBotoes;
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
            Batalha.jogador = new Classe1();

            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe1
            Batalha.jogador.DefinirClasse();
            // Nome da classe do jogador é alocado em variável que será usada pela interface
            classeJogador = Batalha.jogador.NomeClasse;

            // Imagem da classe escolhida pelo player é definida na interface
            imagemClasseEscolhida.texture = imagemClasseAlcooGel.texture;
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
            Batalha.jogador = new Classe2();

            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe2
            Batalha.jogador.DefinirClasse();
            // Nome da classe do jogador é alocado em variável que será usada pela interface
            classeJogador = Batalha.jogador.NomeClasse;

            // Imagem da classe escolhida pelo player é definida na interface
            imagemClasseEscolhida.texture = imagemClasseSabao.texture;
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
            Batalha.jogador = new Classe3();

            // O painelClasse será desativado
            painelClasse.SetActive(false);
            // A classe do jogador será definida como Classe3
            Batalha.jogador.DefinirClasse();
            // Nome da classe do jogador é alocado em variável que será usada pela interface
            classeJogador = Batalha.jogador.NomeClasse;

            // Imagem da classe escolhida pelo player é definida na interface
            imagemClasseEscolhida.texture = imagemClasseMascara.texture;
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
        Batalha.jogador.Vida = Batalha.jogador.VidaInicial;
        painelDerrota.SetActive(false);
        batalha.GetComponent<Batalha>().logEventos.SetActive(true);
    }

    // Função que atualiza a UI com as informações de vida e nome do NPC
    public void AtualizarInfoUI()
    {
        // Variável recebe a quantidade de vida do jogador
        vidaJogador = Batalha.jogador.Vida;
        // Associada a variável de vida do jogador com a interface
        displayVidaJogador.GetComponent<Text>().text = vidaJogador.ToString();
        // Variável recebe a quantidade de vida do NPC
        vidaNPC = Batalha.npc.Vida;
        // Associada a variável de vida do NPC com a interface
        displayVidaNPC.GetComponent<Text>().text = vidaNPC.ToString();
        // Variável recebe índice do NPC
        indiceNPC = Batalha.npc.IndiceNPC;
        // Associada o índice do NPC com a interface
        displayIndiceNPC.GetComponent<Text>().text = indiceNPC.ToString();
    }

    // Função que ativa a tela de vitória
    public void AtivarTelaVitoria()
    {
        painelVitoria.SetActive(true);
        batalha.GetComponent<Batalha>().logEventos.SetActive(false);
    }

    // Função que ativa a tela de derrota
    public void AtivarTelaDerrota()
    {
        // Se o jogador ainda tiver tentativas restando
        if (Batalha.jogador.TentativasJogador > 0)
        {
            painelDerrota.SetActive(true);
            batalha.GetComponent<Batalha>().logEventos.SetActive(false);
        }

        // Se o jogador não tiver mais tentativas
        if(Batalha.jogador.TentativasJogador == 0)
        {
            painelDerrota.SetActive(true);
            botaoTentarNovamente.SetActive(false);
            batalha.GetComponent<Batalha>().logEventos.SetActive(false);
        }
    }

    public void DefinirCorNPC()
    {
        // Pega uma cor aleatória para o NPC
        Color novaCor = new Color(Random.value, Random.value, Random.value, 1.0f);
        // Define o NPC com cor nova
        materialNPC.color = novaCor;

        // Pega uma cor aleatória para os detalhes do NPC
        Color novaCorDetalhes = new Color(Random.value, Random.value, Random.value, 1.0f);
        
        // Enquanto a cor do NPC for igual a cor dos detalhes dele
        while (novaCor == novaCorDetalhes)
        {
            // Uma nova cor será escolhida
            novaCorDetalhes = new Color(Random.value, Random.value, Random.value, 1.0f);           
        }

        // Define os detalhes do NPC com a cor nova
        materialDetalhesNPC.color = novaCorDetalhes;
    }

    private void OnEnable()
    {
        Batalha.NaVitoria += AtivarTelaVitoria;
        Batalha.NaDerrota += AtivarTelaDerrota;
    }

    private void OnDisable()
    {
        Batalha.NaVitoria -= AtivarTelaVitoria;
        Batalha.NaDerrota -= AtivarTelaDerrota;
    }
}
