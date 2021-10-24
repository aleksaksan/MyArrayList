using System;


namespace MyArrayList
{
    public class ArrayList<T> where T : IComparable<T>
    {
        T[] _array;
        int _capacity;
        public int Length { get; private set; }
        
        #region ctor's


        public ArrayList()
        {
            _capacity = 10;
            _array = new T[_capacity];
        }
        public ArrayList(int numOfElements)
        {
            _capacity = numOfElements;
            if (_capacity < 10)
                _capacity = 10;
            _array = new T[_capacity];
        }
        public ArrayList(T[] arr)
        {
            if (arr.Length <= 10)
                _capacity = 10;
            else
                _capacity = arr.Length;
            _array = new T[_capacity];
            for (int i = 0; i < arr.Length; i++)
            {
                _array[i] = arr[i];
            }
            Length = arr.Length;
        }
        #endregion
        /// /////////////////////////////////////////////////////////
        public int GetLength()
        {
            return Length;
        }
        public T[] ToArray()
        {
            T[] arr = new T[Length];
            for (int i = 0; i < Length; i++)
                arr[i] = _array[i];
            return arr;
        }   //ToArray() - вернёт хранимые данные в виде массива
        public void AddFirst(T val) //AddFirst(int val) - добавление в начало списка
        {
            this.Length++;
            IncreaseCapacity();
            T[] temp = new T[_capacity];
            temp[0] = val;
            for (int i = 1; i < Length; i++)
                temp[i] = _array[i - 1];
            _array = temp;
        }
        //AddFirst(ArrayList list) добавление в начало списка (т.е. слияние двух списков)
        public void AddFirst(ArrayList<T> otherList) 
        {
            Length += otherList.Length;
            IncreaseCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < otherList.Length; i++)
                temp[i] = otherList._array[i]; // здесь мог пригодиться итератор (list[i])
            for (int i = otherList.Length, j = 0; i < this.Length; i++, j++)
                temp[i] = _array[j];
            _array = temp;
        }
        //AddLast(int val) - добавление в конец списка
        public void AddLast(T val)
        {
            Length++;
            IncreaseCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < Length - 1; i++)
                temp[i] = _array[i];
            temp[Length - 1] = val;
            _array = temp;
        }
        //AddLast(ArrayList list) - то же самое, но с вашим самодельным классом
        public void AddLast(ArrayList<T> otherList)
        {
            Length += otherList.Length;
            IncreaseCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < Length - otherList.Length; i++)
                temp[i] = _array[i];
            for (int i = Length - otherList.Length, j = 0; i < this.Length; i++, j++)
                temp[i] = otherList._array[j]; // здесь мог пригодиться итератор (list[i])
            _array = temp;
        }
        //AddAt(int idx, int val) - вставка по указанному индексу
        public void AddAt(int idx, T val)
        {
            Length++;
            IncreaseCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < idx; i++)
                temp[i] = _array[i];
            temp[idx] = val;
            for (int i = idx + 1; i < Length; i++)
                temp[i] = _array[i - 1];
            _array = temp;
        }
        //AddAt(int idx, ArrayList list) - то же самое, но с вашим самодельным классом
        public void AddAt(int idx, ArrayList<T> otherList)
        {
            Length += otherList.Length;
            IncreaseCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < idx; i++)
                temp[i] = _array[i];
            for (int i = idx, j = 0; j < otherList.Length; i++, j++)
                temp[i] = otherList._array[j];
            for (int i = otherList.Length + idx; i < this.Length; i++)
                temp[i] = _array[i - otherList.Length];
            _array = temp;
        }
        //Set(int idx, int val) - поменять значение элемента с указанным индексом
        public void Set(int idx, T val)
        {
            _array[idx] = val;
        }
        //RemoveFirst() - удаление первого элемента
        public void RemoveFirst()
        {
            Length--;
            ReduceCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < Length; i++)
                temp[i] = _array[i + 1];
            
            _array = temp;
        }
        //RemoveLast() - удаление последнего элемента
        public void RemoveLast()
        {
            Length--;
            ReduceCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < Length; i++)
                temp[i] = _array[i];
            _array = temp;
        }
        //RemoveAt(int idx) - удаление по индексу
        public void RemoveAt(int idx)
        {
            Length--;
            ReduceCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < idx; i++)
                temp[i] = _array[i];
            for (int i = idx; i < Length; i++)
                temp[i] = _array[i + 1];
            _array = temp;
        }
        //RemoveFirstMultiple(int n) - удаление первых n элементов
        public void RemoveFirstMultiple(int n)
        {
            Length -= n;
            ReduceCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < Length; i++)
                temp[i] = _array[i + n - 1];
            _array = temp;
        }
        //RemoveLastMultiple(int n) - удаление последних n элементов
        public void RemoveLastMultiple(int n)
        {
            Length -= n;
            ReduceCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < Length; i++)
                temp[i] = _array[i];
            _array = temp;
        }
        //RemoveAtMultiple(int idx, int n) - удаление n элементов, начиная с указанного индекса
        public void RemoveAtMultiple(int idx, int n)
        {
            Length -= n;
            ReduceCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < idx; i++)
                temp[i] = _array[i];
            for (int i = idx; i < Length + n; i++)
                temp[i] = _array[idx + n + i];
            _array = temp;
        }
        //RemoveFirst(int val) - удалить первый попавшийся элемент,
        //значение которого равно val (вернуть индекс удалённого элемента)
        public int RemoveFirst(T val) 
        {
            int idx = -1;
            for (int i = 0; i < Length; i++)
            {
                if (val.Equals(_array[i]))
                {
                    idx = i;
                    break;
                }
            }
            if (idx == -1)
                return idx;
            Length--;
            ReduceCapacity();
            T[] temp = new T[_capacity];
            for (int i = 0; i < idx; i++)
                temp[i] = _array[i];
            for (int i = idx; i < Length; i++)
                temp[i] = _array[i];
            _array = temp;
            return idx;
        }
        //RemoveAll(int val) - удалить все элементы, равные val (вернуть кол-во удалённых элементов)
        public int RemoveAll(int val)
        {
            int numOfVal = 0;
            
            T[] temp = new T[_capacity];
            for (int i = 0, indxTemp = 0; i < Length; i++) 
            {
                if (!val.Equals(_array))
                {
                    temp[indxTemp++] = _array[i];
                }
                else
                    numOfVal++;
            }
            Length -= numOfVal;
            ReduceCapacity();
            _array = temp;
            return numOfVal;
        }
        //Contains(int val) - проверка, есть ли элемент в списке
        public bool Contains(int val)
        {
            foreach (var item in _array)
            {
                if (val.Equals(item))
                    return true;
            }
            return false;
        }
        //IndexOf(int val) - вернёт индекс первого найденного элемента,
        //равного val (или -1, если элементов с таким значением в списке нет)
        public int IndexOf(int val)
        {
            for (int i = 0; i < Length; i++)
            {
                if (val.Equals(_array[i]))
                    return i;
            }
            return -1;
        }
        //GetFirst() - вернёт значение первого элемента списка
        public T GetFirst()
        {
            return _array[0];
        }
        //GetLast() - вернёт значение последнего элемента списка
        public T GetLast()
        {
            return _array[Length - 1];
        }
        //Get(int idx) - вернёт значение элемента списка c указанным индексом
        public T Get(int idx)
        {
            return _array[idx];
        }
        //Reverse() - изменение порядка элементов списка на обратный
        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
                _array[i] = _array[Length - 1 - i];
        }
        //Max() - поиск значения максимального элемента
        public T Max()
        {
            T maxVal = _array[0];
            for (int i = 0; i < Length; i++)
                if (maxVal.CompareTo(_array[i]) < 0)
                    maxVal = _array[i];
            return maxVal;
        }
        //Min() - поиск значения минимального элемента
        public T Min()
        {
            T minVal = _array[0];
            for (int i = 0; i < Length; i++)
                if (minVal.CompareTo(_array[i]) > 0)
                    minVal = _array[i];
            return minVal;
        }
        //IndexOfMax() - поиск индекс максимального элемента
        public int IndexOfMax()
        {
            int idxOfMax = 0;
            T maxVal = _array[idxOfMax];
            for (int i = 0; i < Length; i++)
                if (maxVal.CompareTo(_array[i]) < 0)
                {
                    maxVal = _array[i];
                    idxOfMax = i;
                }
            return idxOfMax;
        }
        //IndexOfMin() - поиск индекс минимального элемента
        public int IndexOfMin()
        {
            int idxOfMin = 0;
            T minVal = _array[idxOfMin];
            for (int i = 0; i < Length; i++)
                if (minVal.CompareTo(_array[i]) > 0)
                {
                    minVal = _array[i];
                    idxOfMin = i;
                }
            return idxOfMin;
        }
        

        //Sort() - сортировка по возрастанию
        public void Sort()
        {
            for (int i = 1; i < Length; i++)
            {
                var key = _array[i];
                var j = i;
                while ((j > 1) && (_array[j - 1].CompareTo(key) > 0))
                {
                    MySwap(ref _array[j - 1], ref _array[j]);
                    j--;
                }

                _array[j] = key;
            }
        }
        //SortDesc() - сортировка по убыванию
        public void SortDesc()
        {
            for (int i = 1; i < Length; i++)
            {
                var key = _array[i];
                var j = i;
                while ((j > 1) && (_array[j - 1].CompareTo(key) < 0))
                {
                    MySwap(ref _array[j - 1], ref _array[j]);
                    j--;
                }

                _array[j] = key;
            }
        }
        //////////////////////////MyMethods/////////////////////////// 
        #region MyMethods
        public void Print()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write(_array[i] + "\t");
            }
            Console.WriteLine();
        }
        void IncreaseCapacity() // увеличить ёмкость
        {
            while (Length > _capacity)
                _capacity = _capacity * 3 / 2 + 1;
        }
        void ReduceCapacity() // Уменьшить ёмкость
        {
            while (_capacity > Length * 2)
                _capacity = Length / 3 * 2 + 1;
            if (_capacity < 10)
                _capacity = 10;
        }

        // MySwap()
        void MySwap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public int GetCapacity()
        {
            return _capacity;
        }
        #endregion
        /// //////////////////////
    }
}
