using CourseTracker.Models;
using CourseTracker.Supplemental;
using CourseTracker.ViewModels;

namespace CourseTracker.ContentPages.AssessmentContents;

public partial class Assessment
{
    private Connection _conn;

    public Assessment()
    {
        InitializeComponent();
        BindingContext = new AssessmentView();
        var db = _conn.GetAsyncConnection();
        //TODO: Finish constructor
    }


    public async Task AddAssessment(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new AssessmentView();
        var db = _conn.GetAsyncConnection();
        await db.InsertAsync(new Models.Assessment()); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        //((AssessmentView)BindingContext).RelatedCourseId.Text = course.CourseId;
    }

    public async Task UpdateAssessment(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new AssessmentView();
        var db = _conn.GetAsyncConnection();
        await db.UpdateAsync(new Models.Assessment()); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        //((AssessmentView)BindingContext).RelatedCourseId.Text = course.CourseId;
    }

    public async Task DeleteAssessment(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new AssessmentView();
        var db = _conn.GetAsyncConnection();
        await db.DeleteAsync(new Models.Assessment()); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((AssessmentView)BindingContext).RelatedCourseId.Text = course.CourseId;
    }

    private async Task AddAssessment_OnButtonClicked(object sender, EventArgs e)
    {
        _ = AddAssessment(course: new Course()); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async Task UpdateAssessment_OnButtonClicked(object sender, EventArgs e)
    {
        _ = UpdateAssessment(course: new Course()); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async Task DeleteAssessment_OnButtonClicked(object sender, EventArgs e)
    {
        _ = DeleteAssessment(course: new Course()); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }
}