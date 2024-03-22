using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Excuses.Libraries.Math
{

    [System.Serializable]
    public class GridData
    {
        public GridChunk[,] chunks;
    }

    [System.Serializable]
    public class GridChunk
    {
        public GridPoint[,] points;
        public Vector2Int[] neighborChunks;
        public Vector3Int worldPosition;
        public Vector2Int chunkPosition;

        public GridChunk(GridPoint[,] _points, Vector2Int[] _neighborChunks, Vector3Int _worldPosition, Vector2Int _chunkPosition)
        {
            points = _points;
            neighborChunks = _neighborChunks;
            worldPosition = _worldPosition;
            chunkPosition = _chunkPosition;
        }
    }

    [System.Serializable]
    public class GridPoint
    {
        public Vector2Int[] neighborPoints;
        public GridChunk parentchunk;
        public Vector3Int worldPosition;
        public Vector2Int pointPosition;
    }

    public class Grids : MonoBehaviour
    {
        public enum GridType
        {
            Square,
            Hexagon
        }
        public GridData GenerateGrid(GridType type, Vector2Int scale, int chunkSize, Vector2Int pointsScale)
        {
            GridData newData = new GridData();

            newData.chunks = GenerateChunks(type, scale, chunkSize, pointsScale);

            return newData;
        }

        public GridChunk[,] GenerateChunks(GridType type, Vector2Int scale, int chunkSize, Vector2Int pointsScale)
        {
            GridChunk[,] chunks = new GridChunk[scale.x , scale.y];

            if(type == GridType.Square)
            {
                for (int x = 0; x < scale.x; x++)
                {
                    for (int y = 0; y < scale.y; y++)
                    {
                        GridPoint[,] points = new GridPoint[pointsScale.x, pointsScale.y];
                        Vector2Int[] neighborChunks = GetNeighborChunks(type, new Vector2Int(x, y), scale);
                        chunks[x, y] = new GridChunk(points, neighborChunks, new Vector3Int(x * chunkSize, 0, y * chunkSize), new Vector2Int(x, y));
                    }
                }
            }

            return chunks;
        }

        public Vector2Int[] GetNeighborChunks(GridType type, Vector2Int startingPosition, Vector2Int scale)
        {
            List<Vector2Int> neighbors = new List<Vector2Int>();

            if (type == GridType.Square)
            {
                if (startingPosition.x + 1 < scale.x)
                {
                    neighbors.Add(new Vector2Int(startingPosition.x + 1, startingPosition.y));
                }
                if (startingPosition.x - 1 >= 0)
                {
                    neighbors.Add(new Vector2Int(startingPosition.x - 1, startingPosition.y));
                }
                if (startingPosition.y + 1 < scale.y)
                {
                    neighbors.Add(new Vector2Int(startingPosition.x, startingPosition.y + 1));
                }
                if (startingPosition.y - 1 >= 0)
                {
                    neighbors.Add(new Vector2Int(startingPosition.x, startingPosition.y - 1));
                }
            }

            return neighbors.ToArray();
        }
    }

}
