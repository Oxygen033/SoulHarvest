using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class HarvestPlace : MonoBehaviour
{
    [SerializeField]
    private enum Culture {a, b, c}
    [SerializeField]
    private Sprite SpriteEmpty;
    [SerializeField]
    private Sprite SpriteActive;
    [SerializeField]
    private Sprite SpriteGrowing;
    [SerializeField]
    private Collider2D Collider;
    private bool IsGrown, IsEmpty;
    private GameObject Player;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (IsEmpty && Player.GetComponent<CharaController>().SealedSouls > 0)
            {
                Plant();
            }
            else if (IsGrown)
            {
                StartCoroutine(Harvest());
            }
        }
    }

    private IEnumerator Grow(int time)
    {
        yield return new WaitForSeconds(10);
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteActive;
        IsGrown = true;
        yield return null;
    }

    private void Plant()
    {
        IsEmpty = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteGrowing;
        Player.GetComponent<CharaController>().SealedSouls--;
        StartCoroutine(Grow(10));
    }

    private IEnumerator Harvest()
    {
        Player.GetComponent<CharaController>().Souls += 2;
        IsGrown = false;
        IsEmpty = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteEmpty;
        yield return new WaitForSeconds(0.05f); //Little delay to prevent instantly planting
        yield return null;
    }
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        IsEmpty = true;
    }
}
