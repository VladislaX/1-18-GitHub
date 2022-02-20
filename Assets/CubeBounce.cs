using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeBounce : MonoBehaviour
{
    public PlayerControls Player;
    public TextMeshPro Text;
    private int BlockHealthPointValue;
    public GameObject Object;
    public Game Game;

    private void Awake()
    {
        BlockHealthPointValue = Random.Range(1, 10);
    }
    private void Start()
    {
        
        Text.text = BlockHealthPointValue.ToString();
    }

    internal void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out PlayerControls _))
        {
            BlockHealthPointValue -= 1;
            Player.SnakeHealthPoint -= 1;
            Text.text = (BlockHealthPointValue).ToString();
            Player.Text.text = (Player.SnakeHealthPoint).ToString();
            Player.DestroyBody();
            Player.SnakeRigidbody.GetComponent<ParticleSystem>().Emit (10);
            Game.ScoreCounting();
            if (BlockHealthPointValue == 0)
            {
                Object.SetActive(false);
            }
            if (Player.SnakeHealthPoint == 0)
            {
                Player.Die();
            }
        } 
    }

}
