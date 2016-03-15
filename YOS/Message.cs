using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOS
{
    class Message
    {
        public event EventHandler MessageEventHandler;
        public void OnMessageEventHandler(MessageEventArgs e)
        {
            if (MessageEventHandler != null)
                MessageEventHandler(this, e);
        }
    }

    class MessageEventArgs : EventArgs
    {
        public string strMessageEventArgs;
        public MessageEventArgs(string strMessageEventArgs)
        {
            this.strMessageEventArgs = strMessageEventArgs;
        }
    }
}
