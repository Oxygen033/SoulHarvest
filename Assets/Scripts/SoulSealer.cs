using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSealer : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, gameObject.transform.position) < 2 && Input.GetKeyDown(KeyCode.E) && Player.GetComponent<CharaController>().Souls > 0 && Player.GetComponent<CharaController>().Sculls > 0)
        {
            Player.GetComponent<CharaController>().SealedSouls++;
            Player.GetComponent<CharaController>().Souls--;
            Player.GetComponent<CharaController>().Sculls--;
        }
    }
}
