using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class Player : MonoBehaviour
{
    //dichiarazioni
    [SerializeField] float velocita;
    [SerializeField] int vite;
    private int i = 0;
    public bool attacco, attaccaFermo,colpito, fermo = true;
    public Barra barra;
    private BoxCollider2D pg;
    public Rigidbody2D rb;
    private Animator animazione;
    public Vector2 movimento;
    private float cooldown = 0;
    private float durata;
    private float invulnerabilità = 0;
    public Transform pos;
    [SerializeField] public AudioSource slash;
    [SerializeField] public AudioSource danno;
    [SerializeField] public AudioSource death;
    
    void Start()
    {
        //assegnazione variabili
        rb = GetComponent<Rigidbody2D>();
        pg = GetComponent<BoxCollider2D>();
        animazione = GetComponent<Animator>();
        barra.VitaMassima(vite);
        pos = gameObject.GetComponent<Transform>();
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= cooldown)
            {
                //cdAttacco.Reset();
                attacco = true;
                fermo = true;
                UnityEngine.Debug.Log(fermo);
                UnityEngine.Debug.Log(attacco);
                slash.Play();
                gameObject.tag.Replace("Player", "Attacco");
                animazione.SetBool("Attacco", true);
                //timerAttacco.Start();
                cooldown = Time.time + 1.0f;
                durata = Time.time + 0.5f;
            }

        }
        if (Time.time >= durata)
        {
            attacco = false;
            animazione.SetBool("Attacco", false);
            gameObject.tag.Replace("Attacco", "Player");
        }

        if (colpito == true)
        {
            //StartCoroutine(Knockback());
            colpito = false;
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true)
        {
            animazione.SetBool("fermo", false);
            //movimento giocatore
            Movimento();
            //animazione movimento
            Animazione();
        }
        else
        {
            animazione.SetBool("fermo", true);
            if (attacco == true && fermo == true)
            {
                attaccaFermo = true;
                animazione.SetBool("attaccaFermo", true);
            }
            if (attacco == false && fermo == true && attaccaFermo == true)
            {
                animazione.SetBool("attaccaFermo", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nemico"))
        {
           if(attacco==false)
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
        danno.Play();
        if (vite == 0)
        {
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
    /*IEnumerator Knockback()
    {

        if(movimento.x<0 && (movimento.y >= 0 || movimento.y <= 0))
        {
            while (i < 10)
            {
                gameObject.transform.position = new Vector2(movimento.x - 0.50f,0);
                yield return null;
            }
        }
        else if (movimento.x > 0 && (movimento.y >= 0 || movimento.y<=0))
        {
            while (i < 10)
            {
                gameObject.transform.position = new Vector2(movimento.x + 0.50f, 0);
                yield return null;
            }
        }
        else if ((movimento.x <= 0 || movimento.x >= 0) && movimento.y > 0)
        {
            while (i < 10)
            {
                gameObject.transform.position = new Vector2(0, movimento.y + 0.50f);
                yield return null;
            }
        }
        else if ((movimento.x <= 0 || movimento.x >= 0) && movimento.y < 0)
        {
            while (i < 10)
            {
                
                gameObject.transform.position = new Vector2(0, movimento.y - 0.50f);
                yield return null;
            }
        }
    }*/
}
