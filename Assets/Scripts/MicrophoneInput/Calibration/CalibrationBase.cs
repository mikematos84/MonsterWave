using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

namespace MicrophoneInput
{
    public class CalibrationBase : MonoBehaviour
    {

        protected Text PitchCalibrationText;

        protected const string PitchDetectionObjectName = "PitchDetection";

        protected bool Calibrating;
        public bool IsFinishedCalibrating { get; private set; }

        protected string DetectingVoiceString;
        protected string RequestVoiceString;
        protected string RegisteredVoiceString;

        protected PitchDetection PitchDetection;

        protected float CalibrationTimer = 5f;


        protected void Initialize()
        {


        }

        protected void StartCalibration()
        {
            PitchCalibrationText.text = RequestVoiceString;
            if (PitchDetection.PitchValue > 0)
            {
                Calibrating = true;
            }
        }



        protected IEnumerator Calibrate()
        {
            var pitches = new List<float>();
            float pitchTotal = 0f;

            while (Calibrating && !IsFinishedCalibrating)
            {
                if(Calibrating)
                    PitchCalibrationText.text = DetectingVoiceString;
                if (PitchDetection.PitchValue > 0)
                {
                    pitches.Add(PitchDetection.PitchValue);
                    pitchTotal += PitchDetection.PitchValue;
                }
                yield return new WaitForSeconds(CalibrationTimer);
                Calibrating = false;
                IsFinishedCalibrating = true;
                var avgPitch = pitchTotal / pitches.Count;
                PitchCalibrationText.text = RegisteredVoiceString + avgPitch;

            }
        }


    }
}
