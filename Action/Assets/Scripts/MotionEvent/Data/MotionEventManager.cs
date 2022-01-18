using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventManager
{
    private static MotionEventManager inst = null;
    public static MotionEventManager Inst
    {
        get
        {
            if (inst == null)
            {
                inst = new MotionEventManager();
            }

            return inst;
        }
    }

    private MotionEventManager() { }

    public void Execute(string[] dataList) 
    {
        if (dataList == null) { return; }

        foreach(var eventId in dataList)
        {
            uint targetEventId = 0U;

            if (!uint.TryParse(eventId, out targetEventId))
            {
                Debug.LogError("Execution Fail Event ID:" + eventId);
                continue;
            }

            Debug.Log("Executed Event ID:" + targetEventId);
        }
    }
}
