using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class IPointerTouch : MonoBehaviour, IPointerDownHandler
    {
        public Image _touchObjectUI {get; set;}
        public Slider _slider;

        [SerializeField] private TextMeshProUGUI _sliderText;
        [SerializeField] private TMP_Text _rText;
        [SerializeField] private TMP_Text _bText;

        private float _num;
        private RaycastTouch _raycastTouch;

        public void OnPointerDown(PointerEventData eventData)
        {
            // _raycastTouch.GetTouch();
            _touchObjectUI = eventData.pointerEnter.GetComponent<Image>();
            Debug.Log(_touchObjectUI);
        }

        public void GetTouchUI()
        {
            _touchObjectUI = null;
        }

        public void OnEdit()
        {
            if (_touchObjectUI)
            {
                Color color = _touchObjectUI.color;
                color.g = _slider.value;
                _touchObjectUI.color = color;

                _slider.onValueChanged.AddListener((v) =>
                {
                    _sliderText.text = v.ToString("0.00");
                });
            }

        }

        public void ChangeColor()
        {
            if (_touchObjectUI)
            {
                _touchObjectUI.GetComponent<Image>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            }
        }

        public void ButtonColorPlus()
        {
            if (_touchObjectUI)
            {
                Color color = _touchObjectUI.color;
                color.r = Mathf.Clamp(color.r + 0.1f, 0f, 1f);
                _touchObjectUI.color = color;

                _num = color.r;
                _rText.text = _num.ToString("0.00");
            }
        }

        public void ButtonColorMinus()
        {
            if (_touchObjectUI)
            {
                Color color = _touchObjectUI.color;
                color.r = Mathf.Clamp(color.r - 0.1f, 0f, 1f);
                _touchObjectUI.color = color;

                _num = color.r;
                _rText.text = _num.ToString("0.00");
            }
        }
    }
}