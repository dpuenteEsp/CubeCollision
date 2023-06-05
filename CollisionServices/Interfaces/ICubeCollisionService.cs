using CollisionServices.Models;

namespace CollisionServices.Interfaces
{
    public interface ICubeCollisionService
    {
        bool CheckCollision(Cube cube1, Cube cube2);
        double CalculateIntersectedVolume(Cube cube1, Cube cube2);
    }
}
