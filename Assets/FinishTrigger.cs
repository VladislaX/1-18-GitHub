using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{

    public PlayerControls Player;
 
    
    private void OnTriggerEnter(Collider finish)
    {
       if (finish.transform.position.z == Player.SnakeRigidbody.transform.position.z)
        {
            Player.ReachFinish();
        }
    }

}
