using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLoad_v2.Core
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public int Count { get { return _heap.Count; } }

        public void Push(T data)
        {
            _heap.Add(data);
            int now = _heap.Count - 1;
            while (now > 0)
            {
                // 도장깨기를 시도
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;// 실패

                // 두 값을 교체한다.
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치를 이동한다.
                now = next;


            }
        }

        public T Pop()
        {
            T ret = _heap[0];

            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;
            int now = 0;

            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 1;
                int next = now;
                // 왼쪽 값이 현재 값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                // 오른값이 현재값(왼쪽 이동 포함)보다 크면, 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;
            }
        }
    }
}
