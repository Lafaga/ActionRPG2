using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionEventPanel : MonoBehaviour
{
    [SerializeField]
    private Button saveButton = null;

    [SerializeField]
    private Button resetButton = null;

    [SerializeField]
    private Button createNewMotionEventButton = null;

    [SerializeField]
    private GameObject motionListItemScrollView = null;

    [SerializeField]
    private Transform motionEventItemParent = null;

    [SerializeField]
    private MotionEventListItem listItemTemplate = null;

    private AnimationClip currentClip = null;

    private List<AnimationEvent> clipEventList = new List<AnimationEvent>();

    private MotionEventTool motionEventTool = null;

    private void Awake()
    {
        createNewMotionEventButton?.onClick.AddListener(OnCreateNewEventButtonClick);
        saveButton?.onClick.AddListener(OnSaveMotionEvent);
        resetButton?.onClick.AddListener(OnResetMotionEvent);
    }

    private void OnResetMotionEvent()
    {
        Setup(currentClip, motionEventTool);
    }

    private void OnSaveMotionEvent()
    {

#if UNITY_EDITOR
        
        UnityEditor.AnimationUtility.SetAnimationEvents(currentClip, clipEventList.ToArray());
        UnityEditor.EditorUtility.DisplayDialog("保存成功", "モーションイベントの保存完了", "閉じる");

#endif

    }

    private void OnCreateNewEventButtonClick()
    {
        foreach(var checkEvent in clipEventList)
        {
            if (checkEvent.time == motionEventTool.CurrentFrame)
            {
                Debug.LogError("新規イベント追加エラー : 同フレームにイベントが存在してます");
                return;
            }
        }

        AnimationEvent newAnimationEvent = new AnimationEvent();
        newAnimationEvent.functionName = "OnMotionEvent";
        newAnimationEvent.time = motionEventTool.CurrentFrame;
        newAnimationEvent.stringParameter = string.Empty;

        clipEventList.Add(newAnimationEvent);
        SetupMotionEventPanel(clipEventList.ToArray());
    }

    public void Setup(AnimationClip clip, MotionEventTool tool)
    {
        currentClip = clip;
        motionEventTool = tool;
        clipEventList.Clear();

        if (currentClip != null)
        {
            var eventDatas = currentClip.events;
            if (eventDatas == null) return;
            if (eventDatas.Length == 0)
            {
                motionListItemScrollView.SetActive(false);
                return;
            }
            clipEventList.AddRange(eventDatas);

            SetupMotionEventPanel(eventDatas);
        }
    }

    private void SetupMotionEventPanel(AnimationEvent[] events)
    {
        if (motionEventItemParent != null)
        {
            foreach(Transform child in motionEventItemParent)
            {
                if (child.GetComponent<MotionEventListItem>().IsClonedObject)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        listItemTemplate.gameObject.SetActive(true);
        foreach(var eventData in events)
        {
            var newListItem = Instantiate(listItemTemplate, motionEventItemParent);
            MotionEventListItem meli = newListItem.GetComponent<MotionEventListItem>();
            meli.IsClonedObject = true;
            meli.Setup(eventData, OnMotionEventDeleted);
        }

        listItemTemplate.gameObject.SetActive(false);
        motionListItemScrollView.SetActive(true);
    }

    private void OnMotionEventDeleted(AnimationEvent animationEvent)
    {
        clipEventList.Remove(animationEvent);
        SetupMotionEventPanel(clipEventList.ToArray());

        if (clipEventList.Count == 0)
        {
            motionListItemScrollView.SetActive(false);
        }
    }
}
