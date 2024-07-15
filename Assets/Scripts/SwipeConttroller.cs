using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeConttroller : MonoBehaviour, IEndDragHandler
{
    [SerializeField] int maxPage;
    int currentpage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;

    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;
    float dragThreshould;

    private void Awake()
    {
        currentpage = 1;
        targetPos = levelPagesRect.localPosition;
        dragThreshould = Screen.width / 15;
    }
    public void Next()
    {
        if (currentpage < maxPage)
        {
            currentpage++;
            targetPos += pageStep;
            MovePage();
        }

    }

    public void Perivous()
    {
        if (currentpage >1)
        {
            currentpage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshould)
        {
            if (eventData.position.x > eventData.pressPosition.x) Perivous();
            else Next();
        }
        else
        {
            MovePage();
        }
    }
}
