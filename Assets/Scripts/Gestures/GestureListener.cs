using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edwon.VR.Gesture
{
    public class GestureListener : MonoBehaviour
    {
        public GameObject m_Head = null;
        public Camera m_Camera = null;
        public Monster m_Monster = null;
 

        void Start()
        {
            m_Camera = m_Head.GetComponent<Camera>();
        }

        void Update()
        {

            Ray ray = m_Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.name);
                m_Monster = hit.transform.gameObject.GetComponent<Monster>();
                if (m_Monster)
                {
                    Debug.Log(m_Monster.waveType);
                }
            }
        }

        void OnEnable()
        {
            GestureRecognizer.GestureDetectedEvent += OnGestureDetected;
            GestureRecognizer.GestureRejectedEvent += OnGestureRejected;
        }

        void OnDisable()
        {
            GestureRecognizer.GestureDetectedEvent -= OnGestureDetected;
            GestureRecognizer.GestureRejectedEvent -= OnGestureRejected;
        }

        void OnGestureDetected(string gestureName, double confidence, Handedness hand, bool isDouble)
        {
            //string confidenceString = confidence.ToString().Substring(0, 4);
            //Debug.Log("detected gesture: " + gestureName + " with confidence: " + confidenceString);

            if (m_Monster != null)
            {
                if(m_Monster.waveType == gestureName)
                {
                    m_Monster.Friend();
                }
                else
                {
                    m_Monster.Unfriend();
                }
                m_Monster = null;
            }

            switch (gestureName)
            {
                case "Simple Wave":
                    Debug.Log("Simple Wave");
                    break;

                case "Vertical Wave":
                    Debug.Log("Vertical Wave");
                    break;
            }
        }

        void OnGestureRejected(string error, string gestureName = null, double confidenceValue = 0)
        {
            Debug.Log("Gesture Rejected");
        }
    }
}