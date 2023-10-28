using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manipulator : MonoBehaviour
{
    [SerializeField] private InputField seamBetweenTiles;
    [SerializeField] private InputField cornerTilesInArea;
    [SerializeField] private InputField bias;
    [SerializeField] private Button _button;
    [SerializeField] private Text _resultText;


    private CreateTile scriptCreateTile;


    private void Awake()
    {
        scriptCreateTile = GetComponent<CreateTile>();
        Debug.Assert(seamBetweenTiles != null, $"Assign {nameof(seamBetweenTiles)} field in the inspector");
        Debug.Assert(cornerTilesInArea != null, $"Assign {nameof(cornerTilesInArea)} field in the inspector");
        Debug.Assert(bias != null, $"Assign {nameof(bias)} field in the inspector");
        Debug.Assert(_button != null, $"Assign {nameof(_button)} field in the inspector");
        Debug.Assert(_resultText != null, $"Assign {nameof(_resultText)} field in the inspector");
        Debug.Assert(seamBetweenTiles.contentType == InputField.ContentType.IntegerNumber, "InputType should be IntegerNumber");
        Debug.Assert(cornerTilesInArea.contentType == InputField.ContentType.IntegerNumber, "InputType should be IntegerNumber");
        Debug.Assert(bias.contentType == InputField.ContentType.IntegerNumber, "InputType should be IntegerNumber");
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        int result = ActionWithNumber(Convert.ToInt32(seamBetweenTiles.text), Convert.ToInt32(cornerTilesInArea.text), Convert.ToInt32(bias.text));
        _resultText.text = result.ToString();
    }

    private int ActionWithNumber(int seamBetweenTiles, int cornerTilesInArea, int bias)
    {
        scriptCreateTile.seamBetweenTiles = seamBetweenTiles;
        scriptCreateTile.cornerTilesInArea = cornerTilesInArea;
        scriptCreateTile.bias = bias;
        return scriptCreateTile.areaInt();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}
