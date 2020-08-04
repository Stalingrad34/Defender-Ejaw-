using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI HealthUI = null;
    public TextMeshProUGUI CoinsUI = null;
    public TextMeshProUGUI WavesUI = null;
    public Image GameOverUI = null;
    public Image Win = null;

    private void Start()
    {
        GameOverUI.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
    }
}
