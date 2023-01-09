using System.Collections;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class ItemSpawnPlace : MonoBehaviour
{
    private GameObject Player;
    private enum SpawnType
    {
        Soul,
        Scull
    }
    [SerializeField]
    private GameObject Scull; 
    [SerializeField]
    private GameObject Soul;
    [SerializeField]
    private SpawnType Type;
    private IEnumerator SpawnObject()
    {
        if (transform.childCount == 0)
        {
            if (Type == SpawnType.Scull)
            {
                GameObject NewObj = Instantiate(Scull,
                    new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.identity) as GameObject;
                NewObj.transform.parent = gameObject.transform;
            }

            if (Type == SpawnType.Soul)
            {
                GameObject NewObj = Instantiate(Soul,
                    new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.identity) as GameObject;
                NewObj.transform.parent = gameObject.transform;
            }
        }

        yield return new WaitForSeconds(Random.Range(20, 30) * Player.GetComponent<CharaController>().PowerUpCoeff);
        StartCoroutine(SpawnObject());
        yield return null;
    }
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        StartCoroutine(SpawnObject());
    }
}
