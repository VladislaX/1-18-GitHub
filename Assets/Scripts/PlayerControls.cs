using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Transform SnakeHead;
    public float MouseSensitivity;
    private Vector3 _previousMousePosition;
    public Rigidbody SnakeRigidbody;
    public float SnakeSpeed;
    

    private void Awake()
    {
        SnakeRigidbody.velocity = Vector3.forward*SnakeSpeed;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            SnakeHead.Rotate (0, -delta.x * MouseSensitivity, 0);
        }
      
        

        _previousMousePosition = Input.mousePosition;
    }
}
