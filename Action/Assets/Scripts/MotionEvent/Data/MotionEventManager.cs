using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventManager : MonoBehaviour
{
    private static MotionEventManager inst = null;

    public static MotionEventManager Isnt
    {
        get
        {
            if (Isnt == null)
            {
                Isnt=new motionEventManager();
            }

            return Isnt;
        }
    }

    private MotionEventManager() { }


    public void Execute(string[] dataList)
    {
        if (dataList == null) { return; }

        foreach(var eventId in dataList)
        {
            unit targetEventId = OU;

            if(!unit.TryParse(eventId, out targetEventId))
            {
                Debug.LogError("Execution Fail Event ID:" + eventId);
                continue;
            }

            Debug.Log("Executed Event ID:" + targetEventId);
        }
    }
}
