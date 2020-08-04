using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrice : MonoBehaviour
{
    [SerializeField] private TowerData _tower = null;
    [SerializeField] private TextMeshProUGUI price = null;
    [SerializeField] private GameManager _gameManager = null;
    private Image _image = null;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        price.text = _tower.BuildPrice.ToString();
        if (_gameManager.Coins < _tower.BuildPrice)
        {
            _image.color = Color.red;
           
        }
        else
        {
            _image.color = Color.green;
        }
    }

}
