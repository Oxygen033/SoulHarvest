using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Counters : MonoBehaviour
{
    [SerializeField]private GameObject Player;
    [SerializeField]private Text SoulCounter;
    [SerializeField]private Text ScullCounter;
    [SerializeField] private Text SealedSoulsCounter;
    void Update()
    {
        SoulCounter.text = Player.GetComponent<CharaController>().Souls.ToString();
        ScullCounter.text = Player.GetComponent<CharaController>().Sculls.ToString();
        SealedSoulsCounter.text = Player.GetComponent<CharaController>().SealedSouls.ToString();
    }
}
