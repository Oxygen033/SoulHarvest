using System;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    private GameObject Player;
    public enum ObjType
    {
        Soul,
        Skull
    }
    public ObjType Type;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        if (Type == ObjType.Soul)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Soul_01");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/dev_scull");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (Type == ObjType.Soul)
        {
            Player.GetComponent<CharaController>().Souls++;
        }
        else
        {
            Player.GetComponent<CharaController>().Sculls++;
        }

        Destroy(gameObject);
    }
}
