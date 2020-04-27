using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Classe
{
    #region Variáveis
    protected string NomeClasse { get; set; }
    protected int Vida{ get; set; }
    protected int Ataque { get; set; }
    protected int Defesa { get; set; }
    protected int IndiceHabilidadeCura { get; set; }
    protected int IndiceHabilidadeAtaque { get; set; }
    #endregion

    // ** INFORMAÇÃO NO CONSOLE PARA CONTROLE, REMOVER DEPOIS **
    public void PegarInfo()
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

public class Classe1 : Classe
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe1
    public override void DefinirClasse()
    {
        NomeClasse = "Classe1";
        Vida = 10;
        Ataque = 1;
        Defesa = 1;
        IndiceHabilidadeCura = 1;
        IndiceHabilidadeAtaque = 1;
    }
}

public class Classe2 : Classe
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe2
    public override void DefinirClasse()
    {
        NomeClasse = "Classe2";
        Vida = 20;
        Ataque = 2;
        Defesa = 2;
        IndiceHabilidadeCura = 2;
        IndiceHabilidadeAtaque = 2;
    }
}

public class Classe3 : Classe
{
    // Função que dá override na função abstrata da classe Classe que define atributos como Classe3
    public override void DefinirClasse()
    {
        NomeClasse = "Classe3";
        Vida = 30;
        Ataque = 3;
        Defesa = 3;
        IndiceHabilidadeCura = 3;
        IndiceHabilidadeAtaque = 3;
    }
}
