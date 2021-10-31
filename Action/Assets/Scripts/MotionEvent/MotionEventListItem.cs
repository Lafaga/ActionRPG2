using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionEventListItem : MonoBehaviour
{
    [SerializeField]
    private Text currentFrame = null;

    [SerializeField]
    private Text eventData = null;

    [SerializeField]
    private Input eventDataInput = null;

    [SerializeField]
    private Button deleteButton = null;

    [SerializeField]
    private Button editButton = null;

    public bool IsClonedObject = false;

    AnimationEvent animEventData = null;

    public void Setup(AnimationEvent data)
    {
        if (data != null)
        {
            animEventData = data;
        }
    }


}