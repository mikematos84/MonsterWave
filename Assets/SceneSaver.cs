using System.Collections;
using System.Collections.Generic;
using MicrophoneInput;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{

    public float highTarget, lowTarget;
    private int numTargets = 2;
    private int targetsCalibrated = 0;

	// Use this for initialization
	void Start () {
	    DontDestroyOnLoad(transform.gameObject);
	}

    public void SetTargetPitch(Transform caller, float median)
    {

        if (caller.name == "LowPitchCalibration")
        {
            lowTarget = median;
            Debug.Log("Low Target Set");
            targetsCalibrated++;
        }
        else
        {
            highTarget = median;
            Debug.Log("High Target Set");
            targetsCalibrated++;
        }

        if (targetsCalibrated == numTargets)
        {
            GameObject.Find("PitchDetection").GetComponent<PitchDetection>().displayPitch = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }


}
