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

builder.Services.AddCors(opt =>  //Cors Politikasý
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()  //Gelen Herhangi Bir Baþlýða Ýzin Ver
        .AllowAnyMethod() //Gelen Herhangi Bir Metoda Ýzin Ver
        .SetIsOriginAllowed((host) => true)  //Gelen Herhangi Bir Kaynaða Ýzin Ver
        .AllowCredentials(); //Dýþarýdan Gelen Herhangi Bir Kimliðe Ýzin Ver
    });
});
builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddDbContext<SignalRContext>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();  //IAboutDal sýnýfýný gördüðün zaman EfAboutDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IAboutService,AboutManager>();//AboutService sýnýfýný gördüðün zaman AboutManager Sýnýfýný Çaðýr

builder.Services.AddScoped<IBookingDal, EfBookingDal>();  //IBookingDal sýnýfýný gördüðün zaman EfBookingDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IBookingService, BookingManager>();//IBookingService sýnýfýný gördüðün zaman BookingManager Sýnýfýný Çaðýr

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();  //ICategoryDal sýnýfýný gördüðün zaman EfCategoryDal Sýnýfýný Çaðýr
builder.Services.AddScoped<ICategoryService, CategoryManager>();//ICategoryService sýnýfýný gördüðün zaman CategoryManager Sýnýfýný Çaðýr

builder.Services.AddScoped<IContactDal, EfContactDal>();  //IContactDal sýnýfýný gördüðün zaman EfContactDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IContactService, ContactManager>();//IContactService sýnýfýný gördüðün zaman ContactManager Sýnýfýný Çaðýr

builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();  //IDiscountDal sýnýfýný gördüðün zaman EfDiscountDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IDiscountService, DiscountManager>();//IDiscountService sýnýfýný gördüðün zaman DiscountManager Sýnýfýný Çaðýr


builder.Services.AddScoped<IProductDal, EfProductDal>();  //IProductDal sýnýfýný gördüðün zaman EfProductDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IProductService, ProductManager>();//IProductService sýnýfýný gördüðün zaman ProductManager Sýnýfýný Çaðýr

builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();  //ISocialMediaDal sýnýfýný gördüðün zaman EfSocialMediaDal Sýnýfýný Çaðýr
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();//ISocialMeadiaService sýnýfýný gördüðün zaman SocialMediaManager Sýnýfýný Çaðýr

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();  //ITestimonialDal sýnýfýný gördüðün zaman EfTestimonialDal Sýnýfýný Çaðýr
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();//ITestimonialService sýnýfýný gördüðün zaman TestimonialManager Sýnýfýný Çaðýr



builder.Services.AddScoped<IOrderDal, EfOrderDal>();  //IOrderDal sýnýfýný gördüðün zaman EfOrderDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IOrderService, OrderManager>();//IOrderService sýnýfýný gördüðün zaman OrderManager Sýnýfýný Çaðýr


builder.Services.AddScoped<IOrderDetailsDal, EfOrderDetailsDal>();  //IOrderDetailsDal sýnýfýný gördüðün zaman EfOrderDetailsDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsManager>();//IOrderDetailsService sýnýfýný gördüðün zaman OrderDetailsManager Sýnýfýný Çaðýr

builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();  //IMoneyCaseDal sýnýfýný gördüðün zaman EfMoneyCaseDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();//IMoneyCaseService sýnýfýný gördüðün zaman MoneyCaseManager Sýnýfýný Çaðýr

builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();  //IMenuTableDal sýnýfýný gördüðün zaman EfMenuTableDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IMenuTableService, MenuTableManager>();//IMenuTableService sýnýfýný gördüðün zaman MenuTableManager Sýnýfýný Çaðýr

builder.Services.AddScoped<IBasketDal, EfBasketDal>();  //IBasketDal sýnýfýný gördüðün zaman EfBasketDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IBasketService, BasketManager>();//IBasketService sýnýfýný gördüðün zaman BasketManager Sýnýfýný Çaðýr

builder.Services.AddScoped<INotificationDal, EfNotificationDal>();  //INotificationDal sýnýfýný gördüðün zaman EfNotificationDal Sýnýfýný Çaðýr
builder.Services.AddScoped<INotificationService, NotificationManager>();//INotificationService sýnýfýný gördüðün zaman NotificationManager Sýnýfýný Çaðýr

builder.Services.AddScoped<ISliderDal, EfSliderDal>();  //ISliderDal sýnýfýný gördüðün zaman EfSliderDal Sýnýfýný Çaðýr
builder.Services.AddScoped<ISliderService, SliderManager>();//ISliderService sýnýfýný gördüðün zaman SliderManager Sýnýfýný Çaðýr

builder.Services.AddScoped<IMessageDal, EfMessageDal>();  //IMessageDal sýnýfýný gördüðün zaman EfMessageDal Sýnýfýný Çaðýr
builder.Services.AddScoped<IMessageService, MessageManager>();//IMessageService sýnýfýný gördüðün zaman MessageManager Sýnýfýný Çaðýr

builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //Ýliþkili Tabloda Hata Vermiyo

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
app.UseCors("CorsPolicy"); //Yukardaki Keyi çaðýrmýþ Olduk

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");
//localhost://7121/signalrhub

app.Run();
