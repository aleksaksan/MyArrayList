using NUnit.Framework;
using MyArrayList;

namespace ArrayList.Test
{
    public class Tests
    {
        ArrayList<int> _arrlist;
        [SetUp]
        public void Setup()
        {
            _arrlist = new ArrayList<int>();
        }

        [Test]
        public void CtorTest()
        {
            //act
            ArrayList<int> list = new ArrayList<int>();
            int actualLength = list.Length;
            int actualCapacity = list.GetCapacity();
            //assert
            Assert.AreEqual(0, actualLength);
            Assert.AreEqual(10, actualCapacity);
        }
        [TestCase(0, new int[] { }, 0, 10)]
        [TestCase(9, new int[] { }, 0, 10)]
        [TestCase(11, new int[] { }, 0, 11)]
        public void CtorWithNumTest(int num, int[] expectedArr, int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(num);
            int actualLength = list.Length;
            int actualCapacity = list.GetCapacity();
            //act

            int[] actualArr = list.ToArray();
            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        [TestCase(new int[] { 0 }, new int[] { 0 }, 1, 10)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 3, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 11, 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, 12)]
        public void CtorWithArrTest(int[] OriginArr, int[] expectedArr, int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(OriginArr);
            int actualLength = list.Length;
            int actualCapacity = list.GetCapacity();

            //act
            int[] actualArr = list.ToArray();
            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        // public int GetLength()
        [TestCase(new int[] { 0 }, new int[] { 0 }, 1, 10)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 3, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 11, 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, 12)]
        public void GetLengthTest(int[] originArr, int[] expectedArr, int expectedLength, int expectedCapacity)
        {
            //arrnage
            ArrayList<int> list = new ArrayList<int>(originArr);
            int actualCapacity = list.GetCapacity();
            //act
            int actualLength = list.GetLength();
            int[] actualArr = list.ToArray();
            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //AddFirst(int val) - добавление в начало списка
        [TestCase(0, new int[] {  }, new int[] { 0 }, 1, 10)]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] {0, 1, 2, 3 }, 4, 10)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 12, 17)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 13, 19)]
        public void AddFirstTest(int val, int[] originArr, int[] expectedArr, 
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(originArr);
            
            //act

            list.AddFirst(val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //AddFirst(ArrayList list) добавление в начало списка (т.е. слияние двух списков)
        [TestCase(new int[] { 0, 0, 0 }, new int[] { }, new int[] { 0, 0, 0 }, 3, 10)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 0, 0, 0, 1, 2, 3 }, 6, 10)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 0,0,0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 14, 17)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 20, 29)]
        public void AddListFirstTest(int[] val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> valArr = new ArrayList<int>(val);
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.AddFirst(valArr);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        //AddLast(int val) - добавление в конец списка
        
        [TestCase(0, new int[] { }, new int[] { 0 }, 1, 10)]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] {  1, 2, 3, 0, }, 4, 10)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, }, 12, 17)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, }, 13, 19)]
        public void AddLastTest(int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.AddLast(val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //AddLast(ArrayList list) - то же самое, но с вашим самодельным классом
        [TestCase(new int[] { 0, 0, 0 }, new int[] { }, new int[] { 0, 0, 0 }, 3, 10)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 0, 0, 0, }, 6, 10)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 0, 0, }, 14, 17)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, 0, 0, 0, 0, 0, 0, 0, }, 20, 29)]
        public void AddListLastTest(int[] val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> valArr = new ArrayList<int>(val);
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.AddLast(valArr);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        //AddAt(int idx, int val) - вставка по указанному индексу
        //[TestCase(0, new int[] { }, new int[] { 0 }, 1, 10)]
        [TestCase(2, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 0, 3, }, 4, 10)]
        [TestCase(2, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 12, 17)]
        [TestCase(2, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 13, 19)]
        public void AddAtTest(int idx, int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.AddAt(idx, val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //AddAt(int idx, ArrayList list) - то же самое, но с вашим самодельным классом
        [TestCase(2, new int[] { 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 0, 0, 0, 3,}, 6, 10)]
        [TestCase(2, new int[] { 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 0, 0, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11,}, 14, 17)]
        [TestCase(2, new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,}, 20, 29)]
        public void AddListAtTest(int idx, int[] val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> valArr = new ArrayList<int>(val);
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.AddAt(idx, valArr);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //Set(int idx, int val) - поменять значение элемента с указанным индексом
        [TestCase(1, 0, new int[] { 1, 2, 3 }, new int[] { 1, 0, 3, }, 3, 10)]
        [TestCase(1, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 11, 11)]
        [TestCase(1, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 12, 12)]
        public void SetTest(int idx, int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.Set(idx, val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveFirst() - удаление первого элемента
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3, }, 2, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 10, 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 11, 12)]
        public void RemoveFirstTest(int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.RemoveFirst();

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveLast() - удаление последнего элемента
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2,}, 2, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10, 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 11, 12)]
        public void RemoveLastTest(int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.RemoveLast();

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveAt(int idx) - удаление по индексу
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 3 }, 2, 10)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 10, 11)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 12)]
        public void RemoveAtTest(int idx, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.RemoveAt(idx);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveFirstMultiple(int n) - удаление первых n элементов
        
        //[TestCase(3, new int[] { 1, 2, 3 }, new int[] { }, 0, 10)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 4, 5, 6, 7, 8, 9, 10, 11, }, 8, 11)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 9, 12)]
        public void RemoveFirstMultipleTest(int n, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList<int> list = new ArrayList<int>(originArr);

            //act

            list.RemoveFirstMultiple(n);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
    }
}