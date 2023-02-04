using UnityEngine;

namespace UnityTemplateProjects
{
    public class Value : MonoBehaviour
    {
        [SerializeField] 
        private int _value;

        public void Liquidate()
        {
            Currency.AddCurrency(_value);
        }
    }
}