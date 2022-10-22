using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{
    public Transform playerPos;
    public float speed;

    public float distance;

    // Você vai colocar aqui o ataque e tirar essas outras variáveis.
    public GameObject spt1;
    public GameObject spt2;

    void Start()
    {
        
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
        if (distance <= 2)
        {
            spt1.SetActive(false);
            spt2.SetActive(true);
        }

        if (distance >= 2)
        {
            Follow();
            spt1.SetActive(true);
            spt2.SetActive(false);
        }
    }
}
