using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private AudioSource _paddleHit;

    private bool serve = true;  // boolean to indicate serve action
    private bool end = false;  // game ends
    
    private int player2Score = 0;
    private int player1Score = 0;

    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;

    private Vector3 direction1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && serve)
        {
            direction1 = new Vector3(Random.Range(-4.0f, 4f), Random.Range(-8.0f, 8f), 0);
            //direction1 = new Vector3(1, -0.7f, 0f);
            serve = false;

        }

        if (!serve)
        {
            transform.Translate(Time.deltaTime * _speed * direction1);
            if (transform.position.y > 4.8 && direction1.y > 0)
            {
                direction1.y = -direction1.y;
            }

            if (transform.position.y < -4.8 && direction1.y < 0)
            {
                direction1.y = -direction1.y;
            }

            if (transform.position.x < -6.7)
            {
                player2Score++;
                Reset();
                if (player2Score == 15)
                {
                    end = true;
                } else {serve = true;}
                player2ScoreText.text =  player2Score.ToString();
            }

            if (transform.position.x > 6.7)
            {
                player1Score++;
                Reset();
                if (player1Score == 15)
                {
                    end = true;
                } else { serve = true;}
                player1ScoreText.text =  player1Score.ToString();
            }
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        direction1.x = -direction1.x;
        _paddleHit.Play();
    }
    
    private void Reset()
    {
        transform.position = new Vector3(0,0,0);
    }
}
