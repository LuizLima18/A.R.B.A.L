using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public static int vida;
    public static int pontos;
    public static int vidaInimigo;

    public Text pontosText;
    public Image[] imagemVidas;

    void Start()
    {
        MainScript.pontos = 0;
    }


    void Update()
    {

        pontosText.text = MainScript.pontos.ToString();

        for (int i = 0; i < 5; i++)
        {
            imagemVidas[i].enabled = false;
        }

        for (int i = 0; i < vida; i++)
        {
            imagemVidas[i].enabled = true;
        }
    }
}
