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

    #endregion

    private void Awake()
    {
        // Gera um inimigo no início do jogo para teste * VAI MUDAR DE LUGAR DEPOIS *
        npc.GerarNPC();
    }

    // Função do botão 'ATACAR'
    public void JogadorAtacar()
    {
        int indiceAtaqueJogador;
        int vidaNPC;

        vidaNPC = npc.Vida;

        // O jogador só ataca se a vida do NPC for maior que zero
        if (vidaNPC > 0)
        {
            // Jogador usa o resultado de um dade + o ataque base dele para contabilizar o ataque da rodada
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
            }

            // Se a vida do NPC for maior ou igual ao indice de ataque do jogador
            if (vidaNPC >= indiceAtaqueJogador)
            {
                // A vida do NPC é removida com base no resultado de ataque do jogador
                npc.Vida -= indiceAtaqueJogador;
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
}
