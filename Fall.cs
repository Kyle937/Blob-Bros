using UnityEngine;

public class Fall : MonoBehaviour
{
    public GameObject Shell;
    public GameObject Player;
    public float playerX;
    public float currentX;
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
        if (Mathf.Abs(currentX - playerX) < 0.1)
        {
            Destroy(gameObject);
            Instantiate(Shell, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
