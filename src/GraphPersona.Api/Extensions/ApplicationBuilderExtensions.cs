namespace GraphPersona.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        app.UseCors();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.MapGraphQL();

        return app;
    }
}