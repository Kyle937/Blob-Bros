using UnityEngine;

public class projectileScript : MonoBehaviour
{
    public Vector3 projectileMove;
    public Vector3 bounce;
    public Vector3 Toss;
    public float xMove;
    public float projectileTimer;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        GetComponent<Rigidbody2D>().AddForce(Toss);
        
    }

    // Update is called once per frame
    void Update()
    {
        projectileMove = new Vector3(xMove,0);
        GetComponent<Transform>().position += projectileMove;
        projectileTimer -= Time.deltaTime;
        if(projectileTimer < 0)
        {
            player.gameObject.GetComponent<PlayerMove>().Fireballs -= 1;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            GetComponent<Rigidbody2D>().AddForce(bounce);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            player.gameObject.GetComponent<PlayerMove>().Fireballs -= 1;
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyMove>().hp -= 1;
        }
        if (collision.gameObject.tag == "Spiked")
        {
            player.gameObject.GetComponent<PlayerMove>().Fireballs -= 1;
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyMove>().hp -= 1;
        }
        if (collision.gameObject.tag == "Turtle")
        {
            player.gameObject.GetComponent<PlayerMove>().Fireballs -= 1;
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyMove>().hp -= 1; 
        }
        if (collision.gameObject.tag == "Shell")
        {
            player.gameObject.GetComponent<PlayerMove>().Fireballs -= 1;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
