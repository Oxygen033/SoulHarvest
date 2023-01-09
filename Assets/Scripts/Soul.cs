using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Player.GetComponent<CharaController>().Sculls += 1;
        Destroy(gameObject);
    }
}
