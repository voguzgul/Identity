


using IdentityWEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;//DbCbaðlantýsý için ekliyoruzm
//DB Baðlantytýsý
builder.Services.AddDbContext<AppIdentityDbContext>(opt =>
{
    opt.UseSqlServer(configuration["ConnectionStrings:DefaultConnectionString"]);
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppIdentityDbContext>(); //IdentityUser isteniyor bizden. biz AppUserý IdentityUserdan türettiðim için AppUser ý alýyorum.
                                                                                                        //IdentityRole ile ilgili bir miras iþlemim olmadýðý için direkt veriyorum.
                                                                                                        //.AddEntityFrameworkStores<AppIdentityDbContext>();  bunlar nereye kaydedilecek diyorum
                                                                                                        //AppRole Olarak Deðiþtirildi.


builder.Services.AddRazorPages();



//builder.Services.AddMvc();//projenin ayaða kalkamsý için tüm bileþenleri kurara.
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);






var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//}

//middleware alaný
app.UseDeveloperExceptionPage();//sayfada bir hata aldýðýmýzda sayfayla ilgili hatalarý bize sunar. middlewaredir
app.UseStatusCodePages();//herhangi bir içerik dönemyen sayfalarda bizi bilgilendirici sayfaalrd dönüyor.
app.UseStaticFiles();//js , css gibi dosyalarýn eklenmesinde kullanýlýr.



//bu alanda System.InvalidOperationException: 'Endpoint Routing does not support 'IApplicationBuilder.UseMvc(...) hatasý alýrsanýz yukarýda ,
//builder.Services.AddMvc yerine builder.Services.AddMvc(option => option.EnableEndpointRouting = false); yaz.
app.UseMvcWithDefaultRoute();//arka planda Controller/Action/{id}  default bir route kullandýrýr.

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
