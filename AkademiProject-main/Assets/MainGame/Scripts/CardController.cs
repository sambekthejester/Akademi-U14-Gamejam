using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private bool _isMouseOver;
    public bool IsMouseOver
    {
        get { return _isMouseOver; }
        private set { _isMouseOver = value; }
    }

    private void OnMouseOver()
    {
        _isMouseOver = true;
    }
    private void OnMouseExit()
    {
        _isMouseOver = false;
    }

    
}
