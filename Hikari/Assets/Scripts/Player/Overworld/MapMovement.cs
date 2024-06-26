using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed;
    [SerializeField] Animator Animation;
    [SerializeField] SpriteRenderer Renderer;
    private float Horizontal;
    private float Vertical;
    private GameObject SoundManager;

    void Start()
    {
        SoundManager =  GameObject.Find("SoundManager");
        SoundManager.SendMessage("StopPunch");
    }
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");//I AM THE BEST OF THE BEST IN TERMS OF PROGRAMING PROESS
        Vertical = Input.GetAxisRaw("Vertical");
        SoundManager.SendMessage("PlayWalk",true);
        if (Vertical > 0)
        {
            Animation.SetBool("MovingUp", true);
            Animation.SetBool("MovingDown", false);
            Animation.SetBool("MovingSide", false);
        }
        else if (Vertical < 0)
        {
            Animation.SetBool("MovingUp", false);
            Animation.SetBool("MovingDown", true);
            Animation.SetBool("MovingSide", false);
        }
        else if (Horizontal > 0)
        {
            Animation.SetBool("MovingSide", true);
            Animation.SetBool("MovingUp", false);
            Animation.SetBool("MovingDown", false);
            Renderer.flipX = true;
        }
        else if (Horizontal < 0)
        {
            Animation.SetBool("MovingSide", true);
            Animation.SetBool("MovingUp", false);
            Animation.SetBool("MovingDown", false);
            Renderer.flipX = false;
        }
        else
        {
            Animation.SetBool("MovingSide", false);
            Animation.SetBool("MovingUp", false);
            Animation.SetBool("MovingDown", false);
            SoundManager.SendMessage("PlayWalk",false);
        }
    }
    void FixedUpdate()
    {
        body.velocity = new Vector2 (speed*Horizontal, speed*Vertical);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("House"))
        {
        GameObject SceneTran =  GameObject.Find("SceneManager");
        SceneTran.SendMessage("StartTran",7);
        }
    }
}
