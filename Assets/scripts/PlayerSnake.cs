using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSnake : MonoBehaviour
{
    public int Speed;
    private Vector2 direction;
    [SerializeField]private int length;
    public GameObject bodySegmentPrefab;
    private List<GameObject> bodySegments = new List<GameObject>();
    private List<Vector2> positionsHistory = new List<Vector2>();
    public int gapBetweenSegments = 10;
    public GameObject PANEL;

    public void OnMoveUp(InputAction.CallbackContext context)
    {
        if (context.performed) ChangeDirection(Vector2.up);
    }

    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (context.performed) ChangeDirection(Vector2.down);
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.performed) ChangeDirection(Vector2.left);
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.performed) ChangeDirection(Vector2.right);
    }

    void ChangeDirection(Vector2 newDirection)
    {
        if (newDirection != -direction)
        {
            direction = newDirection;
        }
          
    }
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Speed * Time.deltaTime);

        UpdateBodySegments();

        Movement();
    }
    void UpdateBodySegments()
    {
        for (int i = 0; i < bodySegments.Count; i++)
        {
            int targetIndex = (i + 1) * gapBetweenSegments;
            if (targetIndex < positionsHistory.Count)
                bodySegments[i].transform.position = positionsHistory[targetIndex];
        }
    }
    
    void Movement()
    {
        positionsHistory.Insert(0, transform.position);
        transform.Translate(direction * Speed * Time.deltaTime);
    }
   
    void GrowSnake()
    {
        GameObject segment = Instantiate(bodySegmentPrefab);
        bodySegments.Add(segment);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "manzana")
        {

            GrowSnake();
            length++;
            AudioManager.Instance.PlayEatSound();
            
        }
        else if (collision.gameObject.tag =="cuerpito" || collision.gameObject.tag == "pared")
        {
            Debug.Log("Game Over!");
            AudioManager.Instance.PlayGameOverSound();
            PANEL.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
