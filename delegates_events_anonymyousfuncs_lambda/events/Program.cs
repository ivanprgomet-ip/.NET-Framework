using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events
{
    using System.Collections;

    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class ListWithChangedEvent : ArrayList//we have to inherit arraylist so that we can override its functions (eg. the Add method)
    {
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        public override int Add(object value)
        {
            int i = base.Add(value);
            OnChanged(EventArgs.Empty);
            return i;
        }

        public override void Clear()
        {
            base.Clear();
            OnChanged(EventArgs.Empty);
        }
        
        public override object this[int index]
        {
            set
            {
                base[index] = value;
                OnChanged(EventArgs.Empty);//as soon as we att stuff to the list, the onchanged event fires. we dont want the eventargs to be null, thats why we set it to empty (empty is not null)
            }
        }
    }



}

namespace TestEvents
{
    using events;

    class EventListener
    {
        private ListWithChangedEvent List;
        public EventListener(ListWithChangedEvent list)
        {
            List = list;
            List.Changed += new ChangedEventHandler(ListChanged);
        }
        private void ListChanged(object sender, EventArgs e)
        {
            Console.WriteLine("This is called when the event fires");
        }
        public void Detach()
        {
            List.Changed -= new ChangedEventHandler(ListChanged);
            List = null;
        }
    }
    class Test
    {
        public static void Main()
        {
            ListWithChangedEvent list = new ListWithChangedEvent();
            EventListener listener = new EventListener(list);

            list.Add("item 1");//list gets changed
            list.Add("item 2");//list gets changed
            list.Clear();//list gets changed
            listener.Detach();
            Console.ReadKey();
        }
    }
}