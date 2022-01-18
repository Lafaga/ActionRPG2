using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionClipSamplingPanel : MonoBehaviour
{
    [SerializeField]
    private Text currentClipName = null;

    [SerializeField]
    private Text clipTotalLength = null;

    [SerializeField]
    private Text currentFrame = null;

    [SerializeField]
    private Slider samplingTimeline = null;

    private AnimationClip currentClip = null;

    private Action<float> onSamplingValueChange = null;

    public void SetOnSamplingValueChange(Action<float> callback)
    {
        onSamplingValueChange = callback;

        samplingTimeline.onValueChanged.AddListener((val) => {

            currentFrame.text = samplingTimeline.value.ToString();
            onSamplingValueChange?.Invoke( samplingTimeline.value );
        
        });
    }

    public void SetSamplingClip(AnimationClip clip)
    {
        currentClip = clip;
        currentClipName.text = clip.name;
        clipTotalLength.text = clip.length.ToString();
        currentFrame.text = "0";

        samplingTimeline.minValue = 0f;
        samplingTimeline.maxValue = clip.length;
        samplingTimeline.value = 0f;
    }

}
