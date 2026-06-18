using UnityEngine;

public class PursuePlayer : MonoBehaviour
{
    public GameObject Player;
    public float playerX;
    public float currentX;
    public Vector3 Left;
    public Vector3 Right;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentX = transform.position.x;
        playerX = Player.gameObject.GetComponent<PlayerMove>().transform.position.x;
        if (currentX > playerX)
        {
            GetComponent<Rigidbody2D>().AddForce(Left);
        }
        else if (currentX < playerX)
        {
            GetComponent<Rigidbody2D>().AddForce(Right);
        }
    }
}
