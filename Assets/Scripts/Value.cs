using UnityEditor.AnimatedValues;
using UnityEngine;


public class Value : MonoBehaviour
{
    [SerializeField] private int baseValue;

    [SerializeField] private float scaling;

    private int _value;

    private void Start()
    {
        _value = (int)(transform.position.y * -1 * scaling) + baseValue;
    }

    public void Liquidate()
    {
        Currency.AddCurrency(_value);
    }
}
