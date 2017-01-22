using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

namespace MicrophoneInput
{
    public class LowPitchCalibration : CalibrationBase
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
            RequestVoiceString = "Please sing or hum a low pitch";
            RegisteredVoiceString = "registered low pitch baseline : ";
        }



    }
}
