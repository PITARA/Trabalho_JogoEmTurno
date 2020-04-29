using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    #region Variáveis

    [SerializeField] private GameObject m_interface;

    public static Jogador jogador;
    public static NPC npc = new NPC();
    public static event Action NaVitoria;
    public static event Action NaDerrota;

    private Batalha batalha = new Batalha();
    private GeradorNumerico geradorNumerico = new GeradorNumerico();
    private int vidaNPC;
    private int jogadorVida;
    private int curaMaxima;
    private float tempo;
    public bool turno;
    private bool ativarDefesa;
    private bool fimDeJogo = false;

    #endregion

    private void Awake()
    {
        // Gera um inimigo no início do jogo para teste * VAI MUDAR DE LUGAR DEPOIS *
        npc.GerarNPC();        
    }

    private void Start()
    {
       // variável que limita o turno
        turno = true;
        // tempo do turno
        tempo = 2.0f;
    }

    private void Update()
    {
        if (jogador != null)
        {
            if (!fimDeJogo)
            {
                StartCoroutine("CicloDeJogo");
            }
        }
    }

    // Função do botão 'ATACAR'
    public void JogadorAtacar()
    {
        int indiceAtaqueJogador;
        vidaNPC = npc.Vida;

        // O jogador só ataca se a vida do NPC for maior que zero
        if (vidaNPC > 0 && turno == true)
        {
            // Jogador usa o resultado de um dado + o ataque base dele para contabilizar o ataque da rodada
            indiceAtaqueJogador = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.Ataque);

            // O ataque da rodada é diminuido pela defesa base do NPC   
            indiceAtaqueJogador = indiceAtaqueJogador - npc.Defesa;

            // Se o resultado do indice de ataque do jogador for negativo
            if (indiceAtaqueJogador < 0)
            {
                // O indice do ataque do jogador zera
                indiceAtaqueJogador = 0;
                
                // começa o turno do NPC
                StartCoroutine("TempoTurno");
            }

            // Se a vida do NPC for maior ou igual ao indice de ataque do jogador
            if (vidaNPC >= indiceAtaqueJogador)
            {
                // A vida do NPC é removida com base no resultado de ataque do jogador
                npc.Vida -= indiceAtaqueJogador;
                
                // começa o turno do NPC
                StartCoroutine("TempoTurno");
            }
            
            // Se o resultado da vida do NPC ficar menor ou igual a zero
            else
            {
                // A vida do NPC é setada para 0
                npc.Vida = 0;                
            }
        }
    }

    // Função do botão Defender
    public void JogadorDefender()
    {   
        // recebe o valor de vida e guarda no NPC
        vidaNPC = npc.Vida;
        
        // Condição para uso de habilidade de defesa
        if (vidaNPC > 0 && turno == true)
        {
            // ativa a condição de defesa e permite que o NPC entenda a condição
            ativarDefesa = true;
            // começa o turno do NPC
            StartCoroutine("TempoTurno");            
        }
       
    }

    // Função do botão Hab.1
    public void JogadorHab1()
    {
        int indiceCuraJogador;
        int cura;
        jogadorVida = jogador.Vida;
        vidaNPC = npc.Vida;
        curaMaxima = jogador.VidaInicial;
        

        // O jogador só se cura se a vida do NPC for maior que zero e for o turno do jogador
        if (vidaNPC > 0 && turno == true)
        {
            Debug.Log("A vida é " + curaMaxima);
            // Jogador usa o resultado de um dado + a cura base dele para contabilizar o efeito de cura
            indiceCuraJogador = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.IndiceHabilidadeCura) * jogador.IndiceHabilidadeCura;
            Debug.Log("indice de cura é " + indiceCuraJogador);
            // calcúlo para cura
            cura = jogadorVida + indiceCuraJogador;
            Debug.Log("o valor de cura é " + cura);

            //condição para a cura acontecer e não execeder o limite de vida do jogador
            if(cura >= curaMaxima)
            {
                jogador.Vida = curaMaxima;
                Debug.Log("a vida é " + jogador.Vida);
                StartCoroutine("TempoTurno");
            }
            //se não execedeu então a cura vai ser realizada com base no resultado do indicador
            else
            {
                jogador.Vida += indiceCuraJogador;
                Debug.Log("else vida é " + jogador.Vida);
                StartCoroutine("TempoTurno");
            }           
        }
    }

    // Função do botão Hab.2
    public void JogadorHab2()
    {
        int indiceAtaqueJogador;       

        int multiplicadorAtq = jogador.IndiceHabilidadeAtaque;

        vidaNPC = npc.Vida;

        // O jogador só ataca se a vida do NPC for maior que zero
        if (vidaNPC > 0 && turno == true)
        {
            // Jogador usa o resultado de um dado + o ataque base dele para contabilizar o ataque da rodada
            indiceAtaqueJogador = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.Ataque) * multiplicadorAtq;
            
            // O ataque da rodada é diminuido pela defesa base do NPC   
            indiceAtaqueJogador = indiceAtaqueJogador - npc.Defesa;

            // Se o resultado do indice de ataque do jogador for negativo
            if (indiceAtaqueJogador < 0)
            {
                // O indice do ataque do jogador zera
                indiceAtaqueJogador = 0;

                // começa o turno do NPC
                StartCoroutine("TempoTurno");
            }

            // Se a vida do NPC for maior ou igual ao indice de ataque do jogador
            if (vidaNPC >= indiceAtaqueJogador)
            {
                // A vida do NPC é removida com base no resultado de ataque do jogador
                npc.Vida -= indiceAtaqueJogador;

                // começa o turno do NPC
                StartCoroutine("TempoTurno");
            }
            // Se o resultado da vida do NPC ficar menor ou igual a zero
            else
            {
                // A vida do NPC é setada para 0
                npc.Vida = 0;

            }
        }
    }

    // Função de ataque de NPC
    public void AtaqueNPC()
    {   
        // variavel que armazena o valo de defesa
        int indiceDefJogador;

        // variavel para calculo de ataque do NPC
        int indiceAtaqueNPC;

        // jogador recebe valores de vida
        jogadorVida = jogador.Vida;

        // calculo de defesa de 1 dado + a base da defesa * o base de defesa 
        indiceDefJogador = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.Defesa) * jogador.Defesa;

        // calculo de ataque do NPC
        indiceAtaqueNPC = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), npc.Ataque);

        // condição que determina que quando o ataque pode acontecer
        if (jogadorVida > 0 && ativarDefesa == true)
        {
            //jogador recebe a defesa que é a soma da defesa + o calculo das variaves de defesa
            jogador.Defesa = jogador.Defesa + indiceDefJogador;           

            // O ataque da rodada é diminuido pela defesa base do Jogador   
            indiceAtaqueNPC = indiceAtaqueNPC - jogador.Defesa;

            // variavel perde o bonus de defesa e normaliza a defesa do jogador
            jogador.Defesa = jogador.Defesa - indiceDefJogador;
           

            // Se o resultado do indice de ataque do NPC for negativo
            if (indiceAtaqueNPC < 0)
            {
                // O indice do ataque do NPC zera
                indiceAtaqueNPC = 0;
            }

            // Se a vida do Jogador for maior ou igual ao indice de ataque do NPC
            if (jogadorVida >= indiceAtaqueNPC)
            {
                // A vida do Jogador é removida com base no resultado de ataque do NPC
                jogador.Vida -= indiceAtaqueNPC;
            }

            else
            {
                // A vida do Jogador é setada para 0
                jogador.Vida = 0;
                turno = false;
            }                                
        }

        if (jogadorVida > 0 && ativarDefesa == false)
        {           
            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            Debug.Log("Ataque do inimigo é de: " + geradorNumerico.GerarNumeroAleatorio(1, 6) + " | Ataque base: " + npc.Ataque + " | A defesa do jogador é de: " + jogador.Defesa);

            // O ataque da rodada é diminuido pela defesa base do Jogador   
            indiceAtaqueNPC = indiceAtaqueNPC - jogador.Defesa;

            // Se o resultado do indice de ataque do NPC for negativo
            if (indiceAtaqueNPC < 0)
            {
            // O indice do ataque do NPC zera
            indiceAtaqueNPC = 0;
            }

            // Se a vida do Jogador for maior ou igual ao indice de ataque do NPC
            if (jogadorVida >= indiceAtaqueNPC)
            {
            // A vida do Jogador é removida com base no resultado de ataque do NPC
            jogador.Vida -= indiceAtaqueNPC;
            }

            else
            {
            // A vida do Jogador é setada para 0
            jogador.Vida = 0;
            turno = false;
            }

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            Debug.Log("Inimigo atacou por: " + indiceAtaqueNPC + " | Jogador tinha " + jogadorVida + " de vida, e ficou com " + jogador.Vida);
        }

        //muda o valor de ativar defesa e permite que o jogador use a habilidade novamente
        ativarDefesa = false;
    }

    // Coroutina do tempo do turno
    IEnumerator TempoTurno()
    {
        turno = false;
        Debug.Log("inicio da coroutina e turno do NPC " + turno);

        // espera o tempo estipulado para atacar
        yield return new WaitForSeconds(tempo);

        //começa o ataque do NPC                   
        AtaqueNPC();
      
        // espera o tempo estipulado para trocar a condição do turno
        yield return new WaitForSeconds(tempo);

        // condição para mudar o turno
        if (jogadorVida > 0 && vidaNPC > 0)
        {
            turno = true;                        
        }
        Debug.Log("fim da coroutina e inicio do turno do jogador " + turno);
    }

    // Corotina que controla o ciclo de jogo, gerando mais inimigos e ativando a ação de fim de jogo 
    IEnumerator CicloDeJogo()
    {
        if (!fimDeJogo)
        {
            // Se o NPC morreu e ainda faltam inimigos na lista
            if (npc.Vida == 0 && npc.IndiceNPC < 5)
            {
                // Outro inimigo é gerado
                npc.GerarNPC();
            }

            // Se o jogador morreu e ainda restam tentativas
            if(jogador.Vida == 0 && jogador.TentativasJogador > 0)
            {
                // Se a interface de derrota não estiver ativa
                if (!m_interface.GetComponent<Interface>().painelDerrota.activeInHierarchy)
                {
                    // Uma tentativa do jogador é tirada
                    jogador.DiminuirTentativasJogador();
                    // Ação de derrota é iniciada
                    NaDerrota.Invoke();

                    yield return new WaitForSeconds(tempo);
                }
            }
        }

        // Se o último NPC morreu
        if(npc.Vida == 0 && npc.IndiceNPC == 5)
        {
            fimDeJogo = true;
            yield return new WaitForSeconds(tempo);
            NaVitoria.Invoke();
            Debug.Log("VITORIA");
        }

        // Se o jogador morreu e não há mais tentativas
        if(jogador.Vida == 0 && jogador.TentativasJogador == 0)
        {
            fimDeJogo = true;
            NaDerrota.Invoke();
            Debug.Log("DERROTA");
        }
    }
}
