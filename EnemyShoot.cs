using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public GameObject SpawnPoint;
    public GameObject Player;
    public float playerX;
    public float currentX;
    public float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        cooldown = 3;
    }

    // Update is called once per frame
    void Update()
    {
        currentX = transform.position.x;
        playerX = Player.gameObject.GetComponent<PlayerMove>().transform.position.x;
        if (Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(Left, SpawnPoint.GetComponent<Transform>().position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(Right, SpawnPoint.GetComponent<Transform>().position, Quaternion.identity);
        }
        if (cooldown <= 0){
            if (Mathf.Abs(currentX - playerX) > 1)
            {
                cooldown = 3;
                if (currentX > playerX)
                {
                    Instantiate(Left, SpawnPoint.GetComponent<Transform>().position, Quaternion.identity);
                }
                else if (currentX < playerX)
                {
                    Instantiate(Right, SpawnPoint.GetComponent<Transform>().position, Quaternion.identity);
                }
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
