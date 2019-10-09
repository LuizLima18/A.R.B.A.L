using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool jogoPausado;
    public GameObject pauseUI;


    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    void Continuar()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        jogoPausado = false;
    }

    void Pausar()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        jogoPausado = true; 
    }


}
