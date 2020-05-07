using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float min_X = -2.6f, max_x = 2.6f, min_Y = -5.6f;
    private bool out_Of_Bounds;

    void Update()
    {
        CheckBounds();
    }
    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > max_x)
            temp.x = max_x;
        if (temp.x < min_X)
            temp.x = min_X;

        transform.position = temp;

        if(temp.y <= min_Y)
        {
            if (!out_Of_Bounds)
            {
                out_Of_Bounds = true;
                GameManager.instance.RestartGame();
                SoundManager.instance.DeathSound();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            GameManager.instance.RestartGame();
            SoundManager.instance.DeathSound();
        }
    }
}
