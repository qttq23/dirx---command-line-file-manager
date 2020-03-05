using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using dirx.gui;

namespace Gui.Test
{
    public class TestSimpleGui : IDisposable
    {
        private string _directory;
        private SimpleGui gui;

        public TestSimpleGui()
        {
            gui = new SimpleGui();
        }

        public void Dispose()
        {
            // delete gui
            // ...

        }

        private void addDataGui_0(){

            List<string[]> data = new List<string[]>();

            gui.updateData(data);
        }

        private void addDataGui_3(){
            
            string[] col1 = new string[]{"aaa.txt", "file", "1/1/2020"};
            string[] col2 = new string[]{"bbb", "dir", "5/1/2020"};
            string[] col3 = new string[]{"ccc", "dir", "5/1/2020"};
            List<string[]> data = new List<string[]>();
            data.Add(col1);
            data.Add(col2);
            data.Add(col3);

            gui.updateData(data);
        }

        [Fact]
        public void UpdateGetData_NoData()
        {
            addDataGui_0();
            Assert.True(gui.isEmptyData());
        }

        [Fact]
        public void UpdateGetData_TwoColumns(){
            string[] col1 = new string[]{"aaa.txt", "file", "1/1/2020"};
            string[] col2 = new string[]{"ccc", "dir", "5/1/2020"};
            List<string[]> data = new List<string[]>();
            data.Add(col1);
            data.Add(col2);

            gui.updateData(data);

            Console.WriteLine($"{col1[0]} compare to {gui.getData(0,0)}");

            Assert.Equal(col1[0], gui.getData(0,0));
            Assert.Equal(col2[0], gui.getData(1,0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void HoverAt_InRange(int index){

            addDataGui_3();

            int realIndex = gui.hoverAt(index);
            Assert.Equal(index, realIndex);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(-2)]
        public void HoverAt_OutRange_Upper_Lower(int index){
            addDataGui_3();
            int realIndex = gui.hoverAt(index);


            Assert.Equal(0, realIndex);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        public void HoverPrevious_InRange(int index){
            addDataGui_3();
            int currentCursor = gui.hoverAt(index);
            Assert.Equal(index, currentCursor);

            int realIndex = gui.hoverPrevious();
            Assert.Equal(index - 1, realIndex);
        }

        [Theory]
        [InlineData(0)]
        public void HoverPrevious_OutRange_Lower(int index){
            addDataGui_3();
            int currentIndex = gui.hoverAt(index);
            int realIndex = gui.hoverPrevious();
            Assert.Equal(currentIndex, realIndex);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void HoverNext_InRange(int index){
            addDataGui_3();
            int currentIndex = gui.hoverAt(index);
            Assert.Equal(index, currentIndex);

            int realIndex = gui.hoverNext();

            // Assert.Equal(index + 1, realIndex);
            Assert.Equal(index + 1, realIndex);
        }

        [Theory]
        [InlineData(2)]
        public void HoverNext_OutRange_Upper(int index){
            addDataGui_3();
            int currentIndex = gui.hoverAt(index);
            int realIndex = gui.hoverNext();


            Assert.Equal(currentIndex, realIndex);
        }



    }
}
