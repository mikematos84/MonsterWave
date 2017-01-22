using System;
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

            while (Calibrating && !IsFinishedCalibrating)
            {
                if(Calibrating)
                    PitchCalibrationText.text = DetectingVoiceString;
                if (PitchDetection.PitchValue > 0)
                {
                    pitches.Add(PitchDetection.PitchValue);
                }
                yield return new WaitForSeconds(CalibrationTimer);
                Calibrating = false;
                IsFinishedCalibrating = true;
                var medianPitch = GetMedian(pitches);
                PitchCalibrationText.text = RegisteredVoiceString + medianPitch;

            }
        }

        protected float GetMedian(List<float> sourceNumbers) {
            //Framework 2.0 version of this method. there is an easier way in F4
            if (sourceNumbers == null || sourceNumbers.Count == 0)
                throw new Exception("Median of empty list not defined.");

            //make sure the list is sorted, but use a new array
            float[] sortedPNumbers = sourceNumbers.ToArray();
            Array.Sort(sortedPNumbers);

            //get the median
            int size = sortedPNumbers.Length;
            int mid = size / 2;
            float median = (size % 2 != 0) ? sortedPNumbers[mid] : (sortedPNumbers[mid] + sortedPNumbers[mid - 1]) / 2;
            return median;
        }


    }
}
