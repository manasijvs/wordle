using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private TextMeshProUGUI text;
    public char letter {get; private set; }
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Setletter(char letter)
    {
        this.letter = letter;
        text.text = letter.ToString();
    }
}


