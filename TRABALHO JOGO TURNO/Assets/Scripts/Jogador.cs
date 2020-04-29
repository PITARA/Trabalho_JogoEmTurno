﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jogador
{
    #region Variáveis

    public string NomeClasse { get; set; }
    public int Vida{ get; set; }
    public int Ataque { get; set; }
    public int Defesa { get; set; }
    public int IndiceHabilidadeCura { get; set; }
    public int IndiceHabilidadeAtaque { get; set; }
<<<<<<< HEAD

=======
    public int CuraMaxima { get; set; }
>>>>>>> DevWill
    #endregion

    // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
    public void PegarInfo()
<<<<<<< HEAD
    {
        Debug.Log("A classe escolhida foi " + NomeClasse);
        Debug.Log("Vida: " + Vida);
        Debug.Log("Ataque: " + Ataque);
        Debug.Log("Defesa: " + Defesa);
        Debug.Log("Indice de Habilidade de Cura: " + IndiceHabilidadeCura);
        Debug.Log("Indice de Habilidade de Ataque: " + IndiceHabilidadeAtaque);
    }

    // Função abstrata que define atributos de classe
    public abstract void DefinirClasse();
}

public class Classe1 : Jogador
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe1
    public override void DefinirClasse()
    {
        NomeClasse = "Classe1";
        Vida = 50;
        Ataque = 1;
        Defesa = 1;
        IndiceHabilidadeCura = 1;
        IndiceHabilidadeAtaque = 1;
    }
}

public class Classe2 : Jogador
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe2
    public override void DefinirClasse()
    {
        NomeClasse = "Classe2";
        Vida = 70;
        Ataque = 2;
        Defesa = 2;
        IndiceHabilidadeCura = 2;
        IndiceHabilidadeAtaque = 2;
=======
    {
        Debug.Log("A classe escolhida foi " + NomeClasse);
        Debug.Log("Vida: " + Vida);
        Debug.Log("Ataque: " + Ataque);
        Debug.Log("Defesa: " + Defesa);
        Debug.Log("Indice de Habilidade de Cura: " + IndiceHabilidadeCura);
        Debug.Log("Indice de Habilidade de Ataque: " + IndiceHabilidadeAtaque);
>>>>>>> DevWill
    }
}

<<<<<<< HEAD
=======
    // Função abstrata que define atributos de classe
    public abstract void DefinirClasse();
}

public class Classe1 : Jogador
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe1
    public override void DefinirClasse()
    {
        NomeClasse = "Classe1";
        Vida = 50;
        Ataque = 1;
        Defesa = 1;
        CuraMaxima = 50;
        IndiceHabilidadeCura = 1;
        IndiceHabilidadeAtaque = 1;
    }
}

public class Classe2 : Jogador
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe2
    public override void DefinirClasse()
    {
        NomeClasse = "Classe2";
        Vida = 70;
        Ataque = 2;
        Defesa = 2;
        CuraMaxima = 70;
        IndiceHabilidadeCura = 2;
        IndiceHabilidadeAtaque = 2;
    }
}

>>>>>>> DevWill
public class Classe3 : Jogador
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe3
    public override void DefinirClasse()
    {
        NomeClasse = "Classe3";
        Vida = 100;
        Ataque = 3;
        Defesa = 3;
<<<<<<< HEAD
=======
        CuraMaxima = 100;
>>>>>>> DevWill
        IndiceHabilidadeCura = 3;
        IndiceHabilidadeAtaque = 3;
    }
}
