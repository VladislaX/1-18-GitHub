using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddSigment : MonoBehaviour
{
    public PlayerControls Player;
    public TextMeshPro Text;
    internal int SigmentHealthPointValue;
    public GameObject Object;
    

    private void Awake()
    {
        SigmentHealthPointValue = Random.Range(2, 7);
    }
    private void Start()
    {

        Text.text = SigmentHealthPointValue.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerControls player))
        {

            Player.SnakeHealthPoint = Player.SnakeHealthPoint + SigmentHealthPointValue;
            Player.Text.text = (Player.SnakeHealthPoint).ToString();
            Object.SetActive (false);
        }
    }


}
