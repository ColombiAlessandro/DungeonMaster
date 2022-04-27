using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class Player : MonoBehaviour
{
    //dichiarazioni
    [SerializeField] public float velocita;
    [SerializeField] public int vite;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject schermataMorte;
    public Nemico nemico;
    public bool attacco, attaccaFermo, colpito, fermo = true;
    public Barra barra;
    private BoxCollider2D pg;
    public Rigidbody2D rb;
    //movimento
    private Animator animazione;
    public Vector2 movimento;
    //attacco e danno
    private float cooldown = 0;
    private float durata;
    private float invulnerabilità = 0;
    private int VersoKnockBack, VersoKnockBack1;
    public Transform pos;
    //suoni
    [SerializeField] public AudioSource slash;
    [SerializeField] public AudioSource danno;
    [SerializeField] public AudioSource death;
    //menu pausa
    void Start()
    {
        //assegnazione variabili
        rb = GetComponent<Rigidbody2D>();
        pg = GetComponent<BoxCollider2D>();
        animazione = GetComponent<Animator>();
        barra.VitaMassima(vite);
        pos = gameObject.GetComponent<Transform>();
        nemico = Enemy.GetComponent<Nemico>();
        // MenuPausa.SetActive(false);
        schermataMorte.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetMouseButtonDown(0))
        {
            // UnityEngine.Debug.Log(/*PauseMenu.activeSelf*/);
            if (Time.time >= cooldown)
            {
                attacco = true;
                if (fermo)
                {
                    attaccaFermo = true;
                    animazione.SetBool("attaccaFermo", true);
                }
                //fermo = true;
                //UnityEngine.Debug.Log(fermo);
                //UnityEngine.Debug.Log(attacco);
                slash.Play();
                animazione.SetBool("Attacco", true);
                cooldown = Time.time + 1.0f;
                durata = Time.time + 0.5f;
            }

        }
        if (Time.time >= durata)
        {
            attacco = false;
            animazione.SetBool("Attacco", false);
            attaccaFermo = false;
            animazione.SetBool("attaccaFermo", false);
        }

        if (colpito == true)
            colpito = false;
     
    }
    private void FixedUpdate()
    {
        //UnityEngine.Debug.Log(VersoKnockBack);
        //UnityEngine.Debug.Log(VersoKnockBack1);
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            animazione.SetBool("fermo", false);
            //movimento giocatore
            Movimento();
            //animazione movimento
            Animazione();
        }
        else
        {
            fermo = true;
            animazione.SetBool("fermo", true);
        }

       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //raccoglimento pozioni
        if (collision.gameObject.CompareTag("Pozione")){
            if (vite < 5)
            {
                vite++;
                barra.ImpostaVita(vite);
                Destroy(collision.gameObject);
            }
        }
        //danno/attacco
        if (collision.gameObject.CompareTag("Nemico"))
        {
            
            if (attacco == false)
                animazione.SetBool("Colpito", true);
            if (attacco)
            {
                UnityEngine.Debug.Log("Colpito");
            }
            else
            {
                if (Time.time >= invulnerabilità)
                {
                    Danno();
                    transform.position = Vector2.MoveTowards(transform.position, collision.gameObject.transform.position, -0.20f);
                    invulnerabilità = Time.time + 1.0f;
                }
            }
        }
    }
    private void Movimento()
    {
        if (Time.time >= invulnerabilità-0.5f)
        {
            movimento.x = Input.GetAxis("Horizontal") * velocita;
            movimento.y = Input.GetAxis("Vertical") * velocita;
            rb.MovePosition(rb.position + movimento);
        }
    }
    private void Animazione()
    {
        animazione.SetFloat("Orizzontale", movimento.x);
        animazione.SetFloat("Verticale", movimento.y);
        animazione.SetFloat("Velocità", movimento.sqrMagnitude);
    }
    private void Danno()
    {
        vite--;
        barra.ImpostaVita(vite);
        animazione.SetBool("Colpito", true);
        colpito = true;
        if (vite > 0)
        {
            danno.Play();


        } else {
            schermataMorte.SetActive(true);
            death.Play();
            animazione.SetBool("Morte", true);
            velocita = 0;
            //Destroy(gameObject);
        }
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        animazione.SetBool("Colpito", false);
    }
    /*
    IEnumerator Knockback()
    {
        fermo = true;
        if (/*(animazione.GetFloat("Orizzontale") < 0 && (animazione.GetFloat("Verticale") == 0 || animazione.GetFloat("Verticale") < 0))(animazione.GetFloat("Orizzontale") < 0 && VersoKnockBack == 1) || (animazione.GetFloat("Orizzontale") > 0 && VersoKnockBack == 2)) /*(animazione.GetFloat("Verticale") > 0 || animazione.GetFloat("Verticale") < 0 || animazione.GetFloat("Verticale") == 0)) || (animazione.GetFloat("Orizzontale") > 0  && VersoKnockBack==1))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(-1f, 0f);
        }
       else if((animazione.GetFloat("Orizzontale") < 0 && VersoKnockBack==3 ))animazione.GetFloat("Orizzontale") > 0 && (animazione.GetFloat("Verticale") == 0 || animazione.GetFloat("Verticale") < 0)) || (animazione.GetFloat("Orizzontale") > 0 && VersoKnockBack1 == 4)) /*(animazione.GetFloat("Verticale") > 0 || animazione.GetFloat("Verticale") < 0 || animazione.GetFloat("Verticale") == 0)) || (animazione.GetFloat("Orizzontale") < 0 && VersoKnockBack==2))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(1f, 0f);
        }
       else if((animazione.GetFloat("Verticale") > 0 && (animazione.GetFloat("Orizzontale") > 0 || animazione.GetFloat("Orizzontale") < 0 || animazione.GetFloat("Orizzontale") == 0)) || animazione.GetFloat("Verticale") < 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(0f, -1f);
        }
            
       else if((animazione.GetFloat("Verticale") < 0 && (animazione.GetFloat("Orizzontale") > 0 || animazione.GetFloat("Orizzontale") < 0 || animazione.GetFloat("Orizzontale") == 0)) || animazione.GetFloat("Verticale") > 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.velocity = new Vector2(0f, 1f);
        }
           

        yield return new WaitForSeconds(1f);
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.None;
        fermo = true;
        attaccaFermo = false;
        
    */

    

}
