﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jogador
{
    #region Variáveis

    public string NomeClasse;
    public int Vida;
    public int Ataque;
    public int Defesa;
    public int IndiceHabilidadeCura;
    public int IndiceHabilidadeAtaque;
    public int VidaInicial;
    public int TentativasJogador { get; protected set; }

    #endregion

    // Função abstrata que define atributos de classe
    public abstract void DefinirClasse();

    // Função para remover uma tentativa do jogador
    public void DiminuirTentativasJogador()
    {
        TentativasJogador -= 1;
    }

    public void DefinirVidaJogador(int vida)
    {
        Vida = vida;
    }
}

public class Classe1 : Jogador
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe1
    public override void DefinirClasse()
    {
        NomeClasse = "ÁLCOOL GEL";
        Vida = 70;
        Ataque = 2;
        Defesa = 2;
        VidaInicial = Vida;
        IndiceHabilidadeCura = 2;
        IndiceHabilidadeAtaque = 2;
        TentativasJogador = 3;
    }
}

public class Classe2 : Jogador
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe2
    public override void DefinirClasse()
    {
        NomeClasse = "SABÃO";
        Vida = 60;
        Ataque = 3;
        Defesa = 3;
        VidaInicial = Vida;
        IndiceHabilidadeCura = 2;
        IndiceHabilidadeAtaque = 2;
        TentativasJogador = 3;
    }
}

public class Classe3 : Jogador
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe3
    public override void DefinirClasse()
    {
        NomeClasse = "MÁSCARA";
        Vida = 50;
        Ataque = 1;
        Defesa = 1;
        VidaInicial = Vida;
        IndiceHabilidadeCura = 2;
        IndiceHabilidadeAtaque = 2;
        TentativasJogador = 3;
    }
}
