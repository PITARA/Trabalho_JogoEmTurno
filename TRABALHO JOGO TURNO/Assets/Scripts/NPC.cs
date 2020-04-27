using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC 
{
    #region Variáveis

    private GeradorNumerico geradorNumerico = new GeradorNumerico();

    public int Vida { get; set; }
    public int Ataque { get; set; }
    public int Defesa { get; set; }

    #endregion

    // Função para gerar um NPC com atributos aleatórios dentro de um alcance específico
    public void GerarNPC()
    {
        Vida = geradorNumerico.GerarNumeroAleatorio(50, 100);
        Ataque = geradorNumerico.GerarNumeroAleatorio(1, 3);
        Defesa = geradorNumerico.GerarNumeroAleatorio(1, 3);
    }

}
