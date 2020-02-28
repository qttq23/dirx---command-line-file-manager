using Xunit;
using System;

using dirx.gui;
    
namespace Console.Test{

    public class TestConsolex : IDisposable{


        public TestConsolex(){

        }

        public void Dispose(){

        }

        [Fact]
        public void TestGoToXY(){
            int x = 10;
            int y = 10;

            (int X, int Y) = Consolex.setXY(x, y);

            // check
            Assert.Equal(x, X);
            Assert.Equal(y, Y);
        }

        [Fact]
        public void TestGetX(){
            Consolex.setXY(10,10);
            int realX = Consolex.getX();

            Assert.Equal(10, realX);
        }

        [Fact]
        public void TestGetY()
        {
            Consolex.setXY(10, 20);
            int realY = Consolex.getY();

            Assert.Equal(20, realY);
        }

    }

}

