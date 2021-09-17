using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody = null;

    private bool canLaunch = true;
    private Vector3 movement = Vector3.zero;
    private readonly float speed = 5.0f;

    //TODO: Add code to move ball along with code to delete pieces upon colliding with one
    //Ball should only move once its been launched

    //Ball Launches and Moves - [DONE]
    //Ball collides with other gameobjects - [DONE]

    void Update()
    {
        if (canLaunch == true)
        {
            Vector3 holdPos = GameObject.Find("Paddle").transform.position;
            holdPos.y += 0.35f;
            transform.position = holdPos;
        }

        var xPos = Mathf.Clamp(transform.position.x, -8.65f, 8.65f);
        if (transform.position.x < -8.65f || transform.position.x > 8.65f)
        {
            movement.x *= -1;
        }
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        var newDirection = movement * Time.deltaTime * speed;
        rigidBody.MovePosition(transform.position + newDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movement = Vector2.Reflect(movement, collision.contacts[0].normal);
    }

    public bool LaunchBall() { 
        if (canLaunch == true)
        {
            //Launch
            movement = new Vector3(Random.Range(-5f, 5f), Random.Range(1f, 5f), 0).normalized;
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
