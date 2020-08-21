using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float radius = 2f, dis;
    public QuestGiver questGiver;
    Quest item;
    public Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        item = questGiver.quest;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dis = Vector3.Distance(player.position, gameObject.transform.position);

            if (dis <= radius)
            {
                Pickup();
            }
        }
    }

    void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool wasPickedUp = QuestInv.instance.Add(item);

            if (wasPickedUp)
                Destroy(gameObject);
        }
    }
}
