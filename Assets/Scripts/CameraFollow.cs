using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerControls Player;
    public Vector3 CameraOffset;
    public float CameraSpeed;

    void Update()
    {
        if (Player.CurrentTrigger == null) return;

        Vector3 targetposition = Player.SnakeRigidbody.transform.position + CameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetposition, CameraSpeed * Time.deltaTime); 
    }
}
