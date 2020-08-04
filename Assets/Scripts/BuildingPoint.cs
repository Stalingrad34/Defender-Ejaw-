using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System.Security.Cryptography;

public class BuildingPoint : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image buildingPanel = null;
    [SerializeField] Image sellPanel = null;
    [SerializeField] private GameManager _gameManager = null;
    private Renderer _renderer = null;   
    private GameObject currentTower = null;
    private bool isBuilded = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _renderer.material.color = Color.green;
        if (isBuilded == false)
        {
            buildingPanel.gameObject.SetActive(true);
        }
        else
        {
            sellPanel.gameObject.SetActive(true);
        }              
    }


    public void CreateTower(GameObject tower)
    {
        int price = tower.GetComponent<Tower>().BuildPrice;

        if (_gameManager.Coins > price)
        {
            currentTower = Instantiate(tower, transform.position, Quaternion.identity);
            isBuilded = true;
            _gameManager.ChangeCoins(-price);
            PanelOff();
        }       
    }

    public void SellTower()
    {
        if (currentTower != null)
        {            
            int price = currentTower.GetComponent<Tower>().BuildPrice;
            _gameManager.ChangeCoins(price / 2);
            Destroy(currentTower);
            isBuilded = false;
            PanelOff();
        }        
    }

    public void PanelOff()
    {
        buildingPanel.gameObject.SetActive(false);
        sellPanel.gameObject.SetActive(false);
        _renderer.material.color = Color.white;
    }
}
