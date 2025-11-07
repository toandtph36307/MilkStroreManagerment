using System.Collections.Generic;

public class OrderBll
{
    private readonly OrderDal _orderDal;

    public OrderBll(OrderDal orderDal)
    {
        _orderDal = orderDal;
    }

    public List<OrderDto> GetOrders()
    {
        return _orderDal.GetAllOrders();
    }
}