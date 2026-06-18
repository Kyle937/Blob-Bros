using UnityEngine;

public class SpikeBallLand : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 toss;
    public int direction;
    public float move;
    public Vector3 Move2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = UnityEngine.Random.Range(1, 3);
        if (direction > 1)
        {
            direction = -1;
        }
        move = UnityEngine.Random.Range(3f, 5f);
        GetComponent<Rigidbody2D>().AddForce(Move2 * move * direction);
        GetComponent<Rigidbody2D>().AddForce(toss);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Lakito")
        {
            Destroy(gameObject);
            Instantiate(enemy, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
