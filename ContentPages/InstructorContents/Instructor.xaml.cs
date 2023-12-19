using CourseTracker.Supplemental;
using CourseTracker.ViewModels;

namespace CourseTracker.ContentPages;

public partial class Instructor
{
    private Connection _conn;
    private Models.Instructor _instructor;
    private Models.Course _course;

    public Instructor()
    {
        InitializeComponent();
        BindingContext = new InstructorView();
        var db = _conn.GetAsyncConnection();
        //TODO: Finish constructor
    }

    public async Task AddInstructor(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new InstructorView();
        var db = _conn.GetAsyncConnection();
        await db.InsertAsync(_instructor); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((InstructorView)BindingContext).InstructorName = course.InstructorName;
    }

    public async Task UpdateInstructor(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new InstructorView();
        var db = _conn.GetAsyncConnection();
        await db.UpdateAsync(_instructor); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((InstructorView)BindingContext).InstructorName = course.InstructorName;
    }

    public async Task DeleteInstructor(Models.Course course)
    {
        InitializeComponent();
        BindingContext = new InstructorView();
        var db = _conn.GetAsyncConnection();
        await db.DeleteAsync(_instructor); //TODO: BUILD CONSTRUCTOR FROM INPUTS
        ((InstructorView)BindingContext).InstructorName = course.InstructorName;
    }

    private async void AddInstructor_OnButtonClicked(object sender, EventArgs e)
    {
        _ = AddInstructor(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async void UpdateInstructor_OnButtonClicked(object sender, EventArgs e)
    {
        _ = UpdateInstructor(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }

    private async void DeleteInstructor_OnButtonClicked(object sender, EventArgs e)
    {
        _ = DeleteInstructor(_course); //TODO: Make sure this can actually bind to a course
        await Navigation.PopAsync();
    }
}