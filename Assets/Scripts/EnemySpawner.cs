using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private int level = 1;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float resetSpawnTime = 5f;
    private int qtdEnemys  = 0;
    private float upgrade = 0.25f;

     private bool CheckPosition (Vector3 position, Vector3 size) 
    {
        Collider2D hit = Physics2D.OverlapBox( position, size, 0f);

        if( hit != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Update()
    {
     EnemySpawn();   
    }
    private void EnemySpawn()
    {
        int qtd = level * 2; 

        if( spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }

        if( spawnTime <= 0 )
        {
            
            int repets = 0;

            while( qtdEnemys < qtd )
            {
                GameObject enemyBorn;
                repets++;
                if(repets > 600)
                {
                    break;
                }

                float chance = Random.Range( 1f, level);
                if (chance + 0.2f > 1.8f)
                {
                    enemyBorn = enemys[1];
                }
                else
                {
                    enemyBorn = enemys[0];
                }

                if( chance + upgrade > 2.3f)
                {
                    enemyBorn = enemys[2];
                }

                var position = new Vector2( transform.position.x , Random.Range( -3.6f, 0.05f ));
                //impedir inimigos de serem criados um em cima do outro.

                bool collisionBorn = CheckPosition ( position, enemyBorn.transform.localScale );

                if (collisionBorn)
                {
                    continue;
                }

                Instantiate( enemyBorn, position , Quaternion.identity );

                spawnTime = resetSpawnTime; 

                qtdEnemys++; 
            }
        } 

        if(qtdEnemys >= qtd)
        {
            qtdEnemys = 0;
        }
    }
}
