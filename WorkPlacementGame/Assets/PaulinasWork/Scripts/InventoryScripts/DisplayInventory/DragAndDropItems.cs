using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItems : MonoBehaviour, IDragHandler, IEndDragHandler
{ 
    public Vector3 pos;

    void Awake()
    {
        pos = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        this.transform.position = pos;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other == GameObject.FindGameObjectWithTag("equip"))
        {
            this.transform.position = other.transform.position;
        }
    }
}
