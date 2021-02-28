using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator 
{
    public static void CreateWall(HashSet<Vector2Int> floorPosition, TilemapVisualizer tilemapVisualizer){
        var basicWallPositions = FindWallsInDirection(floorPosition, Direction2D.cardinalDirectionList);

        foreach (var position in basicWallPositions)
        {
            tilemapVisualizer.PaintSingleBasicWall(position);
        }
    }

    public static HashSet<Vector2Int> FindWallsInDirection(HashSet<Vector2Int> floorPosition, List<Vector2Int> directionList){
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();

        foreach (var position in floorPosition)
        {
            foreach (var direction in directionList)
            {
                var neigborPosition = position + direction;
                if(floorPosition.Contains(neigborPosition) == false){
                    wallPositions.Add(neigborPosition);
                }
            }
        }
        return wallPositions;
    }
}
