using UnityEngine;

public class PieceColor : MonoBehaviour
{
    [SerializeField]
    private Sprite blueColor;
    [SerializeField]
    private Sprite redColor;
    [SerializeField]
    private Sprite greenColor;
    [SerializeField]
    private Sprite purpleColor;
    [SerializeField]
    private Sprite goldColor;
    [SerializeField]
    private Sprite greyColor;
    [SerializeField]
    private Sprite brownColor;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        ChooseColor();
    }

    private void ChooseColor()
    {
        //TODO
        // set spriteRenderer.sprite to a random sprite that is present 

        spriteRenderer.sprite = RandomColor();
    }

    private Sprite RandomColor()
    {
        int colorChoice = Random.Range(0, 6);
        switch (colorChoice)
        {
            case 0:
                return blueColor;
            case 1:
                return redColor;
            case 2:
                return greenColor;
            case 3:
                return purpleColor;
            case 4:
                return goldColor;
            case 5:
                return greyColor;
            case 6:
                return brownColor;
            default:
                return blueColor;
        }
    }
}
