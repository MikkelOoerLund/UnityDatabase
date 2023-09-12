using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _textMesh;


    public void SetText(string value)
    {
        _textMesh.text = value;
    }

}
