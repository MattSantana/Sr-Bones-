using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
   {
        if( other.CompareTag("Enemy"))
        {
            other.GetComponent<InimigoPai>().PerdeVida(1);
            Destroy(gameObject);
        }
        Destroy(gameObject, 3f);
   }
}