﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using WpfApplication1.Annotations;
using WpfApplication1.Services;
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    class OrdersEditorViewModel : INotifyPropertyChanged
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly OrdersCommandProxy commandProxy;

        private ObservableCollection<OrderViewModel> _orders { get;  set; }

        public OrdersEditorViewModel(IOrdersRepository ordersRepository, OrdersCommandProxy commandProxy)
        {
            this.ordersRepository = ordersRepository;
            this.commandProxy     = commandProxy;

            // Create dummy order data.
            this.PopulateOrders();

            // Initialize a CollectionView for the underlying Orders collection.
            this.Orders = new ListCollectionView(_orders);

            // Track the current selection.
            this.Orders.CurrentChanged += SelectedOrderChanged;
            this.Orders.MoveCurrentTo(null);

            this.ProcessOrderCommand = new DelegateCommand<object>(ProcessOrder);
        }


        private void ProcessOrder(object parameter)
        {
            Debug.WriteLine(string.Format("Processing order {0} with parameter {1}.", SelectedOrder.OrderName, parameter));
        }

        public ICollectionView Orders { get; private set; }

        private void SelectedOrderChanged(object sender, EventArgs e)
        {
            SelectedOrder = Orders.CurrentItem as OrderViewModel;
            NotifyPropertyChanged("SelectedOrder");
        }

        public OrderViewModel SelectedOrder { get; private set; }

        public ICommand ProcessOrderCommand { get; private set; }

        private void PopulateOrders()
        {
            _orders = new ObservableCollection<OrderViewModel>();

            foreach (Services.Order order in this.ordersRepository.GetOrdersToEdit())
            {
                // Wrap the Order object in a presentation model object.
                var orderPresentationModel = new OrderViewModel(order);
                _orders.Add( orderPresentationModel );

                // Subscribe to the Save event on the individual orders.
                orderPresentationModel.Saved += this.OrderSaved;

                //TODO: 04 - Each Order Save command is registered with the application's SaveAll command.
                commandProxy.SaveAllOrdersCommand.RegisterCommand(orderPresentationModel.SaveOrderCommand);

            }

        }


        private void OrderSaved(object sender, DataEventArgs<OrderViewModel> e)
        {
            if (e != null && e.Value != null)
            {
                OrderViewModel order = e.Value;
                if (this.Orders.Contains( order ))
                {
                    order.Saved -= this.OrderSaved;
                    //TODO: 05 - As each order is saved, it is unregistered from the application's SaveAll command.
                    this.commandProxy.SaveAllOrdersCommand.UnregisterCommand( order.SaveOrderCommand );
                    // Remove saved orders from the collection.
                    this._orders.Remove(order);
                }
            }
        }

        //PropertyChangedEventHandler PropertyChanged  和 NotifyPropertyChanged
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        //[NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            //var handler = PropertyChanged;
            //if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            if(this.PropertyChanged!=null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
