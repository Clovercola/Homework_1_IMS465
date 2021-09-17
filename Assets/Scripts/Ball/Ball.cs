using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody = null;

    private bool canLaunch = true;
    private Vector3 movement = Vector3.zero;
    private readonly float speed = 7.0f;

    //TODO: Add code to move ball along with code to delete pieces upon colliding with one
    //Ball should only move once its been launched

    //Ball Launches and Moves - [DONE]
    //Ball collides with other gameobjects - [DONE]
    //Ball deletes pieces it collides with - [DONE]

    void Update()
    {
        if (canLaunch == true)
        {
            Vector3 holdPos = GameObject.Find("Paddle").transform.position;
            holdPos.y += 0.35f;
            transform.position = holdPos;
        }

        var xPos = Mathf.Clamp(transform.position.x, -8.65f, 8.65f);
        var yPos = Mathf.Clamp(transform.position.y, -6f, 4.9f);
        if (transform.position.x < -8.65f || transform.position.x > 8.65f) 
        {
            movement.x *= -1;
        }
        if (transform.position.y >= 4.7f)
        {
            movement.y *= -1;
        }
        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }

    void FixedUpdate()
    {
        var newDirection = speed * Time.deltaTime * movement;
        rigidBody.MovePosition(transform.position + newDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movement = Vector2.Reflect(movement, collision.contacts[0].normal);
        //Debug.Log(collision.collider);
        if (collision.collider.CompareTag("Piece"))
        {
            Object.Destroy(collision.collider.gameObject);
        }
    }

    public bool LaunchBall() { 
        if (canLaunch == true)
        {
            //Launch
            movement = new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 5f), 0).normalized;
            canLaunch = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetBall()
    {
        movement = Vector3.zero;
        canLaunch = true;
    }

}
