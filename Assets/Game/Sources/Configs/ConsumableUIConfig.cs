using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Sources.Configs
{
    [Serializable]
    public class ConsumableUIData
    {
        [SerializeField] private GameModel.ConsumableTypes type;
        [SerializeField] private Sprite icon;
        [SerializeField] private string title;
        [SerializeField] private string description;

        public GameModel.ConsumableTypes Type => type;
        public Sprite Icon => icon;
        public string Title => title;
        public string Description => description;
    }
    
    [CreateAssetMenu(fileName = "ConsumableUIConfig", menuName = "Configs/ConsumableUIConfig")]
    public class ConsumableUIConfig : ScriptableObject
    {
        [SerializeField] private List<ConsumableUIData> consumables;

        public ConsumableUIData GetConsumableUIData(GameModel.ConsumableTypes type)
        {
            var data = consumables.FirstOrDefault(x => x.Type == type);
            
            if (data == null)
                throw new InvalidOperationException();

            return data;
        }
    }
}
