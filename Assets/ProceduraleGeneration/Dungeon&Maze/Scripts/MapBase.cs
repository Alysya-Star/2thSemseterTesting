using UnityEngine;

namespace ProceduraleGeneration.Dungeon_Maze.Scripts
{
    public class MapBase : MonoBehaviour
    {
        [SerializeField] GameObject wallPrefab;
        [Header("Map Settings")] 
        [SerializeField] int mapWidth = 10;
        [SerializeField] int mapDepth = 10;
        private Vector3 startPosition = new Vector3(1, 0, 1);
        private int[,] map;
        

        public void Start()
        {
            IntilizedMap();
            DrawMap();
        }

        private void IntilizedMap()
        {
            map = new int[mapWidth, mapDepth];
            for (var z = 0; z < mapDepth; z++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                  map[x, z] = (int)roomTypes.start;
                    
                }
            }
        }

        private void DrawMap()
        {
            for (var z = 0; z < mapDepth; z++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                    if (map[x, z] == 0)
                    {
                        var position = new Vector3(x * 6, 0, z * 6);
                        var wall = Instantiate(wallPrefab, position, Quaternion.identity, transform);
                    }
                }
            }
        }
    }
}