using UnityEngine;
using TMPro;

namespace CollisionSample
{
    public class Damage : MonoBehaviour
    {
        protected TextMeshPro tmpDamage;

        protected int damage;

        protected float duration;

        protected float elapsedTime = 0f;

        public float speed = 2f;

        public void Setup(int damage, float duration)
        {
            this.damage = damage;
            this.duration = duration;
            tmpDamage.text = $"-{damage}";
        } 

        void Awake()
        {
            tmpDamage = GetComponent<TextMeshPro>();
        }

        void Update()
        {
            var pos = transform.position;
            pos.y += speed * Time.deltaTime;
            transform.position = pos;

            transform.eulerAngles = Vector3.zero;
        }

        private void LateUpdate()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= duration)
            {
                Destroy(this.gameObject);
                return;
            }
        }
    }

}