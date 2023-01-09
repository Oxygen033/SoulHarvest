using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private Sprite State01;
    [SerializeField]
    private Sprite State02;
    [SerializeField]
    private Sprite State03;
    [SerializeField]
    private Sprite State04;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Collider2D coll;
    void Start()
    {
        coll.enabled = false;
    }

    void Update()
    {
        if(Player.GetComponent<CharaController>().Souls >= 15)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = State02;
        }
        if (Player.GetComponent<CharaController>().Souls >= 20)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = State03;
        }
        if (Player.GetComponent<CharaController>().Souls >= 30)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = State04;
            coll.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(1);
    }
}
