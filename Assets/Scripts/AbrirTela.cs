using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirTela : MonoBehaviour
{
    public string cenas;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(cenas);
        }
    }
}
