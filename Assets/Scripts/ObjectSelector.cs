using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObjectSelector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _select;

    public void OnPointerClick(PointerEventData eventData)
    {
        _select?.Invoke();
    }
}
