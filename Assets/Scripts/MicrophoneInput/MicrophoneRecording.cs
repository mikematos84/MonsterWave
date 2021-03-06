﻿using System;
using UnityEngine;
using Microphone = UnityEngine.Microphone;

namespace MicrophoneInput
{
    public class MicrophoneRecording : MonoBehaviour {

        private string _microphoneName;
        private AudioSource _audioSource;
        private AudioClip _tempClip;
        private int _sampleRate;

        private readonly string _audioGameObject = "PitchDetection";
        private readonly KeyCode _micPress = KeyCode.BackQuote;
        private readonly int _maxRecordTime = 300;



        #region monobehaviours
        void Start ()
        {
            _microphoneName = Microphone.devices[0];
            _sampleRate = AudioSettings.outputSampleRate;
            Debug.Log("Listening on microphone : " + _microphoneName);
            _audioSource = GameObject.Find(_audioGameObject).GetComponent<AudioSource>();


            _audioSource.clip = Microphone.Start(null, true, 10, _sampleRate);
            _audioSource.loop = true; // Set the AudioClip to loop
            while (!(Microphone.GetPosition(_microphoneName) > 0)){} // Wait until the recording has started
            _audioSource.Play(); // Play the audio source!

        }

        // Update is called once per frame
        void Update () {

            if (Input.GetKeyDown(_micPress))
            {
                StartRecording();
            }

            if (Input.GetKeyUp(_micPress))
            {
                StopRecording();

            }
        }
        #endregion

        /// <summary>
        /// Record on the microphone and store the recorded clip in the AudioSource
        /// </summary>
        private void StartRecording()
        {
            _tempClip = Microphone.Start(_microphoneName, false, _maxRecordTime, _sampleRate);
            _audioSource.clip = _tempClip;
            //hacky thing to get audio to playback only if there's something in the buffer
            while (!(Microphone.GetPosition(_microphoneName) > 0))
            {
            }

            PlaybackAudio();
        }

        /// <summary>
        /// Stop recording on key-up, then call ProcessAudio.
        /// </summary>
        private void StopRecording()
        {
            var recordingLength = Microphone.GetPosition(_microphoneName);
            if (recordingLength == 0)
                return;
            Microphone.End(_microphoneName);
            //ProcessAudio(recordingLength);
        }

        /// <summary>
        /// Trims the recorded clip based on how long the recording was pressed for, then calls PlaybackAudio.
        /// </summary>
        /// <param name="recordingLength">the length of recording time from Microphone.GetPosition()</param>
        private void ProcessAudio(int recordingLength)
        {
            var clipData = new float[_tempClip.samples * _tempClip.channels];
            _tempClip.GetData(clipData, 0);
            var trimmedData = new float[recordingLength * _tempClip.channels];
            Array.Copy(clipData, trimmedData, recordingLength - 1);
            var trimmedClip = AudioClip.Create(_tempClip.name, recordingLength, _tempClip.channels, _tempClip.frequency,
                false);
            trimmedClip.SetData(trimmedData, 0);
            _audioSource.clip = trimmedClip;
        }

        /// <summary>
        /// Trigger audio playback on the audiosource.
        /// </summary>
        private void PlaybackAudio()
        {
            _audioSource.Play();

        }

    }
}
