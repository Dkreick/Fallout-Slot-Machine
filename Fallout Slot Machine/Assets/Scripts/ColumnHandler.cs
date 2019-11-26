using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnHandler : MonoBehaviour
{
  [SerializeField]
  public float spinSpeed;
  private int spinTime;
  public int columnHeight;
  public int startSpinningTime;
  private GameData gameData;
  private bool isColumnSpinning;
  public bool isColumnFinished = false;

  void Start ()
  {
    spinTime = Random.Range (2, 4);
  }

  void Update ()
  {
    if (FindObjectOfType<GameData> ().GetGameState () && isColumnFinished == false)
    {
      if (!isColumnSpinning)
      {
        StartCoroutine (ActivateColumn ());
      }
      else
      {
        MoveItems ();
      }
    }
  }

  IEnumerator ActivateColumn ()
  {
    yield return new WaitForSeconds (startSpinningTime);
    isColumnSpinning = true;
    StartCoroutine (DeactivateColumn ());
  }

  IEnumerator DeactivateColumn ()
  {
    float timeRemaining = 0;
    while (timeRemaining <= 1f)
    {
      timeRemaining += Time.deltaTime / spinTime;
      yield return null;
    }
    isColumnSpinning = false;
    SetState(false);
  }

  void MoveItems ()
  {
    foreach (Transform item in transform)
    {
      float speed = spinSpeed * Time.deltaTime;
      item.transform.Translate (Vector3.down * speed);

      if (item.transform.position.y <= -4)
      {
        item.transform.position = new Vector3 (transform.position.x, columnHeight, transform.position.z);
      }
    }
  }

  public bool GetState ()
  {
    return isColumnFinished;
  }

  public void SetState (bool value)
  {
    isColumnFinished = value;
  }
}