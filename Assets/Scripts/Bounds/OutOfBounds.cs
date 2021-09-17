using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: Implement functionality to reset the game somehow. - [DONE]
        // Resetting the game includes destroying the out of bounds ball and creating a new one ready to be launched from the paddle
        GameObject.Find("Ball").GetComponent<Ball>().ResetBall();
    }
}
