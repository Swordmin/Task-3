using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GColor : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] private TMP_Text _rText;
    [SerializeField] private TMP_Text _bText;
    private float num;

    public Slider _slider;

    private MeshRenderer _touchObject;
    private Image _touchObjectUI;


    public void OnPointerDown(PointerEventData eventData)
    {
        _touchObject = null;
        _touchObjectUI = eventData.pointerEnter.GetComponent<Image>();
        Debug.Log(_touchObjectUI);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _touchObjectUI = null;
                Debug.Log("hti" + hit.collider.gameObject);
                _touchObject = hit.collider.gameObject.GetComponent<MeshRenderer>();
            }
        }
    }

    public void OnEdit()
    {
        if (_touchObject)
        {
            Color color = _touchObject.material.color;
            color.g = _slider.value;
            _touchObject.material.color = color;
            _touchObject.material.SetColor("EmmisingColor", color); 

            _slider.onValueChanged.AddListener((v) => {
                _sliderText.text = v.ToString("0.00");
            });

        } else if (_touchObjectUI)
        {
            Color color = _touchObjectUI.color;
            color.g = _slider.value;
            _touchObjectUI.color = color;  

            _slider.onValueChanged.AddListener((v) => {
                _sliderText.text = v.ToString("0.00");
            });
        }

    }

    public void ChangeColor()
    {
        if(_touchObject)
        {
            _touchObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0,1f),Random.Range(0,1f), Random.Range(0,1f) );
        }
        if(_touchObjectUI)
        {
            _touchObjectUI.GetComponent<Image>().color = new Color(Random.Range(0,1f),Random.Range(0,1f), Random.Range(0,1f) );
        }
    }


    public void ButtonColorPlus()
    {
        if(_touchObject)
        {   
            Color color = _touchObject.material.color;
            
            color.r = Mathf.Clamp(color.r + 0.1f, 0f, 1f);
            _touchObject.material.color = color;

            num = color.r;
            _rText.text = num.ToString("0.00");

        }

        if(_touchObjectUI)
        {
            Color color = _touchObjectUI.color;
            color.r = Mathf.Clamp(color.r + 0.1f, 0f, 1f);
            _touchObjectUI.color = color; 

            num = color.r;
            _rText.text = num.ToString("0.00");
        }
    }

    public void ButtonColorMinus()
    {
        if(_touchObject)
        {
            Color color = _touchObject.material.color;
            color.r = Mathf.Clamp(color.r - 0.1f, 0f, 1f);
            _touchObject.material.color = color;

            num = color.r;
            _rText.text = num.ToString("0.00");
        }

        if(_touchObjectUI)
        {
            Color color = _touchObjectUI.color;
            color.r = Mathf.Clamp(color.r - 0.1f, 0f, 1f);
            _touchObjectUI.color = color; 

            num = color.r;
            _rText.text = num.ToString("0.00");
        }
    }

    
}
