using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Player : MonoBehaviour
{
    //dichiarazioni
    [SerializeField] float velocita;
    [SerializeField] int vite;
    public static Timer timerAttacco;
    public bool attacco;
    public Barra barra;
    private BoxCollider2D pg;
    private Rigidbody2D rb;
    private Animator animazione;
    private Vector2 movimento;
    void Start()
    {
        //assegnazione variabili
        rb = GetComponent<Rigidbody2D>();
        pg = GetComponent<BoxCollider2D>();
        animazione = GetComponent<Animator>();
        barra.VitaMassima(vite);
        timerAttacco = new Timer(1100);
        timerAttacco.Elapsed += TimerAttacco_Elapsed;
    }

    private void TimerAttacco_Elapsed(object sender, ElapsedEventArgs e)
    {
        attacco = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attacco = true;
            timerAttacco.Start();
            Animazione();
        }
    }
    private void FixedUpdate()
    {
        //movimento giocatore
        Movimento();
        //animazione movimento
        Animazione();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nemico"))
        {
            if (attacco)
            {
                Debug.Log("Colpito");
            }
            else
            {
                Danno();
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
        animazione.SetBool("Attacco", attacco);
    }
    private void Danno()
    {
        vite--;
        barra.ImpostaVita(vite);
        if (vite == 0)
        {
            Destroy(gameObject);
        }
    }
}
