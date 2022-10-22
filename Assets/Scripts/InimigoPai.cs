using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    [SerializeField] protected float Cooldown;
    [SerializeField] protected float life;
    [SerializeField] protected GameObject lifeRegen;
    [SerializeField] protected float itemRate = 0.7f;
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

        float chance = Random.Range( 0f, 1f );
        if(chance > itemRate)
        {
          Instantiate( lifeRegen, GetComponent<InimigoPai>().transform.position, Quaternion.identity );
        }
      }        

    }
}
