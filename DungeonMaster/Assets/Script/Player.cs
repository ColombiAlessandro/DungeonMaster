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
       // MenuPausa.SetActive(false);
     
    }
    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
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
            if (vite < 3)
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
                    invulnerabilità = Time.time + 1.0f;
                }
            }
        }
    }
    private void Movimento()
    {
        movimento.x = Input.GetAxis("Horizontal") * velocita;
        movimento.y = Input.GetAxis("Vertical") * velocita;
        rb.MovePosition(rb.position + movimento);
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
   
}
