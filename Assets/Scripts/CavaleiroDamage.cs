using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavaleiroDamage : MonoBehaviour
{
    private Animator anim;
    public float range;
    public LayerMask Player;
    public float timerAtk = 0.35f;

    void Start() 
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("CavaleiroAtk"))
        {
            var player = Physics2D.OverlapCircle( transform.position, range, Player);
            
            if( player  != null )
            {
                //Botei esse timer só pra sincronizar o tempo do dano com a descida da animação da espada
                timerAtk-=Time.deltaTime;
                if( Inimigo01Controller.liberaAtk == true)
                {
                    Debug.Log("Te peguei Player");
                    player.gameObject.GetComponent<PlayerController>().TakeDamage(1);  
                    Inimigo01Controller.liberaAtk = false;
                }   
                
            } 
        }
    }
}
