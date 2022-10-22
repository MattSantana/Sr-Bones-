using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    public Transform playerPos;

    public float speed;
    public float rushSpeed;
    public float sec;

    public float smoothSpeed = 0.125f;

    public bool follow;
    public bool rush;


    void Start()
    {
        StartCoroutine(FollolwAndRush());
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    void FixedUpdate()
    {
        Follow();
        Rush();
    }

    void Follow()
    {
        if (follow)
        {
            Vector3 move = transform.position;
            move.y = (playerPos.position).y;

            Vector3 smoothedPos = Vector3.Lerp(transform.position, move, smoothSpeed);

            transform.position = smoothedPos;
        }
    }

    void Rush()
    {
        if (rush)
        {
            StopCoroutine(FollolwAndRush());

            transform.Translate(-Vector2.right * rushSpeed * Time.deltaTime);
        }
    }

    IEnumerator FollolwAndRush()
    {
        follow = true;

        yield return new WaitForSeconds(sec);

        follow = false;
        rush = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if( other.CompareTag("Player") )
        {
           other.GetComponent<PlayerController>().TakeDamage(1);
        }
    }
}
