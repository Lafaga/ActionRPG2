using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventTest : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision = null;

    void OnMotionEvent(int eventId)
    {
        Debug.Log("<color=green> Called Motion Event Id:" + eventId+ "</color>");
        //CommandManager.Execute(eventId);       
    }
}


//class  CommandManager
//{
//    public static void Execute(uint eventId){
        
//        Command targetCommand = CommandFactory.MakeCommand(eventId);
//        targetCommand.Run();
//}

//    class Command { public void Run() { } }
    
//    class AttackCommand : Command { }
//    class EffectCommand : Command { }

//    class AdvCommand : Command { }

//class CommandFactory
//{
//        public static Command MakeCommand(uint id) {
//            switch (id)
//            {
//                case 10000:
//                    return new AttackCommand();
//                    break;
//                case 20000:
//                    return new EffectCommand();
//                    break;
//                case 30000:
//                    return new AdvCommand();
//                    break;
//            }

//            return new Command();
//        }
//}