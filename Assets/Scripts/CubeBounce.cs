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

    public AudioClip _bounceAudio;
    private AudioSource _audio;
    [Min(0)]
    public float BounceVolume;
    
    
    
    

    private void Awake()
    {
        BlockHealthPointValue = Random.Range(1, 10);
        _audio = GetComponent<AudioSource>();
        
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
            BounceAudio();
            if (BlockHealthPointValue == 0)
            {
                Object.SetActive(false);
                Player.BlockCrushAudio();
            }
            if (Player.SnakeHealthPoint == 0)
            {
                Player.Die();
            }
        } 
    }
    public void BounceAudio()
    {
        _audio.PlayOneShot(_bounceAudio, BounceVolume);
    }
   
}
