
using System;
using UnityEngine;

public class MinePower : MonoBehaviour
{
    [SerializeField] private int baseMinePower;
    private static int maxMinePower;
    public static int currentMinePower;

    public static void ResetMinePower()
    {
        currentMinePower = maxMinePower;
    }

    public static void UpgradeMinePower(int amount)
    {
        maxMinePower += amount;
        currentMinePower = maxMinePower;
    }

    public static bool CanMine()
    {
        return currentMinePower > 0;
    }

    public static void Mine()
    {
        currentMinePower--;
    }

    private void Start()
    {
        maxMinePower = baseMinePower;
        currentMinePower = maxMinePower;
    }
}
