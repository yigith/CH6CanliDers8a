var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// �rnek arayaz�l�m (middleware) olu�tural�m
// araya girip isteklerin cevaplar�n�n
// taray�c� taraf�ndan html olarak alg�lanmas�n� istiyoruz

app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html; charset=UTF-8";

    // s�radaki i�lem
    await next();
});


// ROUTING
app.MapGet("/", Anasayfam);
app.MapGet("/about", Hakkinda);


string Anasayfam()
{
    return @"<h1>Siteme Ho�geldiniz.</h1>
            Hakk�mda detayl� bilgi i�in
            <a href=""/about"">t�klay�n�z</a>.";
}

string Hakkinda()
{
    return "<h1>Hakk�nda</h1>" +
           "<p>Benim ad�m Cafer.</p>" +
           "<hr>" +
           "<a href=\"/\">Anasayfaya d�n</a>";
}

app.Run();
