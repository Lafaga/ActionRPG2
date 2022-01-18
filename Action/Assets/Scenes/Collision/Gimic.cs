using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionSample
{

    public class Gimic : MonoBehaviour
    {
        public int delay;

        public float speed = 5f;

        Vector3 originalPos;

        int deg = 0;

        bool start = false;

        IEnumerator Start()
        {
            float r = Random.RandomRange(0, 1f);
            float g = Random.RandomRange(0, 1f);
            float b = Random.RandomRange(0, 1f);
            GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(r, g, b));

            originalPos = transform.position;

            yield return new WaitForSeconds(delay);
            start = true;
        }

        void Update()
        {
            if (!start) return;
            deg++;
            deg %= 360;

            float sineVal = Mathf.Sin(Mathf.Deg2Rad * deg);
            float dy = speed * sineVal;
            Vector3 newPos = originalPos + (Vector3.up * dy);
            transform.position = newPos;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }    
        }
    }
}