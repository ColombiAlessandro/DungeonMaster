using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreazioneNemici : MonoBehaviour
{
    private Animator animazioni;
    [SerializeField] GameObject Ondata1,Ondata2,Ondata3,miniBossS,miniBossF,BossG,Wave1,Wave2,Wave3,Victory;
    public Ondata1 ondata1;
    public Ondata2 ondata2;
    public Ondata3 ondata3;
    public Nemico2 nemico;
    private int Ondata=1;
    void Start()
    {
        nemico = miniBossS.GetComponent<Nemico2>();
        ondata1 = Ondata1.GetComponent<Ondata1>();
        ondata2 = Ondata2.GetComponent<Ondata2>();
        ondata3 = Ondata3.GetComponent<Ondata3>();

        Ondata1.SetActive(true);
        Wave1.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
           UnityEngine.Debug.Log("i:" + ondata1.i);
        UnityEngine.Debug.Log("miniboss:" + miniBossS);
        if (miniBossS==null && Ondata==1)
           {
               Ondata1.SetActive(false);
               Ondata2.SetActive(true);
               ondata1.i = 0;
               Ondata++;
               Wave1.SetActive(false);
               Wave2.SetActive(true);
        }
           else if (miniBossF==null && Ondata==2)
           {
               Ondata2.SetActive(false);
               Ondata3.SetActive(true);
               ondata1.i = 0;
               Ondata++;
               Wave2.SetActive(false);
               Wave3.SetActive(true);

        }
           else if(BossG==null && Ondata==3)
           {
               ondata1.i = 0;
               Ondata3.SetActive(false);
               Wave3.SetActive(false);
               Victory.SetActive(true);
        }
    }
}
