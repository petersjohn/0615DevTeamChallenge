using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0615_Class_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Order
        //POCO
    {
        public string CustomerName { get; set; }
        public string Items { get; set; };

        public decimal TotalPrice { get; set; }
    }
    class OrderRepository : IOrderRepository

        //REPO
    {
        private readonly List<Order> _orders = new List<Order>();

        public void Create(Order orderToAdd)
        {
            _orders.Add(orderToAdd);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }
        public Order GetOrderByID(int orderID)
public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> IOrderRepository.GetOrders()
        {
            throw new NotImplementedException();
        }
    }
    class DictionaryOrderRepository : IOrderRepository
    {
        private readonly Dictionary<int, Order> _orders = new Dictionary<int, Order>()
        public Dictionary<int, Order> GetOrders()
        {
            return _orders;
        }
        public void Create(Order orderToAdd)

        class OrderRepository
        {
            private readonly List<Order> _orders = new List<Order>();
        }
    }
    interface IOrderRepository
    {
        void Create(Order orderToAdd);
        Order GetOrderById(int orderId);
        IEnumerable<Order> GetOrders();
    }
}
