using CourseTracker.ContentPages.CourseContents;

namespace CourseTracker;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void TermsButton_Clicked(object sender, EventArgs e)
    {
        var term = new ContentPages.Term();
        term.BindingContext = new Models.Term();
        term.Navigation.PopAsync();
    }

    private void AssessmentsButton_Clicked(object sender, EventArgs e)
    {
        var term = new ContentPages.Assessment();
        term.BindingContext = new Models.Assessment();
        term.Navigation.PopAsync();
    }

    private void CoursesButton_Clicked(object sender, EventArgs e)
    {
        var term = new Course();
        term.BindingContext = new Models.Course();
        term.Navigation.PopAsync();
    }

    private void InstructorsButton_Clicked(object sender, EventArgs e)
    {
        var term = new ContentPages.Instructor();
        term.BindingContext = new Models.Instructor();
        term.Navigation.PopAsync();
    }
}