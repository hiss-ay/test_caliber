using Game.Sources.Configs;
using UnityEngine;

namespace Game.Sources
{
    public static class UIHelper
    {
        private static ConsumableUIConfig _consumableUIConfig;

        public static ConsumableUIData GetConsumableUIData(GameModel.ConsumableTypes type)
        {
            if (_consumableUIConfig == null)
                _consumableUIConfig = Resources.Load<ConsumableUIConfig>("Configs/ConsumableUIConfig");

            return _consumableUIConfig.GetConsumableUIData(type);
        }
        
        public static string IntegerToString(int number)
        {
            return $"{number:n0}";
        }
        
    }
}