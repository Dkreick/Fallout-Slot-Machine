using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnHandler : MonoBehaviour
{
  [SerializeField]
  public float spinSpeed;
  public int columnHeight;
  public int lowerEdge;
  private bool IsSpinning = true;

  void Start ()
  {

  }

  void Update ()
  {
    if (IsSpinning)
    {
      MoveItems ();
    }
  }

  void MoveItems ()
  {
    foreach (Transform item in transform)
    {
      // moving items down
      float speed = spinSpeed * Time.deltaTime;
      item.transform.Translate (Vector3.down * speed);

      // move symbol up to the top if it's go down and no longer vidible
      Debug.Log(item.transform.position.y);
      if (item.transform.position.y <= lowerEdge)
      {
        item.transform.position = new Vector3 (transform.position.x, columnHeight, transform.position.z);
      }
    }
  }
}