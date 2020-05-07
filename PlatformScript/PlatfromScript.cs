
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromScript : MonoBehaviour
{
    public float move_Speed = 2f;
    public float bound_Y = 6f;

    public bool moving_Platform_Left, moving_Platform_Right,isBreak, isSpike, is_Platform;
    private Animator anim;
    private void Awake()
    {
        if (isBreak)
            anim = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }
    void BreakableDeactivete()
    {
        Invoke("DeactiveateGameObject", 0.5f);
    }
    void DeactiveateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isSpike)
            {
                collision.transform.position = new Vector2(1000f, 1000f);
                GameManager.instance.RestartGame();
                SoundManager.instance.GameOverSound();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (isBreak)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if (is_Platform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (moving_Platform_Left)
            {
                collision.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if (moving_Platform_Right)
            {
                collision.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }
}
