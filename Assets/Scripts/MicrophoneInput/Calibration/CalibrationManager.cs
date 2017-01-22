using System;
using System.Collections.Generic;
using UnityEngine;

namespace MicrophoneInput.Calibration
{
    public class CalibrationManager : MonoBehaviour
    {

        private CalibrationBase _lowPitchCalibration;
        private CalibrationBase _highPitchCalibration;

        // Use this for initialization
        void Start ()
        {
            _lowPitchCalibration = GameObject.Find("LowPitchCalibration").GetComponent<CalibrationBase>();
            _highPitchCalibration = GameObject.Find("HighPitchCalibration").GetComponent<CalibrationBase>();

            _lowPitchCalibration.gameObject.SetActive(false);
            _highPitchCalibration.gameObject.SetActive(false);

            _lowPitchCalibration.gameObject.SetActive(true);
        }
	
        // Update is called once per frame
        void Update () {

            if (_lowPitchCalibration.IsFinishedCalibrating)
            {
                _highPitchCalibration.gameObject.SetActive(true);
            }

        }
    }
}
