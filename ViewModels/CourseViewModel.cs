using CommunityToolkit.Mvvm.ComponentModel;
using CourseTracker.Models;

namespace CourseTracker.ViewModels;

public partial class CourseViewModel : ObservableObject
{
    [ObservableProperty]
    List<Course> courses;

    public CourseViewModel()
    {
        LoadCourses();
    }

    private void LoadCourses()
    {
        foreach (var c in courses)
        {
            Courses.Add(c);
        }
    }
}
