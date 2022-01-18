using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventTool : MonoBehaviour
{
    [SerializeField]
    private Animator targetActorAnimator = null;

    [SerializeField]
    private MotionListItem listItemTemplate = null;

    [SerializeField]
    private Transform motionListParent = null;

    [SerializeField]
    private MotionClipSamplingPanel samplingPanel = null;

    [SerializeField]
    private MotionEventPanel eventPanel = null;

    private GameObject samplingActor = null;

    private AnimationClip[] motionClips = null;

    private AnimationClip currentClip = null;

    public float CurrentFrame { private set; get; } = 0f;

    void Start()
    {
        motionClips = targetActorAnimator?.runtimeAnimatorController.animationClips;
        samplingActor = targetActorAnimator?.gameObject;
        samplingPanel.SetOnSamplingValueChange(PlaySamplingAnim);
        LoadAllMotion();
    }

    void LoadAllMotion()
    {
        if (motionClips == null) 
        {
            listItemTemplate.gameObject.SetActive(false);
            return;
        }

        foreach(AnimationClip motionClip in motionClips)
        {
            GameObject newListItem = Instantiate(listItemTemplate.gameObject, motionListParent);
            MotionListItem mli = newListItem.GetComponent<MotionListItem>();
            string clipName = motionClip.name;

            if (clipName.Equals("idle"))
            {
                currentClip = motionClip;
                PlaySamplingAnim(0f);
                samplingPanel.SetSamplingClip(currentClip);
                eventPanel.Setup(motionClip, this);
            }

            mli.Setup(clipName, () => {
                currentClip = motionClip;
                PlaySamplingAnim(0f);
                samplingPanel.SetSamplingClip(currentClip);
                eventPanel.Setup(motionClip, this);
            });
        }

        listItemTemplate.gameObject.SetActive(false);
    }

    void PlaySamplingAnim(float targetFrame)
    {
        if (currentClip == null) { return; }
        
        if (targetActorAnimator != null)
        {
            if (targetActorAnimator.enabled)
                targetActorAnimator.enabled = false;
        }

        currentClip.SampleAnimation(samplingActor, targetFrame);

        CurrentFrame = targetFrame;
    }

    
}
