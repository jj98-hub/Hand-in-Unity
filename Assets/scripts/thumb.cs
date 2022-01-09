using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StackExchange.Redis;


public class thumb : MonoBehaviour
{
    // Start is called before the first frame update
    // public List<float> id1;
    public static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
    public ISubscriber sub = redis.GetSubscriber();
    // public Data JSONmessage;

    public Vector3 pos2;
    public Vector3 pos3;


    void Start()
    {
        

        
        
    }

    // Update is called once per frame
    
     
    void Update()
    {
        GameObject thumb2 = GameObject.FindGameObjectWithTag("thumb2");
        GameObject thumb3 = GameObject.FindGameObjectWithTag("thumb3");

        sub.Subscribe("Tracking", (channel, json) => {
        Data JSONmessage =  Data.JsonMessage(json);
        // do something with the message
        pos2 = new Vector3(JSONmessage.id2[0],JSONmessage.id2[1],JSONmessage.id2[2]);
        pos3 = new Vector3(JSONmessage.id3[0],JSONmessage.id3[1],JSONmessage.id3[2]);


        });

        thumb2.transform.position = pos2;
        thumb3.transform.position = pos3;

    }


}




