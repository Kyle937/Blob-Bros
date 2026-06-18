using UnityEngine;

public class PowerUpMove : MonoBehaviour
{
    public int Direction;
    public float speed;
    public Vector3 bounce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Direction * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            GetComponent<Rigidbody2D>().AddForce(bounce);
        }
        else
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
