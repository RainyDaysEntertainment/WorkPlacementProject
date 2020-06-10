using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rect;
    Vector3 pos;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        pos.x = rect.transform.position.x;
        pos.y = rect.transform.position.y;
        pos.z = rect.transform.position.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rect.transform.localPosition = pos;
    }
}
