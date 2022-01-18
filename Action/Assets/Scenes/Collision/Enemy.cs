using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CollisionSample
{

    public class Enemy : MonoBehaviour
    {
        NavMeshAgent agent;

        Transform target;

        public void SetTarget(Transform target)
        {
            agent.enabled = false;
            this.target = target;
            agent.enabled = true;
        }

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            if (target == null)return;
            agent.destination = target.position;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.CompareTag("Damage")||
                other.gameObject.CompareTag("Bullet"))
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Magic"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}