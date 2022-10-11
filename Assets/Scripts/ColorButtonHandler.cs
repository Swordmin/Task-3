using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ColorButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private UnityEvent _event;
    private bool _down;
    public void OnPointerDown(PointerEventData eventData)
    {
        _down = true;
        StartCoroutine(Tick());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _down = false;
    }

    IEnumerator Tick() 
    {
        while (_down) 
        {
            yield return new WaitForSeconds(0.05f);
            _event?.Invoke();

        }
    }

}
