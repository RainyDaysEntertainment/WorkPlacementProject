using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    //public string npcName;
    public float radius = 2f, dis;
    public QuestGiver questGiver;
    Quest item;
    public Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        //questGiver = GameObject.Find(npcName).GetComponent<QuestGiver>();

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
            QuestInv.instance.Add(item);

            Destroy(gameObject);
        }
    }
}
