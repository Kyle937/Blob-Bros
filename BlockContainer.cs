using UnityEngine;

public class BlockContainer : MonoBehaviour
{
    public GameObject Brick;
    public GameObject PowerUp;
    public GameObject PowerUp2;
    public GameObject Player;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(Brick, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            if (Player.gameObject.GetComponent<PlayerMove>().powerUp < 1)
            {
                Instantiate(PowerUp, gameObject.GetComponent<Transform>().position + offset, Quaternion.identity);
            }
            else
            {
                Instantiate(PowerUp2, gameObject.GetComponent<Transform>().position + offset, Quaternion.identity);
            }
        }
    }
}
