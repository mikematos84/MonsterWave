﻿using MicrophoneInput.Pitch;
using UnityEngine;
using UnityEngine.UI;

namespace MicrophoneInput
{
    public class PitchDetection : MonoBehaviour
    {
        public float RmsValue;
        public float DbValue;
        public float PitchValue;

        public Text PitchDisplayText;
        public Text VolumeDisplayText;

        private const int QSamples = 1024;
        private const float RefValue = 0.1f;
        private const float Threshold = 0.005f;

        float[] _samples;
        private float[] _spectrum;
        private float _fSample;
        private AudioSource _audioSource;

        private PitchTracker _pitchTracker;


        void Start()
        {
            _samples = new float[QSamples];
            _spectrum = new float[QSamples];
            _fSample = AudioSettings.outputSampleRate;
            _audioSource = GetComponent<AudioSource>();
            _pitchTracker = new PitchTracker(_fSample);
        }

        void Update()
        {
            AnalyzeSound();
        }

        void AnalyzeSound()
        {
            _audioSource.GetOutputData(_samples, 0); // fill array with samples
            int i;
            float sum = 0;
            for (i = 0; i < QSamples; i++)
            {
                sum += _samples[i] * _samples[i]; // sum squared samples
            }
            RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average
            DbValue = 20 * Mathf.Log10(RmsValue / RefValue); // calculate dB
            if (DbValue < -160) DbValue = -160; // clamp it to -160dB min
            // get sound spectrum
            _audioSource.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
            float maxV = 0;
            var maxN = 0;
            for (i = 0; i < QSamples; i++)
            { // find max
                if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                    continue;
                maxV = _spectrum[i];
                maxN = i; // maxN is the index of max
            }
            float freqN = maxN; // pass the index to a float variable
            if (maxN > 0 && maxN < QSamples - 1)
            { // interpolate index using neighbours
                var dL = _spectrum[maxN - 1] / _spectrum[maxN];
                var dR = _spectrum[maxN + 1] / _spectrum[maxN];
                freqN += 0.5f * (dR * dR - dL * dL);
            }
            PitchValue = GetPitchValue(_pitchTracker.ProcessBuffer(_samples));
            DisplayUI();
        }

        private float GetPitchValue(float freqN)
        {
            return freqN * (_fSample / 2) / QSamples; // convert index to frequency
        }

        private void DisplayUI()
        {
            SetText(PitchValue, "Pitch : ", PitchDisplayText);
            SetText(DbValue, "Volume : ", VolumeDisplayText);
        }

        private void SetText(float value, string label, Text uiText)
        {
            uiText.text = string.Concat(label, value.ToString());
        }
    }
}