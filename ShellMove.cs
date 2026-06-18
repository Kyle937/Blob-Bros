using UnityEngine;

public class ShellMove : MonoBehaviour
{
    public int moving;
    public int Direction;
    public float speed;
    public GameObject Turtle;
    public float standTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moving = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == 1)
        {
            standTimer = 3;
            transform.Translate(Vector2.right * Direction * speed * Time.deltaTime);
        }
        else
        {
            standTimer -= Time.deltaTime;
            if (standTimer <= 0)
            {
                Destroy(gameObject);
                Instantiate(Turtle, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            }
        }
    }
    void DirectionChange()
    {
        if (Direction == 1)
        {
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            
        }
        else
        {
            if (moving == 1){
                if (collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<EnemyMove>().hp -= 1;
                }
                else if (collision.gameObject.tag == "Spiked")
                {
                    collision.gameObject.GetComponent<EnemyMove>().hp -= 1;
                }
                else if (collision.gameObject.tag == "Turtle")
                {
                    collision.gameObject.GetComponent<EnemyMove>().hp -= 1; 
                }
                else if (collision.gameObject.tag == "Player")
                {
                    collision.gameObject.GetComponent<PlayerMove>().powerUp -= 1;
                    collision.gameObject.GetComponent<PlayerMove>().hitImunity = 3;
                }
                else
                {
                    DirectionChange();
                }
            }
        }
    }
}
