using System;
using System.Collections.Generic;
using QLPhongTro.FunctionForms.salesForm.Models;
using QLPhongTro.FunctionForms.salesForm.Data;

namespace QLPhongTro.FunctionForms.salesForm.Business
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public int CreateOrder(
            int customerId,
            int userId,
            decimal totalPrice,
            DateTime orderDate,
            string status,
            int? discountId,
            List<OrderRow> orderRows,
            string paymentMethod,
            decimal amountPaid)
        {
            int orderId = _orderRepository.InsertOrder(customerId, userId, totalPrice, orderDate, status, discountId);

            foreach (var row in orderRows)
            {
                _orderRepository.InsertOrderDetail(orderId, row.ProductId, row.Price, row.Quantity);
            }

            _orderRepository.InsertPayment(orderId, paymentMethod, DateTime.Now, amountPaid);

            return orderId;
        }
    }
}