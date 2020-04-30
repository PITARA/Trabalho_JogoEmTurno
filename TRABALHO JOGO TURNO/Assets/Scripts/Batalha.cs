using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Batalha : MonoBehaviour
{
    #region Variáveis

    [SerializeField] private GameObject m_interface;

    public static Jogador jogador;
    public static NPC npc = new NPC();
    public static event Action NaVitoria;
    public static event Action NaDerrota;
    
    private GeradorNumerico geradorNumerico = new GeradorNumerico();
    private int vidaNPC;
    private int jogadorVida;
    private int curaMaxima;
    private float tempo;
    public bool turno;
    private bool ativarDefesa;
    private bool fimDeJogo = false;

    public GameObject logEventos;

    #endregion

    private void Awake()
    {
        // Gera um inimigo no início do jogo para teste * VAI MUDAR DE LUGAR DEPOIS *
        npc.GerarNPC();
        m_interface.GetComponent<Interface>().DefinirCorNPC();
        
    }

    private void Start()
    {
       // variável que limita o turno
        turno = true;
        // tempo do turno
        tempo = 2.0f;

        // Garante que o jogo abre na resolução correta e em modo janela
        int width = 1024; 
        int height = 768; 
        bool isFullScreen = false; 
        int desiredFPS = 60; 

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
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

        // *REMOVER DEPOIS, APENAS PARA TESTE DE MUDANÇA DE COR*
        if (Input.GetKeyDown("space"))
        {
            m_interface.GetComponent<Interface>().DefinirCorNPC();
            
        }
    }

    // Função genérica que retorna o índice de ataque final
    public int Atacar(int ataqueRoll, int indiceModificador)
    {
        // O índice de ataque final é o roll de ataque + o índice modificador de ataque de quem está atacando
        int resultadoAtaque = ataqueRoll + indiceModificador;
        // O resultado final de ataque é retornado
        return resultadoAtaque;
    }

    // Função do botão 'ATACAR'
    public void JogadorAtacar()
    {
        // Mantem o botão no estado 'não selecionado'
        EventSystem.current.SetSelectedGameObject(null);

        int indiceAtaqueJogador;
        vidaNPC = npc.Vida;

        // O jogador só ataca se a vida do NPC for maior que zero
        if (vidaNPC > 0 && turno == true)
        {
            // Jogador usa o resultado de um dado + o ataque base dele para contabilizar o ataque da rodada
            indiceAtaqueJogador = Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.Ataque);

            // O ataque da rodada é diminuido pela defesa base do NPC   
            indiceAtaqueJogador = indiceAtaqueJogador - npc.Defesa;

            // Se o resultado do indice de ataque do jogador for negativo
            if (indiceAtaqueJogador <= 0)
            {
                // O indice do ataque do jogador zera
                indiceAtaqueJogador = 0;
            }

            // Se a vida do NPC for maior ou igual ao indice de ataque do jogador
            if (vidaNPC >= indiceAtaqueJogador)
            {
                // A vida do NPC é removida com base no resultado de ataque do jogador
                npc.Vida -= indiceAtaqueJogador;
                // mostra o dano do jogador
                logEventos.GetComponent<LogEventos>().NovoEventoLog("Seu dano é: " + indiceAtaqueJogador);
                // começa o turno do NPC
                StartCoroutine("TempoTurno");
            }
            
            // Se o resultado da vida do NPC ficar menor ou igual a zero
            else
            {
                // mostra o dano do jogador
                logEventos.GetComponent<LogEventos>().NovoEventoLog("Seu dano é: " + indiceAtaqueJogador);
                // A vida do NPC é setada para 0
                npc.Vida = 0;                
            }
        }
    }

    // Função do botão Defender
    public void JogadorDefender()
    {
        // Mantem o botão no estado 'não selecionado'
        EventSystem.current.SetSelectedGameObject(null);

        // recebe o valor de vida e guarda no NPC
        vidaNPC = npc.Vida;
        
        // Condição para uso de habilidade de defesa
        if (vidaNPC > 0 && turno == true)
        {
            // ativa a condição de defesa e permite que o NPC entenda a condição
            ativarDefesa = true;

            logEventos.GetComponent<LogEventos>().NovoEventoLog("Você usou defesa" );
            // começa o turno do NPC
            StartCoroutine("TempoTurno");            
        }
       
    }

    // Função do botão Hab.1
    public void JogadorHab1()
    {
        // Mantem o botão no estado 'não selecionado'
        EventSystem.current.SetSelectedGameObject(null);

        int indiceCuraJogador;
        int cura;
        jogadorVida = jogador.Vida;
        vidaNPC = npc.Vida;
        curaMaxima = jogador.VidaInicial;        

        // O jogador só se cura se a vida do NPC for maior que zero e for o turno do jogador
        if (vidaNPC > 0 && turno == true)
        {            
            // Jogador usa o resultado de um dado + a cura base dele para contabilizar o efeito de cura
            indiceCuraJogador = Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.IndiceHabilidadeCura) * jogador.IndiceHabilidadeCura;
           
            // calcúlo para cura
            cura = jogadorVida + indiceCuraJogador;            
            
            // condição para a cura acontecer e não execeder o limite de vida do jogador
            if(cura >= curaMaxima)
            {
                jogador.Vida = curaMaxima;
                
                //mostra a quantidade de cura do jogador
                logEventos.GetComponent<LogEventos>().NovoEventoLog("Você curou: " + indiceCuraJogador);
                
                // começa o turno do NPC
                StartCoroutine("TempoTurno");
            }
            // se não execedeu então a cura vai ser realizada com base no resultado do indicador
            else
            {
                jogador.Vida += indiceCuraJogador;

                // mostra a quantidade de cura do jogador
                logEventos.GetComponent<LogEventos>().NovoEventoLog("Você curou: " + indiceCuraJogador);
                
                // começa o turno do NPC
                StartCoroutine("TempoTurno");
            }           
        }
    }

    // Função do botão Hab.2
    public void JogadorHab2()
    {
        // Mantem o botão no estado 'não selecionado'
        EventSystem.current.SetSelectedGameObject(null);

        int indiceAtaqueJogador;       

        int multiplicadorAtq = jogador.IndiceHabilidadeAtaque;

        vidaNPC = npc.Vida;

        // O jogador só ataca se a vida do NPC for maior que zero
        if (vidaNPC > 0 && turno == true)
        {
            // Jogador usa o resultado de um dado + o ataque base dele para contabilizar o ataque da rodada
            indiceAtaqueJogador = Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.Ataque) * multiplicadorAtq;
            
            // O ataque da rodada é diminuido pela defesa base do NPC   
            indiceAtaqueJogador = indiceAtaqueJogador - npc.Defesa;

            // Se o resultado do indice de ataque do jogador for negativo
            if (indiceAtaqueJogador <= 0)
            {
                // O indice do ataque do jogador zera
                indiceAtaqueJogador = 0;
            }

            // Se a vida do NPC for maior ou igual ao indice de ataque do jogador
            if (vidaNPC >= indiceAtaqueJogador)
            {
                // A vida do NPC é removida com base no resultado de ataque do jogador
                npc.Vida -= indiceAtaqueJogador;

                // mostra o dano da habilidade do jogador
                logEventos.GetComponent<LogEventos>().NovoEventoLog("O dano de sua Habilidade é: " + indiceAtaqueJogador);

                // começa o turno do NPC
                StartCoroutine("TempoTurno");
            }

            // Se o resultado da vida do NPC ficar menor ou igual a zero
            else
            {
                // mostra o dano da habilidade do jogador
                logEventos.GetComponent<LogEventos>().NovoEventoLog("O dano de sua Habilidade é: " + indiceAtaqueJogador);

                // A vida do NPC é setada para 0
                npc.Vida = 0;

            }
        }
    }

    // Função de ataque de NPC
    public void AtaqueNPC()
    {
        // Mantem o botão no estado 'não selecionado'
        EventSystem.current.SetSelectedGameObject(null);

        // variavel que armazena o valor de defesa
        int indiceDefJogador;

        // variavel para calculo de ataque do NPC
        int indiceAtaqueNPC;

        // jogador recebe valores de vida
        jogadorVida = jogador.Vida;

        // calculo de defesa de 1 dado + a base da defesa * o base de defesa 
        indiceDefJogador = Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), jogador.Defesa) * jogador.Defesa;

        // calculo de ataque do NPC
        indiceAtaqueNPC = Atacar(geradorNumerico.GerarNumeroAleatorio(1, 6), npc.Ataque);

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

                //mostra na tela o ataque do inimigo
                logEventos.GetComponent<LogEventos>().NovoEventoLog("Inimigo atacou: " + indiceAtaqueNPC);
            }

            else
            {
                logEventos.GetComponent<LogEventos>().NovoEventoLog("Inimigo atacou: " + indiceAtaqueNPC);
                // A vida do Jogador é setada para 0
                jogador.Vida = 0;
                turno = false;
            }                                
        }

        if (jogadorVida > 0 && ativarDefesa == false)
        {           
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

            //Mostra na tela o ataque do inimigo
            logEventos.GetComponent<LogEventos>().NovoEventoLog("Inimigo atacou: " + indiceAtaqueNPC);           
        }

        // muda o valor de ativar defesa e permite que o jogador use a habilidade novamente
        ativarDefesa = false;
    }

    // Coroutina do tempo do turno
    IEnumerator TempoTurno()
    {
        turno = false;

        if (vidaNPC > 0)
        {
            logEventos.GetComponent<LogEventos>().NovoEventoLog("Turno do Inimigo");
        }

        // espera o tempo estipulado para atacar
        yield return new WaitForSeconds(tempo);

        if (vidaNPC > 0)
        {        
            // começa o ataque do NPC                   
            AtaqueNPC();
        }
      
        // espera o tempo estipulado para trocar a condição do turno
        yield return new WaitForSeconds(tempo);

        // condição para mudar o turno
        if (jogadorVida > 0 && vidaNPC > 0)
        {
            turno = true;
            logEventos.GetComponent<LogEventos>().NovoEventoLog("Seu turno");
        }               
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
                // mensagem que avisa que novo inimigo foi gerado
                logEventos.GetComponent<LogEventos>().NovoEventoLog("Novo Inimigo apareceu!");
                // Outra cor é definida para o NPC
                m_interface.GetComponent<Interface>().DefinirCorNPC();
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
