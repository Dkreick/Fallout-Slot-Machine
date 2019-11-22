using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnHandler : MonoBehaviour
{
  [SerializeField]
  public float spinSpeed;
  public int columnHeight;

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
      float speed = spinSpeed * Time.deltaTime;
      item.transform.Translate (Vector3.down * speed);

      if (item.transform.position.y <= -4)
      {
        item.transform.position = new Vector3 (transform.position.x, columnHeight, transform.position.z);
      }
    }
  }
}