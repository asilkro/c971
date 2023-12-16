using CourseTracker.Models;
using CourseTracker.Supplemental;
using CourseTracker.ViewModels;

namespace CourseTracker.ContentPages;

public partial class Course : ContentPage
{
    private Connection _conn;
    private Models.Course _course;
    private Models.Term _term;

    public Course()
    {
        InitializeComponent();
        BindingContext = new CourseView();
        var db = _conn.GetAsyncConnection();
    }

    public async Task AddCourse(Models.Term term)
    {
        InitializeComponent();
        BindingContext = new CourseView();
        var db = _conn.GetAsyncConnection();
        await db.InsertAsync(_course);
        ((CourseView)BindingContext).TermId = term.TermId;
    }

    public async Task UpdateCourse(Models.Term term)
    {
        InitializeComponent();
        BindingContext = new CourseView();
        var db = _conn.GetAsyncConnection();
        await db.UpdateAsync(_course);
        ((CourseView)BindingContext).TermId = term.TermId;
    }

    public async Task DeleteCourse(Models.Term term)
    {
        InitializeComponent();
        BindingContext = new CourseView();
        var db = _conn.GetAsyncConnection();
        await db.DeleteAsync(_course);
        ((CourseView)BindingContext).TermId = term.TermId;
    }

    private async Task AddCourse_OnButtonClicked(object sender, EventArgs e)
    {
        _ = AddCourse(_term); //TODO: Make sure this can actually bind to a term
        await Navigation.PopAsync();
    }

    private async Task UpdateCourse_OnButtonClicked(object sender, EventArgs e)
    {
        _ = UpdateCourse(_term); //TODO: Make sure this can actually bind to a term
        await Navigation.PopAsync();
    }

    private async Task DeleteCourse_OnButtonClicked(object sender, EventArgs e)
    {
        _ = DeleteCourse(_term); //TODO: Make sure this can actually bind to a term
        await Navigation.PopAsync();
    }
}