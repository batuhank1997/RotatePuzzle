using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GAMESTATE { WIN, LOOSE, START}

    public GAMESTATE gameState;
    public List<GameObject> gears;
    public GameObject winScreen;

    private void Awake()
    {
        II = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GAMESTATE.START;
    }

    // Update is called once per frame
    void Update()
    {
        if (gears.Count == 1)
            gameState = GAMESTATE.WIN;

        Sort(gears);

        if(gameState == GAMESTATE.WIN)
        {
            winScreen.SetActive(true);
        }
    }

    void Sort(List<GameObject> gears)
    {
        GameObject temp;

        for (int i = 0; i < gears.Count; i++)
        {
            for (int j = 0; j < gears.Count - 1; j++)
            {
                if (gears[j].transform.position.y < gears[j + 1].transform.position.y)
                {
                    temp = gears[j + 1];
                    gears[j + 1] = gears[j];
                    gears[j] = temp;
                }
            }
            
        }
    }

    public static GameManager II;
    public static GameManager I
    {
        get
        {
            if(II == null)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            return II;
        }
    }
}
