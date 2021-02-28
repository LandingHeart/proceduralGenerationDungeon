using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTileMap;
    [SerializeField]
    private TileBase floorTiles, wallTop;


    public void PaintSingleBasicWall(Vector2Int position){
        PaintSingleTile(wallTileMap, wallTop, position);
    }
    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPosition){
        PaintTiles(floorPosition, floorTilemap, floorTiles);
    }

    public void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile){

        foreach (var position in positions){

            PaintSingleTile(tilemap, tile, position);
        }
    }

    public void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position){
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear(){
        floorTilemap.ClearAllTiles();
        wallTileMap.ClearAllTiles();
    }

}
