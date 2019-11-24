using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
  private bool isSpinning = false;
  private int money;
  public int score;

  public bool GetGameState ()
  {
    return isSpinning;
  }

  public void SetGameState (bool value)
  {
    isSpinning = value;
  }
}