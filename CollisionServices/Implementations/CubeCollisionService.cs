using CollisionServices.Interfaces;
using CollisionServices.Models;
using System;

namespace CollisionServices.Implementations
{
    public class CubeCollisionService : ICubeCollisionService
    {
        public bool CheckCollision(Cube cube1, Cube cube2)
        {            
            double cube1MinX = cube1.X - cube1.Length / 2;
            double cube1MaxX = cube1.X + cube1.Length / 2;
            double cube1MinY = cube1.Y - cube1.Length / 2;
            double cube1MaxY = cube1.Y + cube1.Length / 2;
            double cube1MinZ = cube1.Z - cube1.Length / 2;
            double cube1MaxZ = cube1.Z + cube1.Length / 2;

            double cube2MinX = cube2.X - cube2.Length / 2;
            double cube2MaxX = cube2.X + cube2.Length / 2;
            double cube2MinY = cube2.Y - cube2.Length / 2;
            double cube2MaxY = cube2.Y + cube2.Length / 2;
            double cube2MinZ = cube2.Z - cube2.Length / 2;
            double cube2MaxZ = cube2.Z + cube2.Length / 2;
           
            bool collisionX = cube1MinX <= cube2MaxX && cube1MaxX >= cube2MinX;
            bool collisionY = cube1MinY <= cube2MaxY && cube1MaxY >= cube2MinY;
            bool collisionZ = cube1MinZ <= cube2MaxZ && cube1MaxZ >= cube2MinZ;

            // Return true if all three dimensions overlap (collision)
            return collisionX && collisionY && collisionZ;
        }

        public double CalculateIntersectedVolume(Cube cube1, Cube cube2)
        {
            // Calculate the overlapping dimensions along each axis
            double overlapX = Math.Max(0, Math.Min(cube1.X + cube1.Length / 2, cube2.X + cube2.Length / 2) - Math.Max(cube1.X - cube1.Length / 2, cube2.X - cube2.Length / 2));
            double overlapY = Math.Max(0, Math.Min(cube1.Y + cube1.Length / 2, cube2.Y + cube2.Length / 2) - Math.Max(cube1.Y - cube1.Length / 2, cube2.Y - cube2.Length / 2));
            double overlapZ = Math.Max(0, Math.Min(cube1.Z + cube1.Length / 2, cube2.Z + cube2.Length / 2) - Math.Max(cube1.Z - cube1.Length / 2, cube2.Z - cube2.Length / 2));

            // Calculate the intersected volume
            double volume = overlapX * overlapY * overlapZ;

            return volume;
        }
    }
}
