using CourseTracker.ContentPages.AssessmentContents;
using CourseTracker.ContentPages.CourseContents;
using CourseTracker.ContentPages.InstructorContents;
using CourseTracker.ContentPages.TermContents;

namespace CourseTracker;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void TermsButton_Clicked(object sender, EventArgs e)
    {
        var term = new Term
        {
            BindingContext = new Models.Term()
        };
        term.Navigation.PopAsync();
    }

    private void AssessmentsButton_Clicked(object sender, EventArgs e)
    {
        var term = new Assessment
        {
            BindingContext = new Models.Assessment()
        };
        term.Navigation.PopAsync();
    }

    private void CoursesButton_Clicked(object sender, EventArgs e)
    {
        var term = new Course
        {
            BindingContext = new Models.Course()
        };
        term.Navigation.PopAsync();
    }

    private void InstructorsButton_Clicked(object sender, EventArgs e)
    {
        var term = new Instructor();
        term.BindingContext = new Models.Instructor();
        term.Navigation.PopAsync();
    }
}