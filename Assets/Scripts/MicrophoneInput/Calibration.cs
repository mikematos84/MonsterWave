using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

namespace MicrophoneInput
{
    public class Calibration : MonoBehaviour
    {

        private Text _calibrationPrompt;

        private const string CalibrationPromptObjectName = "CalibrationPrompt";
        private const string PitchDetectionObjectName = "PitchDetection";
        private PitchDetection _pitchDetection;

        private float _calibrationTimer = 3f;

        private bool _calibrating;
        private bool _isFinishedCalibrating;

        // Use this for initialization
        private void Start ()
        {
            _calibrationPrompt = GameObject.Find(CalibrationPromptObjectName).GetComponent<Text>();
            _pitchDetection = GameObject.Find(PitchDetectionObjectName).GetComponent<PitchDetection>();

        }
	
        // Update is called once per frame
        private void Update ()
        {
            if (!_calibrating && !_isFinishedCalibrating)
            {
                StartCalibration();
                StartCoroutine(Calibrate());
            }
        }

        private void StartCalibration()
        {
            _calibrationPrompt.text = "Please sing or hum a low pitch.";
            if (_pitchDetection.PitchValue > 0)
            {
                _calibrating = true;
            }
        }



        private IEnumerator Calibrate()
        {
            var pitches = new List<float>();
            float pitchTotal = 0f;

            while (_calibrating && !_isFinishedCalibrating)
            {
                if(_calibrating)
                    _calibrationPrompt.text = "Detecting voice...";
                if (_pitchDetection.PitchValue > 0)
                {
                    pitches.Add(_pitchDetection.PitchValue);
                    pitchTotal += _pitchDetection.PitchValue;
                }
                yield return new WaitForSeconds(_calibrationTimer);
                _calibrating = false;
                _isFinishedCalibrating = true;
                var avgPitch = pitchTotal / pitches.Count;
                _calibrationPrompt.text = "registered low pitch baseline : " + avgPitch;

            }
        }


    }
}
