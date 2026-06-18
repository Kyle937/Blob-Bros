using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public Vector3 rightMoveForce;
    public Vector3 leftMoveForce;
    public Vector3 jumpForce;
    public bool canJump;
    public bool pain;
    public bool playing;
    public GameObject projectile;
    public GameObject leftSpawn;
    public GameObject rightSpawn;
    public float recoil;
    public float invincibility;
    public float hitImunity;
    public float blink;
    public float blink2;
    public int Fireballs;
    public int lives;
    public int coins;
    public int playerFacing;
    public int powerUp;
    public TextMeshProUGUI liveUI;
    public TextMeshProUGUI coinUI;
    public TextMeshProUGUI powerUpUI;
    public TextMeshProUGUI endUI;
    public string eye;
    public string mouth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playing = true;
        transform.position = GameObject.Find("SpawnPoint").GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        liveUI.text = "lives: " + lives;

        coinUI.text = "" + coins + " :coins";

        powerUpUI.text = eye + mouth + eye;

        if (blink2 <= 0){
        if (blink > 0){
            if (lives == 0){eye = "T";}
            else if (lives == 1){eye = "°";}
            else if (lives < 99){eye = "'";}
            else {eye = "^";}
            blink -= Time.deltaTime;}
        else {eye = "‾"; blink2 = 0.2f;}}
        else{blink2-=Time.deltaTime;blink=1f;}

        if (lives == 0){mouth = "A";}
        else{
        if (invincibility > 0f){mouth = "w";}
        else if (hitImunity > 0){
            if (pain == false){mouth = "u";}
            else{mouth = "o";}}
        else if (powerUp == 0){mouth = "~";}
        else if (powerUp == 1){mouth = "-";}
        else if (powerUp == 2){mouth = "v";}}

        if (playing)
        {
            if (lives <= 0){
                playing = false;
                endUI.text = "GAME OVER";}
            if (coins >= 100){
                coins -= 100;
                lives += 1;}
            if (lives >= 100){lives = 99;}
            if (invincibility > 0f){
                invincibility -= Time.deltaTime;
                hitImunity = 1;}
            if (hitImunity > 0){hitImunity -= Time.deltaTime;}
            else{pain = false;}
            if (powerUp == -1){
                lives -= 1;
                powerUp = 0;
                transform.position = GameObject.Find("SpawnPoint").GetComponent<Transform>().position;}
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Fireballs < 2){
                    if (powerUp == 2)
                    {
                        Fireballs +=1;
                        fireball(playerFacing);
                    }
                }
            }
            if (Input.GetKey(KeyCode.D))
            { 
                playerFacing = 1;
                GetComponent<Rigidbody2D>().AddForce(rightMoveForce);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerFacing = -1;
                GetComponent<Rigidbody2D>().AddForce(leftMoveForce);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(canJump)
                {
                    canJump = false;
                    GetComponent<Rigidbody2D>().AddForce(jumpForce); 
                }
            }
        }
        else
        {     
            playerFacing = 1;
            GetComponent<Rigidbody2D>().AddForce(rightMoveForce);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){unstuck();}
    }
    public void unstuck(){transform.position+= new Vector3(0,0.1f,0);}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playing)
        {
            if (collision.gameObject.tag == "warp1")
            {
                transform.position = GameObject.Find("TelePoint1").GetComponent<Transform>().position;
            }
            if (collision.gameObject.tag == "warp2")
            {
                transform.position = GameObject.Find("TelePoint2").GetComponent<Transform>().position;
            }
            if (collision.gameObject.tag == "Fire")
            {
                powerUp -= 1;
                hitImunity = 3;
            }
            if (collision.gameObject.tag == "Rocket")
            {
                powerUp -= 1;
                hitImunity = 3;
            }
            if (collision.gameObject.tag == "Water")
            {
                canJump = true;
            }
            if (collision.gameObject.tag == "Goal")
            {
                playing = false;
                endUI.text = "YOU WIN";
            }
            if (collision.gameObject.tag == "GoalTop")
            {
                lives += 1;
                playing = false;
                endUI.text = "YOU WIN";
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playing)
        {
            if (collision.gameObject.tag == "Floor")
            {
                canJump = true;
            }
            if (collision.gameObject.tag == "Bricks")
            {
                canJump = true;
            }
            if (collision.gameObject.tag == "Wall")
            {
                canJump = true;
            }
            if (collision.gameObject.tag == "Power Up 1")
            {
                Destroy(collision.gameObject);
                if (powerUp == 0)
                {
                    powerUp = 1;
                }
            }
            if (collision.gameObject.tag == "Power Up 2")
            {
                Destroy(collision.gameObject);
                if (powerUp <= 2)
                {
                    powerUp = 2;
                }
            }
            if (collision.gameObject.tag == "Power Up 3")
            {
                invincibility = 10f;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Power Up 4")
            {
                lives += 1;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Coin")
            {
                coins += 1;
                Destroy(collision.gameObject);
            }
            if (hitImunity <= 0){
                if (collision.gameObject.tag == "Enemy")
                {
                    powerUp -= 1;
                    hitImunity = 3;
                    pain = true;
                }
                if (collision.gameObject.tag == "Spiked")
                {
                    powerUp -= 1;
                    hitImunity = 3;
                    pain = true;
                }
                if (collision.gameObject.tag == "Turtle")
                {
                    powerUp -= 1;
                    hitImunity = 3;
                    pain = true;
                }
            }
        }
    }
    void fireball(int dir)
    {
        if(dir == 1)
        {
            projectile.GetComponent<projectileScript>().xMove = .0025f;
            Instantiate(projectile, rightSpawn.GetComponent<Transform>().position, Quaternion.identity);
            GetComponent<Rigidbody2D>().AddForce(leftMoveForce * recoil);
        }
        if(dir == -1)
        {
            projectile.GetComponent<projectileScript>().xMove = -.0025f;
            Instantiate(projectile, leftSpawn.GetComponent<Transform>().position, Quaternion.identity);
            GetComponent<Rigidbody2D>().AddForce(rightMoveForce * recoil);
        }
    }
}
