using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public GameObject Player;
    public Vector3 playerLocation;
    public Vector3 currentLocation;
    public Vector3 attack;
    public Vector3 jump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentLocation = transform.position;
        playerLocation = Player.gameObject.GetComponent<PlayerMove>().transform.position;
        attack = playerLocation - currentLocation;
        GetComponent<Rigidbody2D>().AddForce(attack);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            GetComponent<Rigidbody2D>().AddForce(jump);
        }
    }
}
