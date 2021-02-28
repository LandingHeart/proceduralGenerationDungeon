using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;
public class SimpleDungeonGenerator : AbstractDungeonGenerator
{
    // Start is called before the first frame update
   

    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameter;


    protected override void RunProceduralGeneration(){
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameter, startPosition);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWall(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position){
        var currentPosition = position;
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();

        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = ProceduralGeneratonAlgorithm.SimpleRandomWalk(currentPosition, parameters.walkLength);
            floorPosition.UnionWith(path);
            if(parameters.startRandomInEachIteration)
                currentPosition = floorPosition.ElementAt(Random.Range(0, floorPosition.Count));
            
        }
        return floorPosition;
    }

   

}
