using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour
{

    [SerializeField] private GameObject _currentObject;
    [SerializeField] private TextMeshProUGUI _textR, _textB, _textG;
    [SerializeField] private float _r, _g, _b;
    [SerializeField] private Slider _slider;
    [SerializeField] private Button button;

    public void UpdateObject(GameObject selectObject)
    {
        _currentObject = selectObject;
        UpdateUI();
    }


    public void AddR() 
    {
        if (_r >= 255)
            return;
        _r++;
        UpdateColor();
    }

    public void RemoveR() 
    {
        if (_r <= 0)
            return;
        _r--;
        UpdateColor();
    }

    public void RandomB() 
    {
        _b = Random.Range(0,255);
        UpdateColor();
    }

    public void OnSliderChanged() 
    {

        if (_currentObject)
        {
            _slider.onValueChanged.AddListener((v) =>
            {
                _g = (v * 255);
                UpdateColor();
            });
        }

    }


    private Color ConvertColor(float r, float g, float b)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }




    private void UpdateColor() 
    {
        if (!_currentObject)
            return;
        if (_currentObject.TryGetComponent(out Image image))
        {
            image.color = ConvertColor(_r,_g,_b);
        }
        if (_currentObject.TryGetComponent(out MeshRenderer mesh))
        {
            mesh.material.color = ConvertColor(_r, _g, _b);
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_currentObject.TryGetComponent(out Image image))
        {
            _textR.text = (image.color.r * 255f).ToString();
            _textG.text = (image.color.g * 255f).ToString();
            _textB.text = (image.color.b * 255f).ToString(); 
            _r = image.color.r * 255f;
            _g = image.color.g * 255f;
            _b = image.color.b * 255f;
            _slider.value = image.color.g;
        }
        if (_currentObject.TryGetComponent(out MeshRenderer mesh))
        {
            _textR.text = (mesh.material.color.r * 255f).ToString();
            _textG.text = (mesh.material.color.g * 255f).ToString();
            _textB.text = (mesh.material.color.b * 255f).ToString();
            _r = mesh.material.color.r * 255f;
            _g = mesh.material.color.g * 255f;
            _b = mesh.material.color.b * 255f;
            _slider.value = mesh.material.color.g;
        } 
    }
   

}
