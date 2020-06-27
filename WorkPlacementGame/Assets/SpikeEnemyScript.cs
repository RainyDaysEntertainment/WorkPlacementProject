using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemyScript : MonoBehaviour
{
    public LeanTweenType easeType;

    void Start()
    {
        
        LeanTween.moveY(gameObject, gameObject.transform.position.y + 1, 1).setLoopPingPong().setEase(easeType);
    }
    
    void Update()
    {
    }
}
