using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

namespace JY
{
    public class SkyManager : MonoBehaviour
    {
        public GameObject sky;
        private AzureWeatherController weather;
        bool timeCheck = false;
       
        public float limit = 10f;
        public float duration = 0;
        public enum Scene
        {
            scene01,
            scene02,
            main
        }

        // Start is called before the first frame update
        void Start()
        {
            weather = sky.GetComponent<AzureWeatherController>();
        }

        // Update is called once per frame
        void Update()
        {
            TimeAdd();
            TimeMinus();
            MultiplyTime();
            
        }

        private float TimeAdd()
        {
            float time = Time.deltaTime;
   
            if (limit>=duration&&!timeCheck)
            {
                duration += time;
               
            }
            else
            {
                timeCheck = true;
               
            }
          
            return duration;
        }
        private float TimeMinus()
        {
            float time = Time.deltaTime;

            if (duration>=0f &&timeCheck)
            {
                duration -= time;

            }
            else
            {
                timeCheck = false;

            }

            return duration;
        }

        private float Normalize()
        {
            float normalize = duration/limit;
            return normalize;
        }
        private void MultiplyTime()
        {
            float num = Normalize();
            float result = num * 2 + 5;
            //Debug.Log(result);
            weather.m_timeOfDay = result;
            //5~7값이 나와야 함.

        }
    }
}

