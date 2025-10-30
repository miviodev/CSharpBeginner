using Stride.Engine;

namespace CSharpBeginner.Code
{
    /// <summary>
    /// This script is used in combination with the GettingAComponent.cs script 
    /// </summary>
    public class AmmoComponent : StartupScript // AmmoComponent здесь тип
    {
        private readonly int maxBullets = 30; //не можем работать из другого скрипта
        private readonly int currentBullets = 12;//не можем работать из другого скрипта

        public override void Start() { }

        public int GetRemainingAmmo() //метод
        {
            return maxBullets - currentBullets; //Возвращает 30 - 12
        }
    }
}
