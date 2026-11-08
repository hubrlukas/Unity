using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;

    private Rigidbody rb;
    private int count;
    private float movementX; 
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
        if ( count >= 12 ) 
        {
            countText.gameObject.SetActive(false);
            gameObject.SetActive(false);
            FindAnyObjectByType<GameManager>().TriggerWin();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter( Collider other )
    {
        if ( other.gameObject.CompareTag( "PickUp" ) ) 
        {
            other.gameObject.SetActive( false );
            ++count;
            SetCountText();
        }
    }

    private void OnCollisionEnter( Collision collision ) 
    {
        if ( collision.gameObject.CompareTag("Enemy") ) 
        {
            FindAnyObjectByType<GameManager>().TriggerLose();
            gameObject.SetActive(false);
            countText.gameObject.SetActive(false);
        }
    }
}
