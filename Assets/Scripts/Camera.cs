using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.I.gameState == GameManager.GAMESTATE.START)
        {

        }
        else if (GameManager.I.gameState == GameManager.GAMESTATE.WIN)
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().Play("Success");
    }
}
