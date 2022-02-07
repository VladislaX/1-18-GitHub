using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWatcher : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerControls player))
        {
            player.CurrentTrigger = this;
        }
    }
}
