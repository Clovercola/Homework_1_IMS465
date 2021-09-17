using UnityEngine;

public class Paddle : MonoBehaviour
{
    //TODO
    // Move paddle left and right using keyboard keys, mapping is up to you - [DONE]
    // Paddle should be able to launch the ball upon space bar being pressed - [DONE, SEE BELOW AND "BALL" SCRIPT]
    // A launched ball will then bounce around, changing its direction upon any collision - [DONE, SEE "BALL" SCRIPT]

    [SerializeField] private readonly float speed = 5.0f;

    void Update()
    {
        // --- MOVEMENT ---
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime * Vector3.right, Space.World);
        }
        var xPos = Mathf.Clamp(transform.position.x, -7.6f, 7.6f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        // --- LAUNCH BALL ---
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject.Find("Ball").GetComponent<Ball>().LaunchBall();
        }


    }

}
