using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float ROW_HEIGHT = 0.48f;
    public const int PIECE_COUNT_PER_ROW = 13;
    public const float PIECE_LENGTH = 0.96f;
    public const int TOTAL_ROWS = 10;

    [SerializeField]
    private Transform pieces = null;

    [SerializeField]
    private GameObject piecePrefab = null;

    [SerializeField]
    private EdgeCollider2D border;


    //TODO
    //Using const data defined above "Instantiate" new pieces to fill the view with
    public void Awake()
    {
        Vector3 loc = new Vector3(-6f, 4, 0);
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles.Set(0, 0, 0);
        for (int i = 0; i < TOTAL_ROWS; i++)
        {
            FillRow(loc, rotation);
            loc.y -= 0.5f;
        }
    }

    private void FillRow(Vector3 loc, Quaternion rotation)
    {
        for (int i = 0; i < PIECE_COUNT_PER_ROW; i++)
        {
            Object.Instantiate(piecePrefab, loc, rotation);
            loc.x += 1f;
        }
        

    }

}
