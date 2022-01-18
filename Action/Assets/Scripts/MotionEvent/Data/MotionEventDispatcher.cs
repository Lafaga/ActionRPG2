using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventDispatcher : MonoBehaviour
{
    void OnMotionEvent(string motionEventData)
    {
        if (string.IsNullOrEmpty(motionEventData))
        {
            return;
        }

        string[] dataList = motionEventData.Trim().Split(',');
        MotionEventManager.Inst.Execute(dataList);
    }
}
