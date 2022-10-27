using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world_scrolling : MonoBehaviour
{
    public Transform playerTransform;
    Vector2Int curTilePosition = new Vector2Int(0,0);
    Vector2Int onTileGridPlayerPosition;
    Vector2Int playTilePosition;
    int height = 3, width = 3;
    float tileSize = 20f;
    GameObject[,] terrainTiles; 
    public int horizontalCount, verticalCount;
    void Awake() {
        terrainTiles = new GameObject[horizontalCount,verticalCount];
    }
    public void add(GameObject tileGameObject, Vector2Int tilePosition){
        terrainTiles[tilePosition.x,tilePosition.y] = tileGameObject;
    }
    void Update()
    {
        playTilePosition.x = (int)(playerTransform.position.x/tileSize);
        playTilePosition.y = (int)(playerTransform.position.y/tileSize);
        if(curTilePosition != playTilePosition){
            curTilePosition = playTilePosition;
            onTileGridPlayerPosition.x = updateonTileGridPlayerPosition(onTileGridPlayerPosition.x,true);
            onTileGridPlayerPosition.y = updateonTileGridPlayerPosition(onTileGridPlayerPosition.y,false);
            updateTileOnScreen();
        }
    }
    private Vector3 calPosition(int x,int y){
        return new Vector3(x*tileSize,y*tileSize,0f);
    }
    public void updateTileOnScreen(){
        for(int x = -width/2; x <= width/2; x++){
            for(int y = -height/2; y <= height/2; y++){
                int tileUpdate_x = updateonTileGridPlayerPosition(playTilePosition.x+x,true);
                int tileUpdate_y = updateonTileGridPlayerPosition(playTilePosition.y+y,true);
                GameObject tile = terrainTiles[tileUpdate_x,tileUpdate_y];
                tile.transform.position = calPosition(
                    playTilePosition.x + x,
                    playTilePosition.y + y
                );
            }
        }
    }
    private int updateonTileGridPlayerPosition(int curVal, bool horizontal){
        if(horizontal){
            if(curVal >= 0){
                curVal %= horizontalCount;
            }else{
                curVal = horizontalCount -1 + curVal % horizontalCount;
            }
        }
        else{
            if(curVal >= 0){
                curVal %= verticalCount;
            }else{
                curVal = verticalCount -1 + curVal % verticalCount;
            }
        }
        return curVal;

    }
}
