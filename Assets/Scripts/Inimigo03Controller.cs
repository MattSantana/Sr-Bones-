using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo03Controller : InimigoPai
{
    [SerializeField] private GameObject myShot;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float velShot;
    [SerializeField] private int qtdShots = 0;
    void Start()
    {
        
    }

    void Update()
    {
        MagicSpawner();
    }
    void MagicSpawner()
    {
        bool visible = GetComponentInChildren<SpriteRenderer>().isVisible;

        var player = FindObjectOfType<PlayerController>();

        Cooldown -= Time.deltaTime;

         if( visible == true && Cooldown <=0 )
        {
            var position = new Vector2( Random.Range( -7.59f, -1.54f ), Random.Range( -3.7f, - 1.3f ) );
            
            Instantiate( myShot, position, Quaternion.identity);

            Cooldown = 4;
        }
    }
    
}

