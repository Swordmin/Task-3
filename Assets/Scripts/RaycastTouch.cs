using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class RaycastTouch : MonoBehaviour
    {
        public Slider _slider;
        public MeshRenderer _touchObject {get; set; }

        [SerializeField] private TextMeshProUGUI _sliderText;
        [SerializeField] private TMP_Text _rText;
        [SerializeField] private TMP_Text _bText;

        private float _num;
        private IPointerTouch _iPointerTouch;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))                
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    // _iPointerTouch.GetTouchUI();
                    Debug.Log("hti" + hit.collider.gameObject);
                    _touchObject = hit.collider.gameObject.GetComponent<MeshRenderer>();
                }
            }
        }

        public void GetTouch()
        {
            _touchObject = null;
        }
    
        public void OnEdit()
        {
            if (_touchObject)
            {
                Color color = _touchObject.material.color;
                color.g = _slider.value;
                _touchObject.material.color = color;
                _touchObject.material.SetColor("EmmisingColor", color);

                _slider.onValueChanged.AddListener((v) =>
                {
                    _sliderText.text = v.ToString("0.00");
                });

            }

        }

        public void ChangeColor()
        {
            if (_touchObject)
            {
                _touchObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            }
        }

        public void ButtonColorPlus()
        {
            if (_touchObject)
            {
                Color color = _touchObject.material.color;

                color.r = Mathf.Clamp(color.r + 0.1f, 0f, 1f);
                _touchObject.material.color = color;

                _num = color.r;
                _rText.text = _num.ToString("0.00");

            }
        }

        public void ButtonColorMinus()
        {
            if (_touchObject)
            {
                Color color = _touchObject.material.color;
                color.r = Mathf.Clamp(color.r - 0.1f, 0f, 1f);
                _touchObject.material.color = color;

                _num = color.r;
                _rText.text = _num.ToString("0.00");
            }
        }


    }
}