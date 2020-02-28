using System;

namespace dirx.gui{

    public class Consolex{

        // public static int origX = 0;
        // public static int origY = 0;

        // public static int curX = 0;

        // public static int curY = 0;

        // public static void setOriginXY(int x, int y){
            
        //     if(x < 0){
        //         x = 0;
        //     }
        //     if(y < 0){
        //         y = 0;
        //     }
        //     origX = x;
        //     origY = y;
        // }
        public static int getX(){
            return Console.CursorLeft;
        }

        public static int getY(){
            return Console.CursorTop;
        }

        public static (int X, int Y) setXY(int x, int y){

            Console.SetCursorPosition(x, y);
            return (Console.CursorLeft, Console.CursorTop);
        }

        public static void write(object o){
            Console.Write(o);
        }
    }
}
