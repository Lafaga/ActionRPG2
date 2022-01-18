using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionSample
{
    public class StatusSimulator : MonoBehaviour
    {
        public enum Type
        {
            Damage,
            Healing
        }

        private Type simulateType = Type.Damage;
        private Color maxColor = Color.white;
        private Color minColor = Color.white;
        private int transition = 0x1;
        private Material myMat = null;
        private bool isSimulating = false;

        private void Awake()
        {
            myMat = GetComponent<Renderer>().material;
        }

        public void Simulate(Type type)
        {
            this.simulateType = type;
            this.isSimulating = true;
        }

        void Update()
        {
            if (!isSimulating) return;
            Simulate();
        }
        void Simulate()
        { 
            switch (simulateType)
            {
                case Type.Damage:
                    maxColor = Color.red;
                    minColor = Color.red;
                    minColor.r = 0f;
                    break;
                case Type.Healing:
                    maxColor = Color.green;
                    minColor = Color.green;
                    minColor.g = 0f;
                    break;
            }

            transition = ~transition;
            myMat.SetColor("_BaseColor", Color.Lerp(minColor, maxColor, transition));
        }

        public void EndSimulate()
        {
            isSimulating = false;
            myMat.SetColor("_BaseColor", Color.white);
        }

    }
}