using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variáveis

    public static Jogador jogador;
    public static NPC npc = new NPC();

    private Batalha batalha = new Batalha();
    private GeradorNumerico geradorNumerico = new GeradorNumerico();
    private int vidaNPC;
    private bool turno;
    private float tempo;
    private int jogadorVida;
    
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
        // atualiza a variável de vida do npc usada nas funções
        vidaNPC = npc.Vida;
        // verificação para criação da variável vida
        if (jogador != null)
        {
            // atribui o valor de vida do jogador
            jogadorVida = jogador.Vida;
        }
        
    }

    // Função do botão 'ATACAR'
    public void JogadorAtacar()
    {
        int indiceAtaqueJogador;        

        // O jogador só ataca se a vida do NPC for maior que zero
        if (vidaNPC > 0 && turno == true)
        {
            // Jogador usa o resultado de um dado + o ataque base dele para contabilizar o ataque da rodada
            indiceAtaqueJogador = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.Ataque);

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            Debug.Log("Ataque do jogador é de: " + geradorNumerico.GerarNumeroAleatorio(1, 6) + " | Ataque base: " + jogador.Ataque + " | A defesa do inimigo é de: " + npc.Defesa);

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

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            Debug.Log("Jogador atacou por: " + indiceAtaqueJogador + " | Inimigo tinha " + vidaNPC + " de vida, e ficou com " + npc.Vida);
        }
    }
    
    // Função do botão Defender
    public void JogadorDefender()
    {
        
    }

    // Função do botão Hab.1
    public void JogadorHab1()
    {
        int indiceCuraJogador;

        // O jogador só se cura se a vida do NPC for maior que zero e for o turno do jogador
        if (vidaNPC > 0 && turno == true)
        {
            // Jogador usa o resultado de um dado + a cura base dele para contabilizar o efeito de cura
            indiceCuraJogador = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.IndiceHabilidadeCura) * jogador.IndiceHabilidadeCura;
            jogador.Vida += indiceCuraJogador;
            StartCoroutine("TempoTurno");

        }

    }
    // Função do botão Hab.2
    public void JogadorHab2()
    {
        int indiceAtaqueJogador;       

        int multiplicadorAtq = jogador.IndiceHabilidadeAtaque;

        // O jogador só ataca se a vida do NPC for maior que zero
        if (vidaNPC > 0 && turno == true)
        {
            // Jogador usa o resultado de um dado + o ataque base dele para contabilizar o ataque da rodada
            indiceAtaqueJogador = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.Ataque) * multiplicadorAtq;

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            Debug.Log("Ataque do jogador é de: " + geradorNumerico.GerarNumeroAleatorio(1, 6) + " | Ataque base: " + jogador.Ataque + " | o multiplicador é  " + multiplicadorAtq + "| A defesa do inimigo é de: " + npc.Defesa);

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

            // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
            Debug.Log("Jogador atacou por: " + indiceAtaqueJogador + " | Inimigo tinha " + vidaNPC + " de vida, e ficou com " + npc.Vida);
        }
    }
    
    // Função de ataque de NPC
    public void AtaqueNPC()
    {
        if (jogadorVida > 0)
        {
                int indiceAtaqueNPC;

                indiceAtaqueNPC = batalha.Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), npc.Ataque);
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
        
    }

    // Coroutina do tempo do turno
    IEnumerator TempoTurno()
    {
        turno = false;
        Debug.Log("turno " + turno);
        // espera o tempo estipulado para atacar
        yield return new WaitForSeconds(tempo);
        //começa o ataque do NPC
        AtaqueNPC();

        // espera o tempo estipulado para trocar a condição do turno
        yield return new WaitForSeconds(tempo);

        // condição para mudar o turno
        if (jogadorVida > 0 && vidaNPC > 0)
        {
            // muda o turno para true
            turno = true;
        }
        Debug.Log("turno " + turno);
    }
}
