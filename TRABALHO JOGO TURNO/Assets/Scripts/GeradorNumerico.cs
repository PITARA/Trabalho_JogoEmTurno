using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeradorNumerico
{
    // Função pega um número aleatório num alcance de um número até outro
    public int GerarNumeroAleatorio(int min, int max)
    {
        System.Random aleatorio = new System.Random();
        // O resultado que será retornado será entre o número min e o número max
        return aleatorio.Next(min, max +1);
    }
}
