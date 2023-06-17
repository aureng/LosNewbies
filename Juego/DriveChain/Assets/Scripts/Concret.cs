using UnityEngine;
using TMPro;

public class Concret : MonoBehaviour
{
 public TMP_Text textField;
    public int value;

    private void Start()
    {
       textField.text=""+value;
    }
}
