using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaPadre : MonoBehaviour
{    private void OnTriggerEnter2D(Collider2D other) 
    {
        if( other.CompareTag("Player") )
        {
           other.GetComponent<PlayerController>().TakeDamage(1);
        }
    }
}
