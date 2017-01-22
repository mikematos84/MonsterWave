using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MicrophoneInput.Calibration
{
    public class CalibrationManager : MonoBehaviour
    {

        public GameObject LowPitchCalibrationObj;
        public GameObject HighPitchCalibrationObj;

        private CalibrationBase _lowPitchCalibration;
        private CalibrationBase _highPitchCalibration;

        private bool activated;

        // Use this for initialization
        void Start ()
        {
            _lowPitchCalibration = LowPitchCalibrationObj.GetComponentInChildren<CalibrationBase>();
            _highPitchCalibration = HighPitchCalibrationObj.GetComponentInChildren<CalibrationBase>();

            SetObjectAndChildrenActive(_lowPitchCalibration.gameObject, false);
            SetObjectAndChildrenActive(_highPitchCalibration.gameObject, false);

            SetObjectAndChildrenActive(_lowPitchCalibration.gameObject, true);

        }
	
        // Update is called once per frame
        void Update () {

            if (_lowPitchCalibration.IsFinishedCalibrating && !activated)
            {
                StartCoroutine(DelayNextCalibration());
            }

        }

        private IEnumerator DelayNextCalibration()
        {
            LowPitchCalibrationObj.transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(2f);
            SetObjectAndChildrenActive(_highPitchCalibration.gameObject, true);
            activated = true;

        }

        private void SetObjectAndChildrenActive(GameObject go, bool isActive)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                go.transform.GetChild(i).gameObject.SetActive(isActive);
            }

            go.SetActive(isActive);


        }
    }
}
