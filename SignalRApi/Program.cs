using SignalRApi.Hubs;
using SignalRBusinessLayer.Abstract;
using SignalRBusinessLayer.Concrete;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.EntityFramework;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>  //Cors Politikas�
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()  //Gelen Herhangi Bir Ba�l��a �zin Ver
        .AllowAnyMethod() //Gelen Herhangi Bir Metoda �zin Ver
        .SetIsOriginAllowed((host) => true)  //Gelen Herhangi Bir Kayna�a �zin Ver
        .AllowCredentials(); //D��ar�dan Gelen Herhangi Bir Kimli�e �zin Ver
    });
});
builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddDbContext<SignalRContext>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();  //IAboutDal s�n�f�n� g�rd���n zaman EfAboutDal S�n�f�n� �a��r
builder.Services.AddScoped<IAboutService,AboutManager>();//AboutService s�n�f�n� g�rd���n zaman AboutManager S�n�f�n� �a��r

builder.Services.AddScoped<IBookingDal, EfBookingDal>();  //IBookingDal s�n�f�n� g�rd���n zaman EfBookingDal S�n�f�n� �a��r
builder.Services.AddScoped<IBookingService, BookingManager>();//IBookingService s�n�f�n� g�rd���n zaman BookingManager S�n�f�n� �a��r

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();  //ICategoryDal s�n�f�n� g�rd���n zaman EfCategoryDal S�n�f�n� �a��r
builder.Services.AddScoped<ICategoryService, CategoryManager>();//ICategoryService s�n�f�n� g�rd���n zaman CategoryManager S�n�f�n� �a��r

builder.Services.AddScoped<IContactDal, EfContactDal>();  //IContactDal s�n�f�n� g�rd���n zaman EfContactDal S�n�f�n� �a��r
builder.Services.AddScoped<IContactService, ContactManager>();//IContactService s�n�f�n� g�rd���n zaman ContactManager S�n�f�n� �a��r

builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();  //IDiscountDal s�n�f�n� g�rd���n zaman EfDiscountDal S�n�f�n� �a��r
builder.Services.AddScoped<IDiscountService, DiscountManager>();//IDiscountService s�n�f�n� g�rd���n zaman DiscountManager S�n�f�n� �a��r


builder.Services.AddScoped<IProductDal, EfProductDal>();  //IProductDal s�n�f�n� g�rd���n zaman EfProductDal S�n�f�n� �a��r
builder.Services.AddScoped<IProductService, ProductManager>();//IProductService s�n�f�n� g�rd���n zaman ProductManager S�n�f�n� �a��r

builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();  //ISocialMediaDal s�n�f�n� g�rd���n zaman EfSocialMediaDal S�n�f�n� �a��r
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();//ISocialMeadiaService s�n�f�n� g�rd���n zaman SocialMediaManager S�n�f�n� �a��r

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();  //ITestimonialDal s�n�f�n� g�rd���n zaman EfTestimonialDal S�n�f�n� �a��r
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();//ITestimonialService s�n�f�n� g�rd���n zaman TestimonialManager S�n�f�n� �a��r



builder.Services.AddScoped<IOrderDal, EfOrderDal>();  //IOrderDal s�n�f�n� g�rd���n zaman EfOrderDal S�n�f�n� �a��r
builder.Services.AddScoped<IOrderService, OrderManager>();//IOrderService s�n�f�n� g�rd���n zaman OrderManager S�n�f�n� �a��r


builder.Services.AddScoped<IOrderDetailsDal, EfOrderDetailsDal>();  //IOrderDetailsDal s�n�f�n� g�rd���n zaman EfOrderDetailsDal S�n�f�n� �a��r
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsManager>();//IOrderDetailsService s�n�f�n� g�rd���n zaman OrderDetailsManager S�n�f�n� �a��r

builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();  //IMoneyCaseDal s�n�f�n� g�rd���n zaman EfMoneyCaseDal S�n�f�n� �a��r
builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();//IMoneyCaseService s�n�f�n� g�rd���n zaman MoneyCaseManager S�n�f�n� �a��r

builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();  //IMenuTableDal s�n�f�n� g�rd���n zaman EfMenuTableDal S�n�f�n� �a��r
builder.Services.AddScoped<IMenuTableService, MenuTableManager>();//IMenuTableService s�n�f�n� g�rd���n zaman MenuTableManager S�n�f�n� �a��r

builder.Services.AddScoped<IBasketDal, EfBasketDal>();  //IBasketDal s�n�f�n� g�rd���n zaman EfBasketDal S�n�f�n� �a��r
builder.Services.AddScoped<IBasketService, BasketManager>();//IBasketService s�n�f�n� g�rd���n zaman BasketManager S�n�f�n� �a��r

builder.Services.AddScoped<INotificationDal, EfNotificationDal>();  //INotificationDal s�n�f�n� g�rd���n zaman EfNotificationDal S�n�f�n� �a��r
builder.Services.AddScoped<INotificationService, NotificationManager>();//INotificationService s�n�f�n� g�rd���n zaman NotificationManager S�n�f�n� �a��r

builder.Services.AddScoped<ISliderDal, EfSliderDal>();  //ISliderDal s�n�f�n� g�rd���n zaman EfSliderDal S�n�f�n� �a��r
builder.Services.AddScoped<ISliderService, SliderManager>();//ISliderService s�n�f�n� g�rd���n zaman SliderManager S�n�f�n� �a��r

builder.Services.AddScoped<IMessageDal, EfMessageDal>();  //IMessageDal s�n�f�n� g�rd���n zaman EfMessageDal S�n�f�n� �a��r
builder.Services.AddScoped<IMessageService, MessageManager>();//IMessageService s�n�f�n� g�rd���n zaman MessageManager S�n�f�n� �a��r

builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //�li�kili Tabloda Hata Vermiyo

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddCors(options =>            //Api Consume Edilmesi
{
    options.AddPolicy("SignalRApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy"); //Yukardaki Keyi �a��rm�� Olduk

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");
//localhost://7121/signalrhub

app.Run();
