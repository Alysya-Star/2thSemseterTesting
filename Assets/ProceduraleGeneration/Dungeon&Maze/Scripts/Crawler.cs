using UnityEngine;

namespace ProceduraleGeneration.Dungeon_Maze.Scripts
{
    public class Crawler
    {
        bool finished = false;
        bool dungeonDefinition = false;
        private int corridorLength;
        private int roomLength;
        private int roomWidth;
        private Vector2Int moveDirection;
        private Vector2Int previousPosition;
        MapBase mapBase;


        void ChangeBool(bool value)
        {
            value = !value;
        }

        public void CrawlMap(int startPosX, int startPosZ)
        {
            moveDirection = new Vector2Int(startPosX, startPosZ);
            while (!finished)
            {
                int direction = Random.Range(0, 3);
                previousPosition = moveDirection;
                if (direction <= 1)
                {
                    // Z direction

                    moveDirection.y += UnityEngine.Random.Range(-1, 1);
                    CheckNeighbours(ref moveDirection);
                }
                else
                {
                    // X direction

                    moveDirection.x += UnityEngine.Random.Range(-1, 1);
                }
            }
        }

        void CheckNeighbours(ref Vector2Int position)
        {
            if (position.x == 0 || position.y == 0 || position.x == mapBase.mapWidth - 1 ||
                position.y == mapBase.mapDepth - 1)
            {
                position = previousPosition;
                return;
            }

            
            
        }

        void SetMapDefinition()
        {
            if (dungeonDefinition == false) // Corridor
            {
                //for (int i = 0; i < CorridorLength; i++)
                //{
                //    // Position auf der Map 
                //}
            }
        }
    }
}