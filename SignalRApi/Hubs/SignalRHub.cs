using Microsoft.AspNetCore.SignalR;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub  //Sunucu Görevi Görecek Bu Sınıf
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }
		public static int clientCount { get; set; } = 0;

        public async Task SendStatistic()
        {
            var CategoryCountValue = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiverCategoryCount", CategoryCountValue);

			var ProductCountValue = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiverProductCount", ProductCountValue);

			var ActiveCategoryCountValue = _categoryService.TAciveCategoryCount();
			await Clients.All.SendAsync("ReceiverActiveCategoryCount", ActiveCategoryCountValue);

			var PasiveCategoryCountValue = _categoryService.TpasiveCategoryCount();
			await Clients.All.SendAsync("ReceiverPasiveCategoryCount", PasiveCategoryCountValue);

			var ProductCountByCategoryNameHamburgerValue = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiverProductCountByCategoryNameHamburger", ProductCountByCategoryNameHamburgerValue);

			var ProductCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiverProductCountByCategoryNameDrink", ProductCountByCategoryNameDrink);

			var ProductPriceAvgValue = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ProductPriceAvg", ProductPriceAvgValue);

			var ProductNamePriceByMaxPriceName = _productService.TProductNamePriceByMaxPrice();
			await Clients.All.SendAsync("ProductNamePriceByMaxPriceName", ProductNamePriceByMaxPriceName);

			var ProductNamePriceByMinPriceName = _productService.TProductNamePriceByMinPrice();
			await Clients.All.SendAsync("ProductNamePriceByMinPriceName", ProductNamePriceByMinPriceName);

			var ProductPriceByHamburgerValue = _productService.TProductPriceByHamburger();
			await Clients.All.SendAsync("ProductPriceByHamburger", ProductPriceByHamburgerValue);

			var TotalOrderCountValue = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("TotalOrderCount", TotalOrderCountValue);

			var ActiveOrderCountValue = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ActiveOrderCount", ActiveOrderCountValue);

			var LastOrderPriceValue = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("LastOrderPrice", LastOrderPriceValue);

			var TotalMoneyCaseAmountValue = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("TotalMoneyCaseAmount", TotalMoneyCaseAmountValue);

			var TodayTotalPriceValue = _orderService.TTodayTotalPrice();
			await Clients.All.SendAsync("TodayTotalPrice", TodayTotalPriceValue);

			var MenuTableCountValue = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("MenuTableCount", MenuTableCountValue);
		}
		public async Task SendProgress()
		{
			var TotalMoneyCaseAmountValue = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("TotalMoneyCaseAmount", TotalMoneyCaseAmountValue);

            var ActiveOrderCountValue = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ActiveOrderCount", ActiveOrderCountValue);

			var MenuTableCountValue = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("MenuTableCount", MenuTableCountValue);

			var ProductPriceAvgValue = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiverProductPriceAvgValue", ProductPriceAvgValue);

            var ProductCountByCategoryNameHamburgerValue = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiverProductCountByCategoryNameHamburgerValue", ProductCountByCategoryNameHamburgerValue);

            var ProductCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiverProductCountByCategoryNameDrink", ProductCountByCategoryNameDrink);

			var TotalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiverTotalOrderCount", TotalOrderCount);

            var CategoryCountValue = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiverCategoryCountValue", CategoryCountValue);

			var ProductCountValue = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiverProductCountValue", ProductCountValue);

            var LastOrderPriceValue = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("LastOrderPrice", LastOrderPriceValue);

			var TotalProductValue = _productService.TTotalProduct();
            await Clients.All.SendAsync("ReceiverTotalProduct", TotalProductValue);

            var BookinCountValue = _bookingService.TBookinCount();
            await Clients.All.SendAsync("ReceiverBookinCountValue", BookinCountValue);

        }
		public async Task GetBookingList()
		{
			var BookingListValue = _bookingService.TGetAll();
			await Clients.All.SendAsync("ReceiverAllBookingList", BookingListValue);
		}
		public async Task SendNotification()
		{
			var NotificationCountByStatusValue = _notificationService.NotificatinCountByStatus(false);
			await Clients.All.SendAsync("ReceiverNotificationCountByStatus", NotificationCountByStatusValue);


			var NotificationCountByStatusFalse = _notificationService.TLinqList(x => x.NotificationStatus == false).OrderByDescending(y => y.NotificationDate).ToList();
			await Clients.All.SendAsync("ReceiverNotificationCountByStatusFalse", NotificationCountByStatusFalse);
		}
		public async Task SendMessage(string User, string Message)
		{
			await Clients.All.SendAsync("ReceiverMessage", User, Message);
		}
		public async Task GetMenuTableList()
		{
			var TableListByStatusValue = _menuTableService.TGetAll();
			await Clients.All.SendAsync("ReceiverTableListByStatus", TableListByStatusValue);
		}
		public override async Task OnConnectedAsync()  //Sitede Aktif Kullanıcı Sayısı Gösterir
		{
			clientCount++;
			await Clients.All.SendAsync("ReceiverClientCount", clientCount);
			await base.OnConnectedAsync();
		}

		public override async Task OnDisconnectedAsync(Exception? exception)  //Hata Oluşursa Diye Exception ifadesi oluşturuyor
		{
			clientCount--;
			await Clients.All.SendAsync("ReceiverClientCount", clientCount);
			await base.OnDisconnectedAsync(exception);
		}
	}
}
