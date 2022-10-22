using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo03Controller : InimigoPai
{
    [SerializeField] private GameObject myShot;
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
            var position = new Vector2( Random.Range( player.transform.position.x -2.8f , player.transform.position.x + 2.8f ), Random.Range( -1f, 1f ) );
            
            Instantiate( myShot, position, Quaternion.identity);

            Cooldown = 1.5f;
        }
    }
    
}

