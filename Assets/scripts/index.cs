using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StackExchange.Redis;

public class index : MonoBehaviour
{
    // Start is called before the first frame update
    public static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
    public ISubscriber sub = redis.GetSubscriber();
    public Vector3 pos5;
    public Vector3 pos6;
    public Vector3 pos7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject index5 = GameObject.FindGameObjectWithTag("index5");
        GameObject index6 = GameObject.FindGameObjectWithTag("index6");
        GameObject index7 = GameObject.FindGameObjectWithTag("index7");
        sub.Subscribe("Tracking", (channel, json) => {
        Data JSONmessage =  Data.JsonMessage(json);
        // do something with the message
      
        pos5 = new Vector3(JSONmessage.id5[0],JSONmessage.id5[1],JSONmessage.id5[2]);
        pos6 = new Vector3(JSONmessage.id6[0],JSONmessage.id6[1],JSONmessage.id6[2]);
        pos7 = new Vector3(JSONmessage.id7[0],JSONmessage.id7[1],JSONmessage.id7[2]);
    

        });
        index5.transform.position = pos5;
        index6.transform.position = pos6;
        index7.transform.position = pos7;
    }
}
