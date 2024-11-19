var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// örnek arayazýlým (middleware) oluþturalým
// araya girip isteklerin cevaplarýnýn
// tarayýcý tarafýndan html olarak algýlanmasýný istiyoruz

app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html; charset=UTF-8";

    // sýradaki iþlem
    await next();
});


// ROUTING
app.MapGet("/", Anasayfam);
app.MapGet("/about", Hakkinda);


string Anasayfam()
{
    return @"<h1>Siteme Hoþgeldiniz.</h1>
            Hakkýmda detaylý bilgi için
            <a href=""/about"">týklayýnýz</a>.";
}

string Hakkinda()
{
    return "<h1>Hakkýnda</h1>" +
           "<p>Benim adým Cafer.</p>" +
           "<hr>" +
           "<a href=\"/\">Anasayfaya dön</a>";
}

app.Run();
