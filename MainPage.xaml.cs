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
    }

    private void AssessmentsButton_Clicked(object sender, EventArgs e)
    {
        var term = new ContentPages.Assessment();
        term.BindingContext = new Models.Assessment();
    }

    private void CoursesButton_Clicked(object sender, EventArgs e)
    {
        var term = new ContentPages.Course();
        term.BindingContext = new Models.Course();
    }

    private void InstructorsButton_Clicked(object sender, EventArgs e)
    {
        var term = new ContentPages.Instructor();
        term.BindingContext = new Models.Instructor();
    }
}