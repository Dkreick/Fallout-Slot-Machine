using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
  private bool isSpinning;
  private int money;
  public int score;
  public Button spinButton;
  public GameObject lastColumn;

  void Update ()
  {
    if (isSpinning && lastColumn.GetComponent<ColumnHandler> ().GetState())
    {
      SetGameState (false);
    }
  }

  public bool GetGameState ()
  {
    return isSpinning;
  }

  public void SetGameState (bool value)
  {
    isSpinning = value;

    if (isSpinning)
    {
      spinButton.interactable = false;
    }
    else
    {
      spinButton.interactable = true;
      lastColumn.GetComponent<ColumnHandler> ().SetState(false);
    }
  }
}