using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneTest : MonoBehaviour {

    private string _microphoneName;

    private readonly string _audioGameObject = "AudioSource";

    private AudioSource _audioSource;

    private AudioClip _tempClip;

	void Start ()
	{
	    _microphoneName = Microphone.devices[0];
	    _audioSource = GameObject.Find(_audioGameObject).GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.BackQuote))
	    {
	        Debug.Log("Recording");

	        _tempClip = Microphone.Start(_microphoneName, false, 2, 44100);
	    }

	    if (Input.GetKeyUp(KeyCode.BackQuote))
	    {
            Debug.Log("End record");
            StopRecording();

	    }
	}

    private void StopRecording()
    {
        var recordingLength = Microphone.GetPosition(_microphoneName);
        if (recordingLength == 0)
            return;
        Microphone.End(_microphoneName);
//        float[] totalSamples = new float[_tempClip.samples];
//        _tempClip.GetData(new float[_tempClip.samples * _tempClip.channels], 0);
//        float[] trimmedSamples = new float[recordingLength];
//        Array.Copy(totalSamples, trimmedSamples, trimmedSamples.Length - 1);
//        _tempClip.SetData(trimmedSamples, 0);
        _audioSource.clip = _tempClip;
        _audioSource.Play();
    }
}
