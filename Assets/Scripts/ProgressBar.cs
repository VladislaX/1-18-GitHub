using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public PlayerControls Player;
    public Transform Finish;
    public Slider Slider;
    private float startZ;
    private float minReachedZ;

    private void Start()
    {
        startZ = Player.SnakeRigidbody.transform.position.z;
    }
    private void Update()
    {
        minReachedZ = Mathf.Max(minReachedZ, Player.SnakeRigidbody.transform.position.z);
        float finishY = Finish.transform.position.z;
        float t = Mathf.InverseLerp(startZ, finishY, minReachedZ);
        Slider.value = t;
    }
}
