using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : InimigoPai
{
    public Transform playerPos;
    public float speed;

    public float distance;
    public  Animator  anim;
   public static bool  liberaAtk = true;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Attack();

        distance = Vector2.Distance(transform.position, playerPos.position);
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    void Attack()
    {
        if (distance <= 2f)
        {
            Cooldown -= Time.deltaTime;
            if( Cooldown <= 0)
            {
                anim.SetTrigger("CavaleiroAtk");
                liberaAtk = true;
                Cooldown = 2f;
            }

        }

        if (distance >= 2f)
        {
            Follow();
        }
    }
}
