using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public GameObject trashTrap;
    public GameObject coneTrap;
    public GameObject barrierTrap;
    public int numOfTrashes;
    public int numOfCones;
    public int numOfBarriers;
    public int numOfTraps;

    void Start(){
        
        numOfTrashes = Random.Range(20, 30);
        numOfCones = Random.Range(20,30);
        numOfBarriers = Random.Range(10, 15);

        PositionateTraps("trash");
        PositionateTraps("cone");
        PositionateTraps("barrier");
    }

   void PositionateTraps( string trapType){
      
       GameObject trap = null;

       if(trapType == "trash"){
           trap = trashTrap;
           numOfTraps = numOfTrashes;
       }else if(trapType == "cone"){
            trap = coneTrap;
            numOfTraps = numOfCones;
       }else if(trapType == "barrier"){
            trap = barrierTrap;
            numOfTraps = numOfBarriers;
       }

       for(int i= 0; i <= numOfTraps ; i++){

            float randomZTrap = UnityEngine.Random.Range(-30, 600);  
            float randomXTrap = UnityEngine.Random.Range(-2, 2);            
            var newTrap = (GameObject) Instantiate(trap, new Vector3(randomXTrap, 0.8f, randomZTrap),
                                                    Quaternion.identity);
                

       }

   }
}
