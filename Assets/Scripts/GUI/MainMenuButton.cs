using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MainMenuButton: MonoBehaviour
{
    [SerializeField] private RectTransform _textTransform;

    private void OnMouseDown()
    {
        ChangeTextMarginDown();
    }
    
    private void OnMouseUp()
    {
        ChangeTextMarginUp();
    }

    public abstract void OnClick();

    private void ChangeTextMarginDown()
    {
        _textTransform.anchoredPosition = new Vector2(0, -10);
    }
    private void ChangeTextMarginUp()
    {
        _textTransform.anchoredPosition = new Vector2(0, 10);
    }
}
