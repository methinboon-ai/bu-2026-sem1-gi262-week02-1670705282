using UnityEngine;

namespace Workshop.Student
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };

        // 1. declare Players variable
        public GameObject[] playerObjTemplates = new GameObject[2];

        void CreatePlayer()
        {
            foreach (var playerTemplate in playerObjTemplates)
            {
                GameObject Player = Instantiate(playerTemplate, new Vector3(0, 0, 0), Quaternion.identity);
                Player.name = playerTemplate.name;
            }

        }
        // 7. declare Exit variable 
        public GameObject exitPrefab;
        void CreateExit()
        {
            if (exitPrefab != null)
            {
                GameObject exit = Instantiate(exitPrefab, new Vector2(columns - 1, rows - 1), Quaternion.identity);
                exit.name = exitPrefab.name;
            }
        }

        public void Start()
        {
            // 1. random player at the position <0, 0> map
            CreatePlayer();
            // 3. create floor
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    int r = UnityEngine.Random.Range(0, floorTiles.Length);
                    GameObject tiles = Instantiate(floorTiles[r], new Vector2(x, y), Quaternion.identity);
                    tiles.name = "Floor" + x + "_" + y;
                }
            }

            // 2. create obstacles (ลากกำแพงแนวตั้งตรงกลางจากขอบล่างขึ้นมาถึงกลางแผนที่)
            int midX = columns / 2;
            int midY = rows / 2;
            for (int y = 0; y <= midY; y++)
            {
                // Debug.Log($"{midX}, {y}");
                int r = UnityEngine.Random.Range(0, wallTiles.Length);
                GameObject tiles = Instantiate(wallTiles[r], new Vector2(midX, y), Quaternion.identity);
                tiles.name = "Obstacle" + midX + "_" + y;
                tiles.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            // 4. create walls
            for (int y = -1; y < rows + 1; y++)
            {
                for (int x = -1; x < columns + 1; x++)
                {
                    if (x == -1 || x == columns || y == -1 || y == rows)
                    {
                        int r = UnityEngine.Random.Range(0, wallTiles.Length);
                        GameObject tiles = Instantiate(wallTiles[r], new Vector2(x, y), Quaternion.identity);
                        tiles.name = "Wall" + x + "_" + y;
                    }
                }
            }
            // 5. random foods
            int numberOfFoods = 1;
            for (int i = 0; i < numberOfFoods; i++)
            {
                int foodx = UnityEngine.Random.Range(0, columns);
                int foody = UnityEngine.Random.Range(0, rows);
                int r = UnityEngine.Random.Range(0, foodTiles.Length);
                Instantiate(foodTiles[r], new Vector2(foodx, foody), Quaternion.identity);
            }
            // 6. generate item along with the saveItemMap
            for (int y = 0; y < saveItemMap.GetLength(0); y++)
            {
                for (int x = 0; x < saveItemMap.GetLength(1); x++)
                {
                    string item = saveItemMap[x, y];
                    if (!string.IsNullOrEmpty(item))
                    {
                        foreach (var foodTile in foodTiles)
                        {
                            if (foodTile.name == item)
                            {
                                int foodx = UnityEngine.Random.Range(0, columns);
                                int foody = UnityEngine.Random.Range(0, rows);
                                GameObject foodItem = Instantiate(foodTile, new Vector2(foodx, foody), Quaternion.identity);
                                foodItem.name = item + "_" + foodx + "_" + foody;
                                break;
                            }
                        }
                    }
                }
            }
            // 7. place exit
            CreateExit();
        }
    }

}