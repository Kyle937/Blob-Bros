using UnityEngine;

public class Stomp : MonoBehaviour
{
    public GameObject player;
    public Vector3 jumpForce;
    public int combo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            collision.gameObject.GetComponent<EnemyMove>().hp -= 1;
            player.gameObject.GetComponent<PlayerMove>().GetComponent<Rigidbody2D>().AddForce(jumpForce); 
            player.gameObject.GetComponent<PlayerMove>().hitImunity = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            combo = 0;
        }
        else if (collision.gameObject.tag == "Wall")
        {
            combo = 0;
        }
        else
        {
            combo += 1;
            if (combo >= 10)
            {
                player.gameObject.GetComponent<PlayerMove>().coins += 1;
            }
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyMove>().hp -= 1;
                player.gameObject.GetComponent<PlayerMove>().GetComponent<Rigidbody2D>().AddForce(jumpForce); 
                player.gameObject.GetComponent<PlayerMove>().hitImunity = 1;
            }
            if (collision.gameObject.tag == "Spiked")
            {
                player.gameObject.GetComponent<PlayerMove>().GetComponent<Rigidbody2D>().AddForce(jumpForce);
            }
            if (collision.gameObject.tag == "Turtle")
            {
                player.gameObject.GetComponent<PlayerMove>().GetComponent<Rigidbody2D>().AddForce(jumpForce); 
                player.gameObject.GetComponent<PlayerMove>().hitImunity = 1;
                collision.gameObject.GetComponent<EnemyMove>().hp -= 1;
            }
            if (collision.gameObject.tag == "Shell")
            {
                player.gameObject.GetComponent<PlayerMove>().hitImunity = 1;
                player.gameObject.GetComponent<PlayerMove>().GetComponent<Rigidbody2D>().AddForce(jumpForce);
                collision.gameObject.GetComponent<ShellMove>().Direction = player.gameObject.GetComponent<PlayerMove>().playerFacing;
                if (collision.gameObject.GetComponent<ShellMove>().moving == 1)
                {
                    collision.gameObject.GetComponent<ShellMove>().moving = 0;
                }
                else
                {
                    collision.gameObject.GetComponent<ShellMove>().moving = 1;
                }
                if (combo >= 20)
                {
                    player.gameObject.GetComponent<PlayerMove>().lives += 1;
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
