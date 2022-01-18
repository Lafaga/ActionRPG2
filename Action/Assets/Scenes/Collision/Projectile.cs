using UnityEngine;

namespace CollisionSample
{
    public class Projectile : MonoBehaviour 
    {   
        public float MaxTravelLength = 10f;

        public float Speed = 10f;
        private float travelledLength = 0f;
        void Update()
        {
            var df = Speed * Time.deltaTime;
            transform.Translate(Vector3.forward * df);
            travelledLength += df;

            if (travelledLength >= MaxTravelLength)
            {
                Destroy(this.gameObject);
            }
        }
    }
}