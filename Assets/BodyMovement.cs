using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    public PlayerControls Player;
    public Transform PreviosSigment;


    void Awake()
    {



    }


    void Update()
    {
        
        Vector3 Offset = new Vector3(PreviosSigment.transform.position.x, PreviosSigment.transform.position.y, PreviosSigment.transform.position.z -1f);
        transform.position = Vector3.Lerp(transform.position, Offset, 1.5f*Player.SnakeSpeed * Time.deltaTime);
    }
    
}
