using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;

namespace WpfApplication1
{
    public static class OrdersCommands
    {
        //TODO: 03 - The application defines a global SaveAll command which invokes the Save command on all registered Orders. It is enabled only when all orders can be saved.
        public static CompositeCommand SaveAllOrdersCommand = new CompositeCommand();
    }


    /// <summary>
    /// Provides a class wrapper around the static SaveAll command.
    /// </summary>
    public class OrdersCommandProxy
    {
        public virtual CompositeCommand SaveAllOrdersCommand
        {
            get { return OrdersCommands.SaveAllOrdersCommand; }
        }
    }
}
