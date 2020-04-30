using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEventos : MonoBehaviour
{
    #region Variáveis

    private int linhasMaximas = 10;

    private Queue<string> fila = new Queue<string>();
    private string MeuTexto = "";
    private GUIStyle estiloGUI = new GUIStyle();

    #endregion

    public void NovoEventoLog(string evento)
    {
        // Se a conta da fila for maior ou igual ao limitador de tinhas
        if (fila.Count >= linhasMaximas)
        {
            // A primeira linha da fila é removida
            fila.Dequeue();
        }

        // Adiciona o texto do log na fila
        fila.Enqueue(evento);

        MeuTexto = "";

        foreach (string log in fila)
        {
            MeuTexto += "[ " + log + " ]";
            MeuTexto += "\n";
        }
    }


    void OnGUI()
    {
        // Define o tamanho da fonte que aparece no log
        estiloGUI.fontSize = 16;
        estiloGUI.wordWrap = true;

        // Define a posição do log 568, 210, 405, 210f
        GUI.Label(new Rect(568, (Screen.height - 210), 405, 1), MeuTexto, estiloGUI);
    }
}
