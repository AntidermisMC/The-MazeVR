﻿using UnityEngine;

public class Generator : MonoBehaviour
{
    public ListPrefab[] P;

    public string code;
    
    private Parser p = new Parser();

    private int[,] map;

    public void GenerateLab()
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                int c = map[i,j];
                if (i % 2 == 0 && j % 2 == 0)
                {
                    if (c == 1)
                        create("Pillar", i, j,false);
                }
                else if (i % 2 == 1 && j % 2 == 0)
                {
                    if (c == 2)
                        create("Wall", i, j,true);
                    else if (c == 4)
                        create("Door", i, j,true);
                    else if (c == 6)
                        create("FalseWall", i, j,true);
                    else if (c == 7)
                        create("IlluWall", i, j,true);
                    else if (c == 8)
                        create("IlluDoor", i, j,true);
                }
                else if (i % 2 == 0 && j % 2 == 1)
                {
                    if (c == 2)
                        create("Wall", i, j,false);
                    else if (c == 4)
                        create("Door", i, j,false);
                    else if (c == 6)
                        create("FalseWall", i, j,false);
                    else if (c == 7)
                        create("IlluWall", i, j,false);
                    else if (c == 8)
                        create("IlluDoor", i, j,false);
                }
                else if (i % 2 == 1 && j % 2 == 1)
                {
                    if (c== 5)
                        create("Light",i,j,false);
                    if (c== 3)
                        create("Player",i,j,false);
                    create("GroundTile", i, j,false);
                }
            }
        }
    }

    public void create(string name, int y,int x, bool rotate)
    {
        Vector3 v;
        foreach (ListPrefab G in P)
            {
                if (G.name == name)
                {
                    switch (G.name)
                    {
                        case ("Pillar"):
                            v = new Vector3(2 * x+transform.position.x, (float) 2.5+transform.position.y, 2 * y+transform.position.z);
                            Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                        case ("Wall"):
                            v = new Vector3(2 * x+transform.position.x, (float) 2.5+transform.position.y, 2 * y+transform.position.z);
                            if (!rotate)
                                Instantiate(G.prefab, v,Quaternion.Euler(new Vector3(0,90,0)), transform);
                            else
                                Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                        case ("GroundTile"):
                            v = new Vector3(2*x+transform.position.x,0+transform.position.y,2*y+transform.position.z);
                            Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                        case ("Player"):
                            v=new Vector3(2*x+transform.position.x,(float)1.5 +transform.position.y,2*y+transform.position.z);
                            Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                        case ("Door"):
                            v = new Vector3(2 * x+transform.position.x, (float) 2.5+transform.position.y, 2 * y+transform.position.z);
                            if (!rotate)
                                Instantiate(G.prefab, v,Quaternion.Euler(new Vector3(0,90,0)), transform);
                            else
                                Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                        case ("Light"):
                            v=new Vector3(2*x+transform.position.x,(float)4.5 +transform.position.y,2*y+transform.position.z);
                            Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                        case ("FalseWall"):
                            v = new Vector3(2 * x+transform.position.x, (float) 2.5+transform.position.y, 2 * y+transform.position.z);
                            if (!rotate)
                                Instantiate(G.prefab, v,Quaternion.Euler(new Vector3(0,90,0)), transform);
                            else
                                Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                        case ("IlluWall"):
                            v = new Vector3(2 * x+transform.position.x, (float) 2.5+transform.position.y, 2 * y+transform.position.z);
                            if (!rotate)
                                Instantiate(G.prefab, v,Quaternion.Euler(new Vector3(0,90,0)), transform);
                            else
                                Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                        case ("IlluDoor"):
                            v = new Vector3(2 * x+transform.position.x, (float) 2.5+transform.position.y, 2 * y+transform.position.z);
                            if (!rotate)
                                Instantiate(G.prefab, v,Quaternion.Euler(new Vector3(0,90,0)), transform);
                            else
                                Instantiate(G.prefab, v, Quaternion.identity, transform);
                            break;
                    }
                }
            }
    }
    
    void Start()
    {
        map = p.codeToMap(code);
        GenerateLab();
    }
}
