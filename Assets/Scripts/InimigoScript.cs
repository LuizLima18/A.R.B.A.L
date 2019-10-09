using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoScript : MonoBehaviour
{

    public GameObject alvo;
    
    public float visao;
    private bool chase;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    Vector3 posicaoInicial;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        MainScript.vidaInimigo = 6;
        posicaoInicial = transform.position;
    }

    void Update()
    {
        if(MainScript.vidaInimigo <= 0)
        {
            MainScript.pontos = MainScript.pontos + 100;
            Destroy(gameObject);

        }

        float distancia = Vector2.Distance(transform.position, alvo.transform.position);


        //Inimigo persegue o jogador
        if (distancia < visao)
        {
            transform.position = Vector2.Lerp(transform.position, alvo.transform.position, 0.01f);
            sr.flipX = true;
            chase = true;
        }
        else if(Vector3.Distance(transform.position, posicaoInicial) > 0.0f)
        {
            transform.position = Vector3.Lerp(transform.position, posicaoInicial, 0.008f);
            sr.flipX = false;
            chase = false;
            
        }
        

        //Animação
        anim.SetBool("pPerseguir", chase);

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        // Caso o NPC toque no jogador
        if (c.gameObject.tag == "Jogador")
        {
            
            MainScript.vida--;
        }
    }

    
 


}
