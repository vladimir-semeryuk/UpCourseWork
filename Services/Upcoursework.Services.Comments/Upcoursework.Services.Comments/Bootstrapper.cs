﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Services.Comments.Comments;

namespace Upcoursework.Services.Comments;
public static class Bootstrapper
{
    public static IServiceCollection AddCommentService(this IServiceCollection services)
    {
        return services
            .AddSingleton<ICommentService, CommentService>();
    }
}
