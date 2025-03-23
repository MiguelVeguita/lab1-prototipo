using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Vector2 areaMin = new Vector2(-9, -4);
    public Vector2 areaMax = new Vector2(9, 4);
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        GenerateNewPosition(); 

    }
    public void GenerateNewPosition()
    {
        Vector2 newPos;
        bool positionIsValid;

        do
        {
            newPos = new Vector2(
                Mathf.Round(Random.Range(areaMin.x, areaMax.x)),
                Mathf.Round(Random.Range(areaMin.y, areaMax.y))
            );

            // Verifica si la posición está libre (sin colisiones)
            Collider2D hit = Physics2D.OverlapCircle(newPos, 0.4f);
            positionIsValid = (hit == null || hit.gameObject == gameObject);

        } while (!positionIsValid);

        transform.position = newPos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "skane")
        {

            GenerateNewPosition();
            scoreManager.AddScore(10);
        }
        
    }
}
