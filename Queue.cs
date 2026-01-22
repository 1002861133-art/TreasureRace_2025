using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureRace_2025
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;


        /* הפעולה בונה ומחזירה תור ריק **/
        public Queue()
        {
            this.first = null;
            this.last = null;
        }
        /* הפעולה מכניסה את הערך x לסוף התור הנוכחי **/
        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);
            if (this.last == null)
                this.first = temp;
            else
                this.last.SetNext(temp);

            this.last = temp;
        }
        /* הפעולה מוציאה ומחזירה את הערך הנמצא  בראש התור הנוכחי **/
        public T Remove()
        {
            T x = this.first.GetValue();
            this.first = this.first.GetNext();
            if (this.first == null)
                this.last = null;
            return x;
        }
        /* הפעולה מחזירה את הערך הנמצא  בראש התור הנוכחי **/
        public T Head()
        {
            return this.first.GetValue();
        }
        /* הפעולה מחזירה אמת אם התור הנוכחי ריק או שקר אחרת **/
        public bool IsEmpty()
        {
            return this.first == null;
        }
        /* הפעולה מחזירה מחרוזת המתארת את התור הנוכחי */
        public override string ToString()
        {
            string str = "[";
            Node<T> pos = this.first;
            while (pos != null)
            {
                if (pos.GetNext() == null)
                    str = str + pos.GetValue();
                else
                    str = str + pos.GetValue() + ", ";
                pos = pos.GetNext();
            }
            str = str + "]";
            return str;
        }


    }
}

