using CourseTracker.Supplemental;
using CourseTracker.ViewModels;

namespace CourseTracker.ContentPages.AssessmentContents;

public partial class Assessment
{
    private Connection _conn;
    private Models.Assessment _assessment;
    private Models.Course _course;

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
        await db.InsertAsync(_assessment); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((AssessmentView)BindingContext).CourseId = course.CourseId;
    }

    public async Task UpdateAssessment(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new AssessmentView();
        var db = _conn.GetAsyncConnection();
        await db.UpdateAsync(_assessment); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((AssessmentView)BindingContext).CourseId = course.CourseId;
    }

    public async Task DeleteAssessment(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new AssessmentView();
        var db = _conn.GetAsyncConnection();
        await db.DeleteAsync(_assessment); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((AssessmentView)BindingContext).CourseId = course.CourseId;
    }

    private async Task AddAssessment_OnButtonClicked(object sender, EventArgs e)
    {
        _ = AddAssessment(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async Task UpdateAssessment_OnButtonClicked(object sender, EventArgs e)
    {
        _ = UpdateAssessment(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async Task DeleteAssessment_OnButtonClicked(object sender, EventArgs e)
    {
        _ = DeleteAssessment(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }
}