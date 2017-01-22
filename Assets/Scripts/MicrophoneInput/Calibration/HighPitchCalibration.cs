using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

namespace MicrophoneInput
{
    public class HighPitchCalibration : CalibrationBase
    {

        // Use this for initialization
        private void OnEnable ()
        {
            Initialize();
        }

        // Update is called once per frame
        private void Update ()
        {
            if (!enabled) return;
            if (Calibrating || IsFinishedCalibrating) return;
            StartCalibration();
            StartCoroutine(Calibrate());
        }

        protected void Initialize()
        {
            PitchCalibrationText = GetComponent<Text>();
            PitchDetection = GameObject.Find(PitchDetectionObjectName).GetComponent<PitchDetection>();

            DetectingVoiceString = "Detecting voice...";
            RequestVoiceString = "Please sing or hum a high pitch";
            RegisteredVoiceString = "registered high pitch baseline : ";
        }



    }
}
