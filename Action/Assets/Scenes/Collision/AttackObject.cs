using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionSample
{
    public class AttackObject : MonoBehaviour
    {
        public float lifeTime = 1f;

        float elapsedTimeFromCreation = 0f;
        
        void Update()
        {
            elapsedTimeFromCreation += Time.deltaTime;
            if (elapsedTimeFromCreation >= lifeTime)
            {
                Destroy(this.gameObject);
            }   
        }
    }
}