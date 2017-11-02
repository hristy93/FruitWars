using FruitWars.Models;

namespace FruitWars.Interfaces
{
    public interface IGridManager
    {
        void DisplayOnGrid((int x, int y) position);
        void DisplayOnGrid(Figure figure);
        void InitiateGrid();
        void PrintGrid();
    }
}