using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text sizeView;
    [SerializeField] private Tower tower;

    private void OnEnable()
    {
        tower.SizeUpdated += onSizeUpdated;
    }

    private void OnDisable()
    {
        tower.SizeUpdated -= onSizeUpdated;
    }

    private void onSizeUpdated(int size)
    {
        sizeView.text = size.ToString();
    }
}
