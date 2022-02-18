using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Transform SnakeHead;
    public CameraWatcher CurrentTrigger;
    public float MouseSensitivity;
    private Vector3 _previousMousePosition;
    public Rigidbody SnakeRigidbody;
    public float SnakeSpeed;
    public Game Game;
    internal int SnakeHealthPoint;
    public TextMeshPro Text;
    internal int BodyOffset;
    public GameObject[] Body;
    

    private void Awake()
    {
        Movement();
        SnakeHealthPoint = 1;
    }
    private void Start()
    {
        Text.text = (SnakeHealthPoint).ToString();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            SnakeHead.Rotate (0, delta.x * MouseSensitivity, 0);
        }
        
        _previousMousePosition = Input.mousePosition;
        
        if (SnakeHead.position.x <= -3.5f)
        {
            Vector3 LeftWall = new Vector3 (-3.5f, SnakeHead.transform.position.y, SnakeHead.transform.position.z);
            SnakeHead.position = LeftWall;
        }
        if (SnakeHead.position.x >= 0.25f)
        {
            Vector3 RightWall = new Vector3(0.25f, SnakeHead.transform.position.y, SnakeHead.transform.position.z);
            SnakeHead.position = RightWall;
        }

        
        Movement();
    }
    public void ReachFinish()
    {
        Game.OnPlayerReackFinish();
        SnakeRigidbody.velocity = Vector3.zero;
    }

       public void Die()
    {
        Game.OnPlayerDied();
        SnakeRigidbody.velocity = Vector3.zero;

    }
    public void Movement()
    {
        SnakeRigidbody.velocity = Vector3.forward * SnakeSpeed;
    }
    public void AddBody()
    {
        if (SnakeHealthPoint > 1 )
        {
            int BodyOffset = SnakeHealthPoint;
            for (int i = 1; i < BodyOffset; i++) 
            {
                if (i >= 10)
                {
                    BodyOffset = 10;
                }
                Body[i].SetActive(true);
                Body[i].transform.position = SnakeRigidbody.transform.position + SigmentOffsetPosition(i);
                

            }

        }

    }
    public void DestroyBody ()
    {
        if (SnakeHealthPoint < 10)
        {
            int BodyOffset = SnakeHealthPoint;
            for (int i = BodyOffset; i > 0; i--)
            {
                
                Body[BodyOffset].SetActive(false);
                
            } return;
            
        }
        if (SnakeHealthPoint <= 1)
        {
            Body[1].SetActive(false);
        }
    }

    private Vector3 SigmentOffsetPosition(int i)
    {
       return new Vector3 (0, 0, -i * 1.1f);
    }

   

}
