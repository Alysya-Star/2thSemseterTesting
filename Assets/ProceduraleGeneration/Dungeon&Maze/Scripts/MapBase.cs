using UnityEngine;

namespace ProceduraleGeneration.Dungeon_Maze.Scripts
{
    public class MapBase : MonoBehaviour
    {
        [SerializeField] GameObject wallPrefab;
        [SerializeField] GameObject testing;

        [Header("Map Settings")]
        // Noch in Random um aendern
        [SerializeField] [Range(15f, 50f)] public int mapWidth;
        [SerializeField] [Range(15f, 50f)]public int mapDepth;
        [SerializeField] [Range(15f, 50f)]public int mapHeight;
        protected int startPosX = 1, startPosZ = 1;
        public int[,,] map;

        public void Start()
        {
            IntilizedMap();
            DrawMap();
        }

        private void IntilizedMap()
        {
            map = new int[mapWidth, mapHeight,mapDepth];
            for (var z = 0; z < mapDepth; z++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                    if (z == 0 || z == mapDepth - 1 || x == 0 || x == mapWidth - 1)
                    {
                        map[x, z] = (int)roomTypes.border;
                    }
                    else
                    {
                        map[x, z] = (int)roomTypes.corridor;
                    }
                }
            }

            map[startPosX, startPosZ] = (int)roomTypes.start;
        }

        private void DrawMap()
        {
            for (var z = 0; z < mapDepth; z++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                    if (map[x, z] == (int)roomTypes.border)
                    {
                        var position = new Vector3(x * 10, 0, z * 10);
                        var wall = Instantiate(wallPrefab, position, Quaternion.identity, transform);
                    }
                    else if(map[x, z] == (int)roomTypes.corridor)
                    {
                        var position = new Vector3(x * 10, 0, z * 10);
                        var test = Instantiate(testing, position, Quaternion.identity, transform);
                    }
                }
            }
        }
    }
}