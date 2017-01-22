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

            Vector3 forward = m_Camera.transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(m_Camera.transform.position, forward, Color.green);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.name);
                m_Monster = hit.transform.gameObject.GetComponent<Monster>();
                if (m_Monster)
                {
                    //Debug.Log(m_Monster.waveType);
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
            if (m_Monster != null)
            {
                string gestureNameStripped = gestureName.Replace("Left--", "");
                gestureNameStripped = gestureName.Replace("Right--", "");

                int index = System.Array.IndexOf(m_Monster.waveType, gestureNameStripped);

                if (index >= 0)
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

                default:
                    break;
            }
        }

        void OnGestureRejected(string error, string gestureName = null, double confidenceValue = 0)
        {
            Debug.Log("Gesture Rejected");
        }
    }
}