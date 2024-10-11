namespace PvZGame.Models.Plants
{
    public class GreenPlant : Plant
    {
        private const int GreenPlantHealth = 50;
        private const int GreenPlantDamage = 10;
        private const string GreenPlantImagePath = "Assets/Images/PlantsImages/green_plant.jpg";
        
        public GreenPlant(string name, double positionX, double positionY) 
            : base(name, GreenPlantHealth, GreenPlantDamage, GreenPlantImagePath)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
