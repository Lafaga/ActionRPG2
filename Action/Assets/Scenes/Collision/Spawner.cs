using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionSample
{

    public class Spawner : MonoBehaviour
    {
        public float SpawnSpan = 5f;

        public int MaxEnemyPerSpawn = 5;

        public Enemy enemy;

        public Transform player;

        void Start()
        {
            StartCoroutine(ScheduledSpawn());
        }

        IEnumerator ScheduledSpawn()
        {
            while(true)
            {
                for(int i=0; i<Random.Range(0,MaxEnemyPerSpawn);i++)
                {
                    var newEnemy = Instantiate(enemy);
                    newEnemy.transform.position = transform.position;
                    newEnemy.SetTarget(player);
                }
                
                yield return new WaitForSecondsRealtime(SpawnSpan);
            }
        }
        
    }
}