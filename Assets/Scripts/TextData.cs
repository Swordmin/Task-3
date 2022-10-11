using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TextData", menuName = "Panel/Text Data")]
public class TextData : ScriptableObject
{
    [SerializeField] private TMP_Text _rText;
    public TMP_Text _bText;
    public TextMeshProUGUI  _sliderText;
    public Slider _slider;

    public TMP_Text RText => _rText;
}
