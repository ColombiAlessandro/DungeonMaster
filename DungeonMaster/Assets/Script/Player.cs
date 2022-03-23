using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //velocità giocatore 
    [SerializeField] float velocita;
    private BoxCollider2D pg;
    private Animator animazione;
    void Start()
    {
        pg = GetComponent<BoxCollider2D>();
        animazione = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //movimento giocatore
        transform.Translate(Input.GetAxis("Horizontal") * velocita, Input.GetAxis("Vertical") * velocita, 0);

        animazione.SetBool("Sinistra", Input.GetAxis("Horizontal") < 0);
        animazione.SetBool("Sopra", Input.GetAxis("Vertical") > 0);

    }
}
