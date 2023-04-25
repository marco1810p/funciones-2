using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
   
    public int livescount;
    public TextMeshProUGUI txtLives;
    public TextMeshProUGUI txtScore;
    public int Score = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        livescount = 3;
        initialPosition = transform.position;
        txtLives.text = livescount.ToString();
        txtScore.text = Score.ToString();
    }

    private void Update()
    {
        
    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("damager"))
        {
            LoseALife();

        } else if (collision.gameObject.CompareTag("coin"))
        {
            ScorePoint();
            Destroy(collision.gameObject);
        } 
    }

    void LoseALife()
    {
        transform.position = initialPosition;
        livescount--;

        if (livescount == 0)
        {
            PlayerDeath();
        }
        txtLives.text = livescount.ToString();
    }

    void PlayerDeath()
    {
        Destroy(gameObject);
    }

    void ScorePoint()
    {
       
        Score++;
        Debug.Log("Tiene la llave");
        txtScore.text = Score.ToString();
    }
}
