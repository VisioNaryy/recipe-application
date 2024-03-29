﻿namespace RecipeApplication.Middleware;

public class HeadersMiddleware
{
    private readonly RequestDelegate _next;

    public HeadersMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            context.Request.Headers["X-Content-Type-Options"] = "nosniff";

            return Task.CompletedTask;
        });

        await _next(context);
    }
}