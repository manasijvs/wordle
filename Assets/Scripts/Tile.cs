using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public class state
    {
        public Color fillColoor;
        public Color outlinecolor;
    }
    

    public state states {get; private set;}
    public char letter {get; private set; }
    private TextMeshProUGUI text;
    private Image fill;
    private Outline outline;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Setletter(char letter)
    {
        this.letter = letter;
        text.text = letter.ToString();
    }

    public void setstate(state stata)
    {
        this.stata = stata;
    }
}


