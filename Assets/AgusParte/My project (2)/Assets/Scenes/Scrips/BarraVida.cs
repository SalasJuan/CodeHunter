using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Player _player;
    private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _player._vida;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _player._vida; 
    }
}
