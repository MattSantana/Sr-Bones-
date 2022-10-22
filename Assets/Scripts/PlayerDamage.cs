using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private Animator anim;
    public float range;
    public LayerMask Enemy;
    
    public 

    void Start() 
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update() 
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("BonesAttack"))
        {
           var enemy = Physics2D.OverlapCircle( transform.position, range, Enemy);
           
            if( enemy  != null )
            {
                //Botei esse timer só pra sincronizar o tempo do dano com a descida da animação da espada
                //timerAtk-=Time.deltaTime;
                if( PlayerController.liberaAtk == true)
                {
                    Debug.Log("Te peguei inimigo");
                    enemy.gameObject.GetComponent<InimigoPai>().PerdeVida(1);    
                    PlayerController.liberaAtk = false;
                } 
            
            } 
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
