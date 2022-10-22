using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    [SerializeField] protected float Cooldown;
    [SerializeField] protected float life;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerdeVida(int dano)
    {
        life -= dano; 
        if( life <= 0 )
        {
          Destroy(gameObject);
        }        
  
    }
}
