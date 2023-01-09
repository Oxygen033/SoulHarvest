using System.Collections;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rbody;
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private Sprite State2;
    [SerializeField]
    private Sprite State3;

    public int Souls;
    public int Sculls;
    public int SealedSouls;
    public float PowerUpCoeff = 1.0f;

    void Start()
    {
        Souls = 0;
        Sculls = 0;
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rbody.MovePosition(transform.position + new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rbody.MovePosition(transform.position + new Vector3(0, -1, 0) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rbody.MovePosition(transform.position + new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rbody.MovePosition(transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
        if(Souls >= 15)
        {
            PowerUpCoeff = 0.9f;
        }
        if(Souls >= 20)
        {
            PowerUpCoeff = 0.8f;
            gameObject.GetComponent<SpriteRenderer>().sprite = State2;
        }
        if(Souls >= 30)
        {
            PowerUpCoeff = 0.7f;
            gameObject.GetComponent<SpriteRenderer>().sprite = State3;
        }
    }
}