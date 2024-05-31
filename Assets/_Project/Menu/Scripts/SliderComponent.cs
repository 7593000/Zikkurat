using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderComponent : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    private Slider _slider;

    private void Start()
    {
        _slider ??= GetComponent<Slider>();
    }

    public void SetValue(float value)
    { 
        _slider.value = value;
   
        _text.text = value.ToString();
    }

    public float GetValue =>_slider.value;  

    public void SetTextHanlde()
    {
        
        string text;


        text = (_slider.value % 1 != 0) ?  _slider.value.ToString("F2"): _slider.value.ToString();
         
        _text.text = text;
    }
}