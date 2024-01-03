using CommunityToolkit.Maui;
using CourseTracker.Models;
using CourseTracker.Supplemental;
using Microsoft.Extensions.Logging;

namespace CourseTracker;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // This *should* register all the pages in the assembly?
        builder.Services.AddSingleton<Course>();
        builder.Services.AddSingleton<Instructor>();
        builder.Services.AddSingleton<Term>();
        builder.Services.AddSingleton<Assessment>();
        builder.Services.AddTransient<ContentPages.CourseContents.Course>();
        builder.Services.AddTransient<ContentPages.InstructorContents.Instructor>();
        builder.Services.AddTransient<ContentPages.TermContents.Term>();
        builder.Services.AddTransient<ContentPages.AssessmentContents.Assessment>();
        builder.Services.AddTransient<ContentPages.CourseContents.CourseCreateModify>();
        builder.Services.AddTransient<ContentPages.InstructorContents.InstructorCreateModify>();
        builder.Services.AddTransient<ContentPages.TermContents.TermCreateModify>();
        builder.Services.AddTransient<ContentPages.AssessmentContents.AssessmentCreateModify>();

        builder.Services.AddSingleton<TrackerDb>();

        return builder.Build();
    }
}