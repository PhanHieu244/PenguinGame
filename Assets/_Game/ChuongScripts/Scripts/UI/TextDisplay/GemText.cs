using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using TMPro;
using UnityEngine;

public class GemText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmp;

    private void OnValidate()
    {
        _tmp = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        GameAction.OnChangeGem += OnChangeGem;
        ShowCurrentGem();
    }

    private void OnChangeGem(int obj)
    {
        ShowCurrentGem();
    }

    private void ShowCurrentGem()
    {
        _tmp.SetText($"{GameDataManager.Instance.playerData.Gem}");
    }
}