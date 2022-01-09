using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StackExchange.Redis;
public class RedisConnectorHelper : MonoBehaviour
{
    // Start is called before the first frame update
    // public List<float> id1;
    public static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
    public ISubscriber sub = redis.GetSubscriber();
    // public Data JSONmessage;
    public Vector3 pos0;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos5;
    public Vector3 pos6;
    public Vector3 pos7;
    public Vector3 pos9;
    public Vector3 pos10;
    public Vector3 pos11;
    public Vector3 pos13;
    public Vector3 pos14;
    public Vector3 pos15;
    public Vector3 pos17;
    public Vector3 pos18;
    public Vector3 pos19;

    void Start()
    {
        

        
        
    }

    // Update is called once per frame
    
     
    void Update()
    {
        GameObject wrist0 = GameObject.FindGameObjectWithTag("wrist0");
        GameObject thumb2 = GameObject.FindGameObjectWithTag("thumb2");
        GameObject thumb3 = GameObject.FindGameObjectWithTag("thumb3");
        GameObject index5 = GameObject.FindGameObjectWithTag("index5");
        GameObject index6 = GameObject.FindGameObjectWithTag("index6");
        GameObject index7 = GameObject.FindGameObjectWithTag("index7");
        GameObject middle9 = GameObject.FindGameObjectWithTag("middle9");
        GameObject middle10 = GameObject.FindGameObjectWithTag("middle10");
        GameObject middle11 = GameObject.FindGameObjectWithTag("middle11");
        GameObject ring13 = GameObject.FindGameObjectWithTag("ring13");
        GameObject ring14 = GameObject.FindGameObjectWithTag("ring14");
        GameObject ring15 = GameObject.FindGameObjectWithTag("ring15");
        GameObject pinky17 = GameObject.FindGameObjectWithTag("pinky17");
        GameObject pinky18 = GameObject.FindGameObjectWithTag("pinky18");
        GameObject pinky19 = GameObject.FindGameObjectWithTag("pinky19");
        sub.Subscribe("Tracking", (channel, json) => {
        Data JSONmessage =  Data.JsonMessage(json);
        // do something with the message
        pos0 = new Vector3(JSONmessage.id0[0],JSONmessage.id0[1],JSONmessage.id0[2]*1000000);
        pos2 = new Vector3(JSONmessage.id2[0],JSONmessage.id2[1],JSONmessage.id2[2]);
        pos3 = new Vector3(JSONmessage.id3[0],JSONmessage.id3[1],JSONmessage.id3[2]);
        pos5 = new Vector3(JSONmessage.id5[0],JSONmessage.id5[1],JSONmessage.id5[2]);
        pos6 = new Vector3(JSONmessage.id6[0],JSONmessage.id6[1],JSONmessage.id6[2]);
        pos7 = new Vector3(JSONmessage.id7[0],JSONmessage.id7[1],JSONmessage.id7[2]);
        pos9 = new Vector3(JSONmessage.id9[0],JSONmessage.id9[1],JSONmessage.id9[2]);
        pos10 = new Vector3(JSONmessage.id10[0],JSONmessage.id10[1],JSONmessage.id10[2]);
        pos11 = new Vector3(JSONmessage.id11[0],JSONmessage.id11[1],JSONmessage.id11[2]);
        pos13 = new Vector3(JSONmessage.id13[0],JSONmessage.id13[1],JSONmessage.id13[2]);
        pos14 = new Vector3(JSONmessage.id14[0],JSONmessage.id14[1],JSONmessage.id14[2]);
        pos15 = new Vector3(JSONmessage.id15[0],JSONmessage.id15[1],JSONmessage.id15[2]);
        pos17 = new Vector3(JSONmessage.id17[0],JSONmessage.id17[1],JSONmessage.id17[2]);
        pos18 = new Vector3(JSONmessage.id18[0],JSONmessage.id18[1],JSONmessage.id18[2]);
        pos19 = new Vector3(JSONmessage.id19[0],JSONmessage.id19[1],JSONmessage.id19[2]);
        
        // GameObject middle9 = GameObject.FindGameObjectWithTag("middle9");
        // index5.transform.position = new Vector3(JSONmessage.id5[0]*10,JSONmessage.id5[1],JSONmessage.id5[2]);
        // middle9.transform.position = pos9;
        
        // Debug.Log(index5.transform.position);

        });
        wrist0.transform.position =pos0;
        // wrist0.transform.position = new Vector3(0,0,0);
        thumb2.transform.position = pos2;
        thumb3.transform.position = pos3;
        index5.transform.position = pos5;
        index6.transform.position = pos6;
        index7.transform.position = pos7;
        middle9.transform.position = pos9;
        middle10.transform.position = pos10;
        middle11.transform.position = pos11;
        ring13.transform.position = pos13;
        ring14.transform.position = pos14;
        ring15.transform.position = pos15;
        pinky17.transform.position = pos17;
        pinky18.transform.position = pos18;
        pinky19.transform.position = pos19;
    }


}

public class Data{

    public List<float> id0;
    // public List<float> id1;
    public List<float> id2;
    public List<float> id3;
    // public List<float> id4;
    public List<float> id5;
    public List<float> id6;
    public List<float> id7;
    // public List<float> id8;
    public List<float> id9;
    public List<float> id10;
    public List<float> id11;
    // public List<float> id12;
    public List<float> id13;
    public List<float> id14;
    public List<float> id15;
    // public List<float> id16;
    public List<float> id17;
    public List<float> id18;
    public List<float> id19;

    // public List<float> id20;

    public static Data JsonMessage(string message){

    return JsonUtility.FromJson<Data>(message);
    
}

}

