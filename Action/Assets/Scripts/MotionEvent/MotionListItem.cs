using System;
using UnityEngine;
using UnityEngine.UI;

public class MotionListItem : MonoBehaviour
{
    [SerializeField]
    private Button listItemButton = null;

    [SerializeField]
    private Text motionNameLabel = null;

    public void Setup(string motionName,Action onClick)
    {
        listItemButton.onClick.AddListener(()=> { onClick?.Invoke(); });
        motionNameLabel.text = motionName;
    }
}
