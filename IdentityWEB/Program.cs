


using IdentityWEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;//DbCba�lant�s� i�in ekliyoruzm
//DB Ba�lantyt�s�
builder.Services.AddDbContext<AppIdentityDbContext>(opt =>
{
    opt.UseSqlServer(configuration["ConnectionStrings:DefaultConnectionString"]);
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppIdentityDbContext>(); //IdentityUser isteniyor bizden. biz AppUser� IdentityUserdan t�retti�im i�in AppUser � al�yorum.
                                                                                                        //IdentityRole ile ilgili bir miras i�lemim olmad��� i�in direkt veriyorum.
                                                                                                        //.AddEntityFrameworkStores<AppIdentityDbContext>();  bunlar nereye kaydedilecek diyorum
                                                                                                        //AppRole Olarak De�i�tirildi.


builder.Services.AddRazorPages();



//builder.Services.AddMvc();//projenin aya�a kalkams� i�in t�m bile�enleri kurara.
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);






var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//}

//middleware alan�
app.UseDeveloperExceptionPage();//sayfada bir hata ald���m�zda sayfayla ilgili hatalar� bize sunar. middlewaredir
app.UseStatusCodePages();//herhangi bir i�erik d�nemyen sayfalarda bizi bilgilendirici sayfaalrd d�n�yor.
app.UseStaticFiles();//js , css gibi dosyalar�n eklenmesinde kullan�l�r.



//bu alanda System.InvalidOperationException: 'Endpoint Routing does not support 'IApplicationBuilder.UseMvc(...) hatas� al�rsan�z yukar�da ,
//builder.Services.AddMvc yerine builder.Services.AddMvc(option => option.EnableEndpointRouting = false); yaz.
app.UseMvcWithDefaultRoute();//arka planda Controller/Action/{id}  default bir route kulland�r�r.

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
