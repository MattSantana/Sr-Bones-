using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenLife : MonoBehaviour
{
    void Update() 
    {
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerController.life += 5;
            Destroy(gameObject);
        }
        Debug.Log(PlayerController.life);
    }
}
