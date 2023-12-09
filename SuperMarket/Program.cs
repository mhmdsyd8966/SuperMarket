using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RepositorySQL;
using Services;
using SuperMarket.Data;
using UseCase;
using UseCase.CategoriesUseCase;
using UseCase.Interface;
using UseCase.ProductsUseCase;
using UseCase.TransactionUseCase;
using UseCase.UseCaseInterface;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<MarketContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDbContext<AccountContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AccountContextConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();


builder.Services.AddAuthorization(
	options =>
	{
		options.AddPolicy("AdminOnly", p => p.RequireClaim("Positon", "Admin"));
		options.AddPolicy("CashierOnly", p => p.RequireClaim("Positon", "Cashier"));
	});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
//use case DI Category
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
//use case DI Product
builder.Services.AddTransient<IViewProductUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryIdUseCase,ViewProductsByCategoryIdUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IGetProductByIdUseCase,GetProductByIdUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
//use case DI Transaction
builder.Services.AddTransient<IGetTransactionUseCase,GetTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionUseCase,GetTodayTransactionUseCase>();
builder.Services.AddTransient<IRecorTransactionUseCase,RecordTransactionUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
