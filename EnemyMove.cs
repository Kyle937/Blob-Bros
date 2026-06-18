using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int Direction;
    public float speed;
    public Vector3 bounce;
    public int hp;
    public bool winged;
    public bool hasShell;
    public GameObject Shell;
    public bool SingleDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 1)
        {
            Destroy(gameObject);
            if (hasShell)
            {
                Instantiate(Shell, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            }
        }
        transform.Translate(Vector2.right * Direction * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (winged)
            {
                GetComponent<Rigidbody2D>().AddForce(bounce);
            }
        }
        else
        {
            if (SingleDirection == false)
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
        }

    }
}
