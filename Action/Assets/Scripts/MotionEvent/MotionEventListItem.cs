using System;
using UnityEngine;
using UnityEngine.UI;

public class MotionEventListItem : MonoBehaviour
{
    [SerializeField]
    private Text currentFrame = null;

    [SerializeField]
    private Text eventData = null;

    [SerializeField]
    private InputField eventDataInput = null;

    [SerializeField]
    private Button deleteButton = null;

    [SerializeField]
    private Button editButton = null;

    public bool IsClonedObject = false;

    AnimationEvent animEventData = null;

    private Action<AnimationEvent> onDeleteEvent = null;

    private enum EditState
    {
        Edit,
        Apply
    }

    private EditState currentEditState = EditState.Edit;

    private void Awake()
    {
        editButton?.onClick.AddListener(OnEditButtonClick);
        deleteButton?.onClick.AddListener(OnDeleteButtonClick);
    }

    private void OnDeleteButtonClick()
    {
        onDeleteEvent?.Invoke(animEventData);
    }

    private void OnEditButtonClick()
    {
        if (currentEditState == EditState.Edit)
        {
            currentEditState = EditState.Apply;
            editButton.GetComponentInChildren<Text>().text = "äÆóπ";
            eventDataInput.gameObject.SetActive(true);
        }
        else
        {
            currentEditState = EditState.Edit;
            editButton.GetComponentInChildren<Text>().text = "ï“èW";
            eventDataInput.gameObject.SetActive(false);

            var newEventData = eventDataInput.text;
            animEventData.stringParameter = newEventData;
            eventData.text = newEventData;
        }
    }

    public void Setup(AnimationEvent data, Action<AnimationEvent> onDeleteCallback)
    {
        if (data != null)
        {
            animEventData = data;
        }

        onDeleteEvent = onDeleteCallback;

        SetupDisplay();
    }

    private void SetupDisplay()
    {
        if (animEventData == null)
        {
            return;
        }

        currentFrame.text = string.Format("{0:#,0.000}", animEventData.time);
        eventData.text = animEventData.stringParameter;
        eventDataInput.text = animEventData.stringParameter;
        eventDataInput.gameObject.SetActive(false);
    }

}
