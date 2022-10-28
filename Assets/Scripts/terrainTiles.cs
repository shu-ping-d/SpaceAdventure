using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainTiles : MonoBehaviour{ 
    public Vector2Int tilePosition;
    // Start is called before the first frame update
    void Start()
    {
        world_scrolling world = GetComponentInParent<world_scrolling>();
        if (world != null)
        {
            world.add(gameObject,tilePosition);
        }
        else{
            // Try again by including inactive GameObjects.
            world = GetComponentInParent<world_scrolling>(true);
            if (world != null)
                world.add(gameObject,tilePosition);
        }
    }
}
