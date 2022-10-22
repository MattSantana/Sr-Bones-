using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaPadre : MonoBehaviour
{   
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if( other.CompareTag("Player") )
        {
           other.GetComponent<PlayerController>().TakeDamage(1);
        }
    }
    public void SelfDestroy()
    {
        Destroy(gameObject, 0.5f);
    }
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        bool shotPadre  = GetComponentInChildren<SpriteRenderer>().isVisible;

        if( shotPadre)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("PadreShot"))
            {
                SelfDestroy();
            }
        }
    }
}
