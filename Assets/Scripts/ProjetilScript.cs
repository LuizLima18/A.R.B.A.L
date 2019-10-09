using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour
{

    public float velocidade;
    public float tempoBala;
    


    void Start()
    {
        Destroy(gameObject, tempoBala);        
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Inimigo")
        {
            MainScript.vidaInimigo--;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
