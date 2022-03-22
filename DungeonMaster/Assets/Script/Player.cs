using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocita;
    private BoxCollider2D pg;
    void Start()
    {
        pg = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * velocita, Input.GetAxis("Vertical") * velocita,0);
    }
}
