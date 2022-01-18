using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionSample
{
    public class Magic : MonoBehaviour
    {
        public float duration;

        private float elapsedTime;
        void Update()
        {
            elapsedTime+=Time.deltaTime;
            if(elapsedTime >= duration)
            {
                Destroy(this.gameObject);
            }
        }
    }

}