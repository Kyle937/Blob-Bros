using UnityEngine;

public class EnemyMove3 : MonoBehaviour
{
    public int direction;
    public float move;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move <= 0)
        {
            if (direction == -1)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer += Time.deltaTime;
            }
            if (timer >= 0.5f)
            {
                direction = -1;
                move = 2;
            }
            else if (timer <= 0)
            {
                direction = 1;
                move = 5;
            }
            transform.Translate(Vector2.up * Time.deltaTime * direction);
        }
        else
        {
            move -= Time.deltaTime;
        }
    }
}
