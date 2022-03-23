using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //dichiarazioni
    [SerializeField] float velocita;
    private BoxCollider2D pg;
    private Animator animazione;
    void Start()
    {
        //assegnazione variabili
        pg = GetComponent<BoxCollider2D>();
        animazione = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float spostamentoX= Input.GetAxis("Horizontal")*velocita;
        float spostamentoY= Input.GetAxis("Vertical")*velocita;
        float spostamento=(spostamentoX*spostamentoX)+(spostamentoY*spostamentoY);
        //movimento giocatore
        transform.Translate(spostamentoX, spostamentoY, 0);
        //controllo per animazione 
        animazione.SetFloat("Orizzontale", spostamentoX);
        animazione.SetFloat("Verticale", spostamentoY);
        animazione.SetFloat("Velocità", spostamento);

    }
}
