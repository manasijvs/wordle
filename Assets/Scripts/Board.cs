using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Board : MonoBehaviour
{
    //if(Input.GetKeyDown(KeyCode.A))to detect if we pressed A key
    //loop through an array of keys and check one. in c# there is no constatnt array. therefore we use readonly
    private static  readonly KeyCode[] supported_keys = new KeyCode[]
    {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, 
        KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, 
        KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, 
        KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, 
        KeyCode.Y, KeyCode.Z
    };

    private Row[] rows;
    private string[] solutions;
    private string[] validwords;//we pick a random soln and compare it against when we guess. guesses can be any of the valid word.

    //to keep track of which tile we are at
    private int rowindex;
    private int columnindex;

    private void Awake()
    {
        rows = GetComponentsInChildren<Row>();
    }

    private void Start()
    {
        loaddata();
    }

    private void loaddata()
    {
        TextAsset textfile = Resources.Load("official_wordle_all") as TextAsset;
        validwords = textfile.text.Split("\n");//in the file words seperated by new lines

        textfile = Resources.Load("official_wordle_common") as TextAsset;
        solutions = textfile.text.Split("\n");
    }
    private void Update()//for inputs
    {
        Row currentrow = rows[rowindex];
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            columnindex = Mathf.Max(columnindex - 1, 0);
            currentrow.tiles[columnindex].Setletter('\0');
        }
        else if(columnindex >= currentrow.tiles.Length)//to remove array bound exception. if column index greaterthan how many tiles we have in that current row
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                submitrow(currentrow);
            }
        }
        else
        {
            for(int i = 0; i < supported_keys.Length; i++)
            {
                if (Input.GetKeyDown(supported_keys[i]))//access key at that index
                {
                    currentrow.tiles[columnindex].Setletter((char)supported_keys[i]);//explicitly cast it to a char
                    columnindex++;
                    break;//to allow user to press only one letter(key) per frame
                }
            }
        }
    }

    private void submitrow(Row row)
    {
        //...we need to pick a random word from  a dic and compare the guess
    }
}
