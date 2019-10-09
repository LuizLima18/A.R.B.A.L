using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorScript : MonoBehaviour
{

    public float velocidade;
    public float impulso;

    public Camera cam;
    public Transform sensorChao;
    public GameObject arma;
    public GameObject projetilPrefab;

    private bool atirar;
    private bool estaNoChao;
    private float mover;
    private bool pular;

    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private Animator anim;

    Vector3 posicaoInicialCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        posicaoInicialCamera = cam.transform.position;

        MainScript.vida = 5;
    }

    
    void Update()
    {

        
        
        // Input para mover personagem
        mover = Input.GetAxisRaw("Horizontal") * velocidade;

        // Orientacao do personagem
        if (mover > 0.0f)
        {
            spr.flipX = false;
        }
        else if (mover < 0.0f)
        {
            spr.flipX = true;
        }

        //Animacao
        anim.SetFloat("pMover", Mathf.Abs(mover));
        anim.SetBool("pPular", estaNoChao);
        anim.SetFloat("pPuloMeio", rb.velocity.y);
        anim.SetBool("pAtirar", atirar);
        
        //Morte por queda
        if(transform.position.y < -5.5)
        {
            SceneManager.LoadScene("OverScene");
        }



        // Verifica contato com o piso
        estaNoChao = Physics2D.Linecast(transform.position,
            sensorChao.position, 1 << LayerMask.NameToLayer("Piso"));

        // Input para o pulo
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            pular = true;
        }

        //Input para atirar
        if (Input.GetButton("Fire1") && atirar == false)
        {
            atirar = true;
            StartCoroutine(Disparar());
        }

        

        //Camera
        cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);

        if(MainScript.vida <= 0)
        {

           // mover =  Vector2.zero;

            Destroy(gameObject, 3.0f);
        }

        

    }

    
    void FixedUpdate()
    {
        // Mover
        rb.velocity = new Vector2(mover, rb.velocity.y);

        // Pulo
        if (pular)
        {
            rb.AddForce(Vector2.up * impulso);
            pular = false;
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {

        //Coleta moeda
        if (c.tag == "Moeda")
        {
            c.GetComponent<AudioSource>().Play();
            MainScript.pontos = MainScript.pontos +10;
            
            Destroy(c.gameObject, 0.3f);
        }

        
    }

    IEnumerator Disparar()
    {
        Instantiate(projetilPrefab, arma.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        atirar = false;

    }

}
