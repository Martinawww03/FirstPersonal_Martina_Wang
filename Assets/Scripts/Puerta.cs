using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        anim= GetComponent<Animator>();
    }
    public void Abrir()
    {
        anim.SetTrigger("Abrir");
    }

    
}
