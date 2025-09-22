using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public void OnPlayerDie()
    {
        Time.timeScale = 0;
        print("Game Over");
    }
}
