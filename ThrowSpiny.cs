using UnityEngine;
public class ThrowSpiny : MonoBehaviour
{
    public GameObject Spiny;
    public float Delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Delay -= Time.deltaTime;
        if (Delay <= 0)
        {
            Delay = 1;
            Delay = UnityEngine.Random.Range(5f, 10f);
            Instantiate(Spiny, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
