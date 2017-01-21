using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edwon.VR.Gesture
{
    public class GestureListener : MonoBehaviour
    {

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