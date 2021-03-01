﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGeneratonAlgorithm
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {

        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        var previousPosition = startPosition;

        for(int i = 0; i < walkLength; i++){
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
    public static List<Vector2Int> RandomCorridor(Vector2Int startPosition, int corridorLength){
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPosition = startPosition;
        corridor.Add(currentPosition);
        for (int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }

        return corridor;
    }
}
public static class Direction2D{
    public static List<Vector2Int> cardinalDirectionList =  new List<Vector2Int>{
        new Vector2Int(0,1),// up
        new Vector2Int(1,0),//right
        new Vector2Int(0, -1), // down
        new Vector2Int(-1, 0), //left 
    };
     public static List<Vector2Int> diagonalDirectionList =  new List<Vector2Int>{
        new Vector2Int(1,1),// up-right
        new Vector2Int(1,-1),//right-down
        new Vector2Int(-1, -1), // down-left
        new Vector2Int(-1, 1), //left-up 
    };

    public static List<Vector2Int> eightDirectionList = new List<Vector2Int>{
        new Vector2Int(0,1),// up
        new Vector2Int(1,1),// up-right
        new Vector2Int(1,0),//right
        new Vector2Int(1,-1),//right-down
        new Vector2Int(0, -1), // down
        new Vector2Int(-1, -1), // down-left
        new Vector2Int(-1, 0), //left 
        new Vector2Int(-1, 1), //left-up 
    };
    public static Vector2Int GetRandomCardinalDirection(){
         return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
    }

}