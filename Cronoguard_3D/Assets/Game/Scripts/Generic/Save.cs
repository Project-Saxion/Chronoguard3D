using System.Collections.Generic;

namespace Game.Scripts.Generic
{
    [System.Serializable]
    public class Save
    {
        public List<int> levels = new List<int>();
        public int money;
        public int healthPlayer;
        public int healthBase;
        public int wave;
    }
}